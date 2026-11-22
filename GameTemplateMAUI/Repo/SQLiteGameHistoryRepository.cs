using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoKnightsGame;

namespace GameTemplateMAUI.Repo
{
    internal class SQLiteGameHistoryRepository: IGameHistoryRepository
    {
        SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create;

        string databasePath =
            Path.Combine(FileSystem.Current.AppDataDirectory, "pets.db3");

        SQLiteAsyncConnection database;

        public SQLiteGameHistoryRepository()
        {
            database = new SQLiteAsyncConnection(databasePath, Flags);
            database.CreateTableAsync<GameRecord>().Wait();
        }

        Task<GameRecord> IGameHistoryRepository.GetGame(int id)
        {
            throw new NotImplementedException();
        }

        Task<List<GameRecord>> IGameHistoryRepository.GetGames()
        {
            throw new NotImplementedException();
        }

        Task IGameHistoryRepository.SaveGameAsync(GameRecord game)
        {
            throw new NotImplementedException();
        }
    }
}
