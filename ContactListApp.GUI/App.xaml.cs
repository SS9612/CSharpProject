using System;
using Microsoft.Extensions.DependencyInjection;
using ContactListApp.Library.Interfaces;
using ContactListApp.Library.Services;
using System.Windows;

namespace ContactListApp.GUI
{
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IContactService, ContactService>();

            ServiceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }
}
