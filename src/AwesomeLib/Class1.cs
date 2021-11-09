using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeLib
{
    public class SuperHero
    {
        private IEnumerable<BadGuy> _badGuys = new List<BadGuy>();
        public void EliminateAllSuperVailians(ISuperHeroLogger logger = null)
        {
            var safeLogger = logger ?? new EmptySuperHeroLogger();
            foreach (var badGuy in _badGuys)
            {
                safeLogger.Log("Killing bad buy");
                badGuy.Kill();
            }
        }
        public void EliminateAllSuperVailians(Action<string> logAction)
        {
            foreach (var badGuy in _badGuys)
            {
                logAction("Killing bad buy");
                badGuy.Kill();
            }
        }
    }

    public interface ISuperHeroLogger
    {
        void Log(string message);
    }

    public class EmptySuperHeroLogger : ISuperHeroLogger
    {
        public void Log(string message)
        {
        }
    }

    internal class BadGuy
    {
        public void Kill()
        {
            new LambdaLogger().Error("This is an error");
        }
    }

    public class LambdaLogger
    {
        public Action<string> Error { get; set; } = s => { };
    }
}
