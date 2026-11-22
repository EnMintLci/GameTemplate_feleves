using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoKnightsGame;
using CommunityToolkit.Mvvm.Messaging;
using GameTemplateMAUI.Repo;

namespace GameTemplateMAUI.Sessions
{
    public class LocalSession : ISession
    {
        private readonly IGameHistoryRepository _repo;
        private readonly GameEngine _engine;

        public GameState State => _engine.State;

        public LocalSession(GameEngine engine)
        {
            _engine = engine;
            
        }

        public bool RequestMove(Move move)
        {
            

            bool accepted = _engine.MakeMove(move);

            if (accepted)
            {
                StateChanged?.Invoke(this, _engine.State);
            }
            if (State.IsTerminalState)
                {
                GameEnded?.Invoke(this, State); 
            }
            return accepted;
        }

        public event EventHandler<GameState>? StateChanged;
        public event EventHandler<GameState>? GameEnded;
    }
}
