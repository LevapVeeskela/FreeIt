using System;
using FreeIt.Domain.Common.Extensions;
using FreeIt.Domain.Interfaces.Services;

namespace FreeIt.Domain.Services.LowLevel.FirstWeek
{
    public class FirstWeekService : IFirstWeekService
    {
        public void Process()
            => Calculate().ToConsole();

        private double Calculate()
            => (Math.Pow(6, 2) - 1) / 2;
    }
}
