using FreeIt.Domain.Services.LowLevel.FirstWeek;
using System;
using FreeIt.Domain.Common.Helpers;

namespace FreeIt.LowLevel.FirstWeek
{
    class Program
    {
        static void Main(string[] args)
           => Execute();
        
        private static void Execute()
        {
            var service = new FirstWeekService();
            service.Calculate().DoubleToConsole();
            Console.ReadKey();
        }
    }
}
