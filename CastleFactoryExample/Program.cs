using Castle.Facilities.TypedFactory;
using Castle.Windsor;
using Castle.Windsor.Installer;
using CastleFactoryExample.Interfaces;
using System;

namespace CastleFactoryExample
{
    class Program
    {
        private static WindsorContainer container;

        static void Main(string[] args)
        {
            InstallDependencies();

            var worker = container.Resolve<IWorker>();
            worker.Start();

            Console.WriteLine("Process completed. Press any key to exit...");
            Console.ReadKey();
        }

        private static void InstallDependencies()
        {
            container = new WindsorContainer();
            container.AddFacility<TypedFactoryFacility>();
            container.Install(FromAssembly.This());
        }
    }
}
