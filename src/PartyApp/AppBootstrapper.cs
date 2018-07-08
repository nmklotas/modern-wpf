using System;
using System.Windows;
using Caliburn.Micro;
using Castle.Windsor;
using PartyApp.Application;
using PartyApp.Login;
using PartyApp.Servers;
using PartyApp.Shell;
using PartyApp.TesonetApi;
using static Castle.MicroKernel.Registration.Component;

namespace PartyApp
{
    public class AppBootstrapper : BootstrapperBase
    {
        private IWindsorContainer _container;

        public AppBootstrapper() => Initialize();

        protected override void Configure()
        {
            base.Configure();

            _container = new WindsorContainer().
                Register(For<ShellViewModel>()).
                Register(For<ServersViewModel>()).
                Register(For<LoginViewModel>()).
                Register(For<LoggingInterceptor>()).
                Register(For<ITesonetApi>().ImplementedBy<HttpTesonetApi>()).
                Register(For<IWindowManager>().ImplementedBy<WindowManager>()).
                Register(For<IEventAggregator>().ImplementedBy<EventAggregator>().Interceptors<LoggingInterceptor>());
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            base.OnStartup(sender, e);
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.Resolve(service);
        }
    }
}
