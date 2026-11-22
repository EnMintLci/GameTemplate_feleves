using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoKnightsGame;

namespace GameTemplateMAUI.Repo
{
    public interface IGameHistoryRepository
    {
        Task SaveGameAsync(GameRecord game);
        Task<List<GameRecord>> GetGames();
        Task<GameRecord> GetGame(int id);
    }
}
