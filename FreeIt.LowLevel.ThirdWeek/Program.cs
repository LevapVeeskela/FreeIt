using FreeIt.Domain.Services.LowLevel.ThirdWeek;
using System;

namespace FreeIt.LowLevel.ThirdWeek
{
    class Program
    {
        static void Main(string[] args)
            => Execute();

        static void Execute()
        {
            var service = new ThirdWeekService();

            service.Process();

            Console.ReadKey();
        }
    }
}
