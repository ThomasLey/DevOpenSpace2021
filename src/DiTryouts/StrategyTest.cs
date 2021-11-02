using System;
using System.Linq;
using NUnit.Framework;
using StructureMap;

namespace DiTryouts
{
    [TestFixture]
    public class StrategyTest
    {
        public IContainer Create()
        {
            return new Container(_ =>
            {
                _.For<IPdfGenerator>().Use<PdfGenerator>();
                _.For<IBarcodeGenerator>().Use<ZXingGenerator>();
                _.For<IBarcodeGenerator>().Use<QrCoderGenerator>();
                _.For<IMyLogger>().Use<MyConsoleLogger>().Singleton();
            });
        }

        [Test]
        public void LetsTestStrategies()
        {
            var c = Create();

            var x = c.GetInstance<IPdfGenerator>();
            Console.WriteLine($"Done: {x.GetType().Name} => #{x.GetHashCode()}");
        }

        [Test]
        public void LetsTestStrategies2()
        {
            var c = Create();

            var x = c.GetAllInstances<IBarcodeGenerator>();
            x.ToList().ForEach(y => Console.WriteLine($"Done: {y.GetType().Name} => #{y.GetHashCode()}"));
        }
    }

    [TestFixture]
    public class LazyFactorySingletonTests
    {
        [Test]
        public void Register_All_Three()
        {
            Assert.Fail("implement me");
        }
    }
}