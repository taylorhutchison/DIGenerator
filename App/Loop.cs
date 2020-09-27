using System;
using System.Linq;

namespace App
{
    public static class Loop
    {
        public static void Start()
        {
            while (true)
            {
                Console.Write("What type of public transport do you want to take: ");
                var option = Console.ReadLine();
                if (option == "exit") return;
                var match = DIManager.Controllers.Where(c => c.Name.ToLower().StartsWith(option.ToLower())).FirstOrDefault();
                if (match != null)
                {
                    var instance = (IController)DIManager.CreateInstance(match);
                    instance.Get();
                    Console.Write("\n\n");
                }
                else
                {
                    Console.Write("\n\nCould not find matching controller\n\n");
                }
            }
        }
    }
}