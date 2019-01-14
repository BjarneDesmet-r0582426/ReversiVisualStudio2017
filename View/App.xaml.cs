using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System.Windows;
using ViewModel;
using ViewModel.Interfaces;
using ViewModel.Services;


namespace View
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // show the options window


            var container = new UnityContainer();
            container.RegisterInstance<IUnityContainer>(container);
            container.RegisterType<ITimerService, TimerService>();
            container.RegisterInstance<ITimeService>(new TimeService());
            UnityServiceLocator locator = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => locator);


            var windowMain = new MainWindow();
            windowMain.DataContext = new OptionsViewModel();
            windowMain.Show();
        }
    }
}
