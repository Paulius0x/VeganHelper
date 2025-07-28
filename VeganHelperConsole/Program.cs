using System;
using VeganHelper.Models;

namespace VeganHelperConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vegan Helper Started:");
            ServiceRunner.CollectUserInfo();
            Console.WriteLine("The End. Press [Enter] to exit");
            Console.ReadKey();
        }
    }
}
