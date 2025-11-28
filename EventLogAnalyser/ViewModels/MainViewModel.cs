using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using EventLogAnalyser.Dto;
using EventLogAnalyser.Services;

namespace EventLogAnalyser.ViewModels;

public interface IMainViewModel;

public class MainViewModel : ObservableObject, IMainViewModel
{
    private readonly IEventLogService _service;

    public ObservableCollection<EventLogDto> Entries { get; } = [];

    public MainViewModel(IEventLogService service)
    {
        _service = service;
        Load();
    }

    private void Load()
    {
        Entries.Clear();
        foreach (var item in _service.LoadSystemLog())
        {
            Entries.Add(item);
        }
    }
}
