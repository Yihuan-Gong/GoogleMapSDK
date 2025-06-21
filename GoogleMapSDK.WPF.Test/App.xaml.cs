using GoogleMapSDK.Core.Extensions;
using GoogleMapSDK.WPF.Extensions;
using IoCContainer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GoogleMapSDK.WPF.Test
{
    /// <summary>
    /// App.xaml 的互動邏輯
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;
        
        public App()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("AppConfig.json")
                .Build();

            var serviceCollection = new IoCContainer.ServiceCollection();
            serviceCollection.AddCoreRegistration(configuration);
            serviceCollection.AddWPFRegistration();
            serviceCollection.AddSingleton<MainWindow>();
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        void App_Startup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }
}
