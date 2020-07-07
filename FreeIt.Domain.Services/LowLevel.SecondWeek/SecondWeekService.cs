using FreeIt.Domain.Common.Constants;
using FreeIt.Domain.Common.Extensions;
using FreeIt.Domain.Common.Helpers;
using FreeIt.Domain.Interfaces.Services;

namespace FreeIt.Domain.Services.LowLevel.SecondWeek
{
    public class SecondWeekService : ILowLevelService
    {
        public void Process()
            => Calculate(GetReady()).ToConsole();

        private (double, double, string) GetReady()
        {
            double arg1;
            double arg2;

            while (!double.TryParse(Constants.Templates.EnterValue.GetValueFromConsole(), out arg1))
                Constants.TextErrors.WrongFormat.ToConsole();

            while (!double.TryParse(Constants.Templates.EnterValue.GetValueFromConsole(), out arg2))
                Constants.TextErrors.WrongFormat.ToConsole();

            var @operator = Constants.Templates.EnterOperation.GetValueFromConsole();

            while (!@operator.IsOperator())
            {
                Constants.TextErrors.WrongFormat.ToConsole();
                @operator = Constants.Templates.EnterOperation.GetValueFromConsole();
            }

            return (arg1, arg2, @operator);
        }

        double Calculate((double arg1, double arg2, string @operator) tuple)
            => MathHelper.Calculate(tuple.arg1, tuple.arg2, tuple.@operator);
    }
}