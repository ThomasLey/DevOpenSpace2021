using System;
using System.Collections.Generic;
using System.Linq;
using DiTryouts.Models;
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

                _.For(typeof(IStrategyResolver<>)).Use(typeof(StrategyResolver<>)).Singleton();
                _.For<GlobalState>().Singleton();
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

            var a = c.GetInstance<IEnumerable<IBarcodeGenerator>>();
            a.ToList().ForEach(b => Console.WriteLine($"Done: {b.GetType().Name} => #{b.GetHashCode()}"));
        }

        [Test]
        public void GetStrategyByState()
        {
            var c = Create();

            Console.WriteLine("== Getting initial strategy");
            var x = c.GetInstance<IStrategyResolver<IBarcodeGenerator>>();
            var y = x.Resolve();
            Console.WriteLine($"Done: {y.GetType().Name} => #{y.GetHashCode()}");

            Console.WriteLine("== Getting changed strategy");
            var s = c.GetInstance<GlobalState>();
            s.IBarcodeGenerator = nameof(QrCoderGenerator);
            y = x.Resolve();
            Console.WriteLine($"Done: {y.GetType().Name} => #{y.GetHashCode()}");
        }
    }
}