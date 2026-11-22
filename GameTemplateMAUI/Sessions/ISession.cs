using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoKnightsGame;

namespace GameTemplateMAUI.Sessions
{
    public interface ISession
    {
        public bool RequestMove(Move move);
        public GameState State { get; }
        event EventHandler<GameState>? StateChanged;
        event EventHandler<GameState>? GameEnded;
    }
}
