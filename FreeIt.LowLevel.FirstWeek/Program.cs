using FreeIt.Domain.Services.LowLevel.FirstWeek;
using System;
using FreeIt.Domain.Common.Extensions;

namespace FreeIt.LowLevel.FirstWeek
{
    class Program
    {
        static void Main(string[] args)
           => Execute();
        
        static void Execute()
        {
            var service = new FirstWeekService();

            service.Calculate().ToConsole();

            Console.ReadKey();
        }
    }
}
