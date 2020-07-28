using System.Threading.Tasks;

namespace FreeIt.Domain.Interfaces.Services
{
    public interface IGameService
    {
        int FireproofPrize { get; set; }

        Task StartGame();
    }
}