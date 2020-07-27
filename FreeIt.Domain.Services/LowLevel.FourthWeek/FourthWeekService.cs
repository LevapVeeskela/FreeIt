using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FreeIt.Domain.Common.Constants;
using FreeIt.Domain.Common.Enums;
using FreeIt.Domain.Common.Extensions;
using FreeIt.Domain.Common.Models.Requests.Millionaire;
using FreeIt.Domain.Interfaces.Services;
using FreeIt.Domain.Interfaces.Services.External;

namespace FreeIt.Domain.Services.LowLevel.FourthWeek
{
    public class FourthWeekService: IFourthWeekService
    {
        private readonly IMillionaireClient _millionaireClient;

        public FourthWeekService(IMillionaireClient millionaireClient)
            => _millionaireClient = millionaireClient;
        
        public async Task Process()
        {
            await _millionaireClient.GetAsync(new GetQuestionRequest
            {
                QType = LevelDifficulty.Easy,
                Count = 2
            }, new CancellationToken());
        }

        private List<int> GetReady()
        {
            var args = new List<int>();

            int count;

            while (!int.TryParse(Constants.Templates.EnterCountForPlusValues.GetValueFromConsole(), out count))
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

    }
}