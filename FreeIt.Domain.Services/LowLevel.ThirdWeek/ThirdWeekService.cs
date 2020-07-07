using System.Collections.Generic;
using FreeIt.Domain.Common.Constants;
using FreeIt.Domain.Common.Extensions;
using FreeIt.Domain.Common.Helpers;
using FreeIt.Domain.Interfaces.Services;

namespace FreeIt.Domain.Services.LowLevel.ThirdWeek
{
    public class ThirdWeekService : IThirdWeekService
    {
        public void Process()
            => Calculate(GetReady().ToArray()).ToConsole();

        private List<int> GetReady()
        {
            var args = new List<int>();

            int count;

            while (!int.TryParse(Constants.Templates.EnterCountValues.GetValueFromConsole(), out count))
                Constants.TextErrors.WrongFormat.ToConsole();

            for (int i = 0; i < count; i++)
            {
                var text = string.Format(Constants.Templates.EnterValueTemplate, i + 1);

                int value;

                while (!int.TryParse(text.GetValueFromConsole(), out value))
                    Constants.TextErrors.WrongFormat.ToConsole();

                args.Add(value);
            }

            return args;
        }

        private long Calculate(params int[] args)
            => MathHelper.CalculateMultiply(args);
    }
}