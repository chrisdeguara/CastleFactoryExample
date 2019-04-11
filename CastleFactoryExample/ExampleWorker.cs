using CastleFactoryExample.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleFactoryExample
{
    public class ExampleWorker : IWorker
    {
        private readonly IMyFactory myFactory;

        public ExampleWorker(
            IMyFactory myFactory)
        {
            this.myFactory = myFactory ?? throw new ArgumentNullException(nameof(myFactory));
        }

        public void Start()
        {
            IMyProvider myProvider = null;
            try
            {
                myProvider = myFactory.CreateMyProvider("Provider Instance 1");
                myProvider.DoSomething1("Hello from instance 1");
                myProvider.DoSomething2("World from instance 1");
            }
            finally
            {
                myFactory.Release(myProvider);
            }


            IMyProvider myProvider2 = null;
            try
            {
                myProvider2 = myFactory.CreateMyProvider("Provider Instance 2");
                myProvider2.DoSomething1("Hello from instance 2");
                myProvider2.DoSomething2("World from instance 2");
            }
            finally
            {
                myFactory.Release(myProvider2);
            }
        }

        public void Stop()
        {
            //TODO stop
        }
    }
}
