using FreeIt.Domain.Services.LowLevel.SecondWeek;
using System;

namespace FreeIt.LowLevel.SecondWeek
{
    class Program
    {
        static void Main(string[] args)
            => Execute();

        static void Execute()
        {
            var service = new SecondWeekService();

            service.Process();

            Console.ReadKey();
        }
    }
}
