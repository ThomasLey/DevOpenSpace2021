using System;
using System.Diagnostics;
using AwesomeLib;

namespace DiTryouts.Models
{
    public class MyConsoleLogger : IMyLogger
    {
        public MyConsoleLogger()
        {
            Log($"(CTOR) {GetType().Name} => #{GetHashCode()}");
        }

        public void Log(string message) { Console.WriteLine($"[LOG] {message}"); }
    }

    public class SuperHeroLoggerAdapter : ISuperHeroLogger
    {
        private readonly IMyLogger _logger;

        public SuperHeroLoggerAdapter(IMyLogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public void Log(string message)
        {
            _logger.Log(message);
        }
    }
}