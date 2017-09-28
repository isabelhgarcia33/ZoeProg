﻿namespace ZoeProg
{
  using System.Windows;
  using Prism.Modularity;
  using Prism.Unity;
  using Microsoft.Practices.Unity;
  using Common;
  using Services;
  using static Services.PackageRepository;

  public class AppBootstrapper : UnityBootstrapper
  {
    protected override void ConfigureContainer()
    {
      this.Container.RegisterType<IShellViewModel, ShellViewModel>(new ContainerControlledLifetimeManager());
      base.ConfigureContainer();
    }

    protected override void ConfigureServiceLocator()
    {
      this.Container.RegisterType<IPowerShellService, PowerShellService>(new ContainerControlledLifetimeManager());
      this.Container.RegisterType<IPackageService, PackageService>(new ContainerControlledLifetimeManager());
      this.Container.RegisterType<IPackageRepository, PackageRepository>(new ContainerControlledLifetimeManager());
      this.Container.RegisterType<IProgressService, ProgressService>(new ContainerControlledLifetimeManager());

      base.ConfigureServiceLocator();
    }

    protected override IModuleCatalog CreateModuleCatalog()
    {
      return new ConfigurationModuleCatalog();
    }

    protected override DependencyObject CreateShell()
    {
      return Container.Resolve<Shell>();
    }

    //protected override Prism.Regions.IRegionBehaviorFactory ConfigureDefaultRegionBehaviors()
    //{
    //  var factory = base.ConfigureDefaultRegionBehaviors();
    //  return factory;
    //}

    //protected override void ConfigureModuleCatalog()
    //{
    //  base.ConfigureModuleCatalog();
    //}

    protected override void InitializeShell()
    {
      base.InitializeShell();

      App.Current.MainWindow.Show();
    }
  }
}