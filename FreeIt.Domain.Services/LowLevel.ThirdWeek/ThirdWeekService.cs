using System.Collections.Generic;
using FreeIt.Domain.Common.Constants;
using FreeIt.Domain.Common.Extensions;
using FreeIt.Domain.Common.Helpers;

namespace FreeIt.Domain.Services.LowLevel.ThirdWeek
{
    public class ThirdWeekService
    {
        public void Process()
            => Calculate(GetReady().ToArray()).LongToConsole();

        private List<int> GetReady()
        {
            var args = new List<int>();

            int count;

            while (!int.TryParse(Constants.Templates.EnterCountValues.ReadValueFromConsole(), out count))
                Constants.TextErrors.WrongFormat.StringToConsole();

            for (int i = 0; i < count; i++)
            {
                var text = string.Format(Constants.Templates.EnterValueTemplate, i + 1);

                int value;

                while (!int.TryParse(text.ReadValueFromConsole(), out value))
                    Constants.TextErrors.WrongFormat.StringToConsole();

                args.Add(value);
            }

            return args;
        }

        private long Calculate(params int[] args)
            => MathHelper.CalculateMultiply(args);
    }
}