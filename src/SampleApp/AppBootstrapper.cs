﻿using System;
using System.Windows;
using Caliburn.Micro;
using Castle.Windsor;
using SampleApp.Application;
using SampleApp.Login;
using SampleApp.Servers;
using SampleApp.Shell;
using SampleApp.TesonetApi;
using Serilog;
using static Castle.MicroKernel.Registration.Component;

namespace SampleApp
{
    public class AppBootstrapper : BootstrapperBase
    {
        private readonly Lazy<IWindsorContainer> _container;

        public AppBootstrapper()
        {
            Initialize();
            _container = new Lazy<IWindsorContainer>(CreateContainer);
        }

        protected override void Configure()
        {
            base.Configure();
            Log.Logger = new LoggerConfiguration().
                MinimumLevel.Information().
                WriteTo.File("log.txt").
                CreateLogger();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            base.OnStartup(sender, e);
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.Value.Resolve(service);
        }

        private static IWindsorContainer CreateContainer()
        {
            return new WindsorContainer().
                Register(For<ShellViewModel>()).
                Register(For<ServersViewModel>()).
                Register(For<LoginViewModel>()).
                Register(For<LoggingInterceptor>()).
                Register(For<ITesonetApi>().ImplementedBy<HttpTesonetApi>()).
                Register(For<IWindowManager>().ImplementedBy<WindowManager>()).
                Register(For<IEventAggregator>().ImplementedBy<EventAggregator>().Interceptors<LoggingInterceptor>());
        }
    }
}
