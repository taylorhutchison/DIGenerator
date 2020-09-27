using System;
using System.Linq;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            DIManager.RegisterControllers();
            DIManager.Register<ILogger, Logger>();
            DIManager.Register<IBus, Bus>();
            DIManager.Register<IFerry, Ferry>();
            DIManager.Register<ISubway, Subway>();

            Loop.Start();

        }
    }
}
