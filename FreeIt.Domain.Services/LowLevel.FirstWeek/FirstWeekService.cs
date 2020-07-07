using System;
using FreeIt.Domain.Common.Extensions;
using FreeIt.Domain.Interfaces.Services;

namespace FreeIt.Domain.Services.LowLevel.FirstWeek
{
    public class FirstWeekService : ILowLevelService
    {
        public void Process()
            => Calculate().ToConsole();

        double Calculate()
            => (Math.Pow(6, 2) - 1) / 2;
    }
}
