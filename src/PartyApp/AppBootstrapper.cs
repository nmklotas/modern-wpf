using System;
using System.Windows;
using Caliburn.Micro;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using SampleApp.Application;
using SampleApp.Login;
using SampleApp.Servers;
using SampleApp.Shell;
using SampleApp.TesonetApi;

namespace SampleApp
{
    public class AppBootstrapper : BootstrapperBase
    {
        private IWindsorContainer _container;

        public AppBootstrapper() => Initialize();

        protected override void Configure()
        {
            base.Configure();

            _container = new WindsorContainer().
                Register(Component.For<ShellViewModel>()).
                Register(Component.For<ServersViewModel>()).
                Register(Component.For<LoginViewModel>()).
                Register(Component.For<LoggingInterceptor>()).
                Register(Component.For<ITesonetApi>().ImplementedBy<HttpTesonetApi>()).
                Register(Component.For<IWindowManager>().ImplementedBy<WindowManager>()).
                Register(Component.For<IEventAggregator>().ImplementedBy<EventAggregator>().Interceptors<LoggingInterceptor>());
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
