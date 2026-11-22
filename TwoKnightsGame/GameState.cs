using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoKnightsGame
{
    public class GameState
    {
        public int WhiteTurns { get; set; } = 1;
        public int TurnNo { get; set; } = 0;
        public bool IsTerminalState { get; set; }

        public Board Board { get; set; } = new Board();
        public List<Move[]> MoveHistory { get; set; } = new();
    }
}
