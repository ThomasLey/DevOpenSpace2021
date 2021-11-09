using System;
using DiTryouts.Models;
using NUnit.Framework;
using StructureMap;

namespace DiTryouts
{
    [TestFixture]
    public class LazyFactorySingletonTest
    {
        public IContainer Create()
        {
            return new Container(_ =>
            {
                _.For<IBarcodeGenerator>().Use<ZXingGenerator>().AlwaysUnique();
                //_.For<IBarcodeGenerator>().Use<ZXingGenerator>().Singleton();
                //_.For<IBarcodeGenerator>().Use<ZXingGenerator>();
                // use is using an instance, which is basically handled as singleton
                //_.For<Func<IBarcodeGenerator>>().Use<Func<IBarcodeGenerator>>(context => () => context.GetInstance<IBarcodeGenerator>());
                _.For<Func<IBarcodeGenerator>>().Use<Func<IBarcodeGenerator>>(CreateGenerator);
                _.For<IMyLogger>().Use<MyConsoleLogger>().Singleton();
            });
        }

        private IBarcodeGenerator CreateGenerator()
        {
            return new QrCoderGenerator(new MyConsoleLogger());
        }

        [Test]
        public void Register_All_Three()
        {
            var c = Create();

            var w = c.GetInstance<Lazy<IBarcodeGenerator>>();
            Console.WriteLine($"Done: {w.GetType().Name} => #{w.GetHashCode()}");
            Console.WriteLine($"Done: {w.Value.GetType().Name} => #{w.Value.GetHashCode()}\r\n");

            var x = c.GetInstance<Lazy<IBarcodeGenerator>>();
            Console.WriteLine($"Done: {x.GetType().Name} => #{x.GetHashCode()}");
            Console.WriteLine($"Done: {x.Value.GetType().Name} => #{x.Value.GetHashCode()}\r\n");


            var y = c.GetInstance<Func<IBarcodeGenerator>>();
            Console.WriteLine($"Done y: {y.GetType().Name} => #{y.GetHashCode()}\r\n");
            var z = c.GetInstance<Func<IBarcodeGenerator>>();
            Console.WriteLine($"Done z: {z.GetType().Name} => #{z.GetHashCode()}\r\n");
            
            var y1 = y();
            Console.WriteLine($"Done: {y1.GetType().Name} => #{y1.GetHashCode()}");
            var y2 = y();
            Console.WriteLine($"Done: {y2.GetType().Name} => #{y2.GetHashCode()}");
        }
    }
}
