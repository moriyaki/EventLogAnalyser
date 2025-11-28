using System.Windows;
using CommunityToolkit.Mvvm.DependencyInjection;
using EventLogAnalyser.ViewModels;

namespace EventLogAnalyser;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = Ioc.Default.GetService<IMainViewModel>()
            ?? throw new NullReferenceException();
    }
}