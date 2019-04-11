using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Facilities.TypedFactory;
using CastleFactoryExample.Interfaces;
using CastleFactoryExample.Providers;

namespace CastleFactoryExample.Ioc.Installers
{
    public class MyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IWorker>()
                .ImplementedBy<ExampleWorker>()
                .Named("ExampleWorker"));

            container.Register(Component.For<IMyProvider>()
                .ImplementedBy<MyProvider>()
                .Named(@"MyProvider")
                .DependsOn(Dependency.OnComponent(typeof(IMyFactory), "MyFactory"))
                .LifeStyle.Transient);

            container.Register(Component.For<IMyFactory>()
                .Named(@"MyFactory")
                .AsFactory().LifeStyle.Singleton);
        }
    }
}