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
                _.For<IPdfGenerator>().Use<PdfGenerator>();
                _.For<IBarcodeGenerator>().Use<QrCoderGenerator>();
                _.For<IMyLogger>().Use<MyConsoleLogger>().Singleton();
            });
        }

        public IContainer Create2_LoggerAsAlwaysNewInstance()
        {
            return new Container(_ =>
            {
                _.For<IPdfGenerator>().Use<PdfGenerator>();
                _.For<IBarcodeGenerator>().Use<QrCoderGenerator>();
                _.For<IMyLogger>().Use<MyConsoleLogger>().AlwaysUnique();
            });
        }

        [Test]
        public void Container1()
        {
            var c = Create();

            var l = c.GetInstance<IPdfGenerator>();
            Console.WriteLine($"Done: {l.GetType().Name} => #{l.GetHashCode()}");

            var x = c.GetInstance<IBarcodeGenerator>();
            Console.WriteLine($"Done: {x.GetType().Name} => #{x.GetHashCode()}");

            x = c.GetInstance<IBarcodeGenerator>();
            Console.WriteLine($"Done: {x.GetType().Name} => #{x.GetHashCode()}");
        }

        [Test]
        public void Container2()
        {
            var c = Create2_LoggerAsAlwaysNewInstance();

            // this resolving created two instances
            var l = c.GetInstance<IPdfGenerator>();
            Console.WriteLine($"Done: {l.GetType().Name} => #{l.GetHashCode()}");
        }
    }
}
