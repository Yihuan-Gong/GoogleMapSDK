using GoogleMapSDK.Core.Extensions;
using GoogleMapSDK.Winform.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoogleMapSDK.Winform.Test
{
    internal static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("AppConfig.json")
                .Build();

            var serviceCollection = new IoCContainer.ServiceCollection();
            serviceCollection.AddCoreRegistration(configuration);
            serviceCollection.AddWinformRegistration();
            serviceCollection.AddSingleton<Form1>();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var form = serviceProvider.GetService<Form1>() as Form;

            Application.Run(form);
        }
    }
}
