using System;
using DiTryouts.Models;
using NUnit.Framework;
using StructureMap;

namespace DiTryouts
{
    [TestFixture]
    public class SingletonTest
    {
        public IContainer Create()
        {
            return new Container(_ =>
            {
                _.For<IBarcodeGenerator>().Use<QrCoderGenerator>();
                _.For<IMyLogger>().Use<MyConsoleLogger>().Singleton();
            });
        }

        [Test]
        public void Container1()
        {
            var c = Create();

            var x = c.GetInstance<IBarcodeGenerator>();
            Console.WriteLine($"Done: {x.GetType().Name} => #{x.GetHashCode()}");

            x = c.GetInstance<IBarcodeGenerator>();
            Console.WriteLine($"Done: {x.GetType().Name} => #{x.GetHashCode()}");

        }
    }
}
