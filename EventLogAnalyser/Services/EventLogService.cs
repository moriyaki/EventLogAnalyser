using System.Diagnostics;
using EventLogAnalyser.Dto;

namespace EventLogAnalyser.Services;

public interface IEventLogService
{
    IEnumerable<EventLogDto> LoadSystemLog();
}

public class EventLogService : IEventLogService
{
    public IEnumerable<EventLogDto> LoadSystemLog()
    {
        var log = new EventLog("System");
        foreach (EventLogEntry entry in log.Entries)
        {
            var dto = new EventLogDto
            {
                Time = entry.TimeGenerated.ToString("yyyy/MM/dd hh:mm:ss"),
                Source = entry.Source,
                InstanceID = entry.InstanceId.ToString(),
                Level = entry.EntryType.ToString(),
                Message = entry.Message
            };
            if (dto.Level == "Information")
            {
                continue;
            }
            yield return dto;
        }
    }
}
