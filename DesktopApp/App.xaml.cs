using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DesktopApp.IRepositories;
using DesktopApp.Service;
using Microsoft.Extensions.DependencyInjection;

namespace DesktopApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 


    public partial class App : Application
    {
        private readonly ServiceProvider serviceProvider;
        public App()
        {

            ServiceCollection services = new ServiceCollection();
            services.AddSingleton<MainWindow>();
            serviceProvider = services.BuildServiceProvider();


        }
    }
}
