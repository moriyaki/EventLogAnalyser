using System.Configuration;
using System.Data;
using System.Windows;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Messaging;
using EventLogAnalyser.Services;
using EventLogAnalyser.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace EventLogAnalyser
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// サービスの登録をします
        /// </summary>
        public App()
        {
            Ioc.Default.ConfigureServices(Services);
        }

        /// <summary>
        /// 現在の App インスタンスを取得します
        /// </summary>
        public new static App Current => (App)Application.Current;

        /// <summary>
        /// サービスプロバイダです
        /// </summary>
        public IServiceProvider Services { get => ConfigureServices(); }

        /// <summary>
        /// サービスを登録します
        /// </summary>
        /// <returns></returns>
        private static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IMessenger, WeakReferenceMessenger>();
            services.AddSingleton<IMainViewModel, MainViewModel>();

            services.AddSingleton<IEventLogService, EventLogService>();

            return services.BuildServiceProvider();
        }
    }
}
