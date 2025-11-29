using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using EventLogAnalyser.Dto;

namespace EventLogAnalyser.Services;

public interface IEventLogService
{
    IEnumerable<EventLogDto> LoadSystemLog();
}

public enum EventLevel
{
    LogAlways = 0,
    Critical = 1,
    Error = 2,
    Warning = 3,
    Information = 4,
    Verbose = 5
}

public class EventLogService : IEventLogService
{
    public IEnumerable<EventLogDto> LoadSystemLog()
    {
        var query = new EventLogQuery("System", PathType.LogName);
        using var reader = new EventLogReader(query);

        EventRecord record;
        while ((record = reader.ReadEvent()) != null)
        {
            var levelCode = (EventLevel)(record.Level ?? 0);
            if (levelCode == EventLevel.Information) { continue; }

            yield return new EventLogDto
            {
                Time = record.TimeCreated?.ToString("yyyy/MM/dd HH:mm:ss") ?? string.Empty,
                Source = record.ProviderName,
                InstanceID = record.Id.ToString(),
                Level = record.LevelDisplayName,
                Message = record.FormatDescription()
            };
        }
    }
}
