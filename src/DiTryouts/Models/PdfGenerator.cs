using System;
using StructureMap;

namespace DiTryouts.Models
{
    public class PdfGenerator : IPdfGenerator
    {
        public PdfGenerator(IServiceLocator serviceLocator,IBarcodeGenerator generator, IMyLogger logger)
        {
            logger.Log($"(CTOR) {GetType().Name} => #{GetHashCode()} (GEN=#{generator.GetHashCode()}) (LOG=#{logger.GetHashCode()})");
        }
    }

    public interface IServiceLocator
    {
        T Get<T>();
    }

    public class ServiceLocator : IServiceLocator
    {
        private readonly IContainer _container;

        public ServiceLocator(IContainer container)
        {
            _container = container ?? throw new ArgumentNullException(nameof(container));
        }
        public T Get<T>()
        {
            return _container.GetInstance<T>();
        }
    }
}