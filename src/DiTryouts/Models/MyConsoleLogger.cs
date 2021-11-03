using System;

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
}