using System.Threading.Tasks;
using FreeIt.Domain.Common.Constants;
using FreeIt.Domain.Common.Extensions;
using FreeIt.Domain.Interfaces.Services;

namespace FreeIt.Domain.Services.LowLevel.FourthWeek
{
    public class FourthWeekService : IFourthWeekService
    {
        private readonly IGameService _gameService;

        public FourthWeekService(IGameService gameService)
            => _gameService = gameService;

        public async Task Process()
        {
            await _gameService.StartGame();
            _gameService.FireproofPrize.ToConsole(Constants.Templates.WinnerPrizeTemplate);
        }
    }
}