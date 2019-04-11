using CastleFactoryExample.Interfaces;
using System;

namespace CastleFactoryExample.Providers
{
    public class MyProvider : IMyProvider
    {
        private readonly string s;

        public MyProvider(string s)
        {
            this.s = s;
        }

        public void DoSomething1(string s2)
        {
            Console.WriteLine($"DoSomething1 - s: {s} - s2: {s2}");
        }

        public void DoSomething2(string s2)
        {
            Console.WriteLine($"DoSomething2 - s: {s} - s2: {s2}");
        }
    }
}
