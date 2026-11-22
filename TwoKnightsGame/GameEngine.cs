using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TwoKnightsGame
{
    
    public partial class GameEngine
    {
        public GameState State { get; set; } = new();
        
        private bool IsMoveLegal(Move move)
        {
            if (State.WhiteTurns == 1 && move.figure == State.Board.KnightA)
            {
                return true;
            }
            else if(State.WhiteTurns == 0 && move.figure == State.Board.KnightB)
            {
                return true;
            }
            return false;
        }
        public bool MakeMove(Move move)
        {
            if (State.IsTerminalState == false)
            {
                if (IsMoveLegal(move) && State.Board.MakeMove(move))
                {
                    State.WhiteTurns = (State.WhiteTurns + 1) % 2;
                    if (State.WhiteTurns == 0)
                    {
                        State.MoveHistory.Add(new Move[2]);
                        State.MoveHistory[State.TurnNo][0] = move;
                    }
                    else
                    {
                        //State.MoveHistory.Add(new Move[2]);
                        State.MoveHistory[State.TurnNo][1] = move;
                        State.TurnNo++;
                    }

                    if (State.Board.IsWinningSpot(State.Board.KnightA) || State.Board.IsWinningSpot(State.Board.KnightB))
                    {
                        State.IsTerminalState = true;
                    }
                    return true;
                }
            }
            return false;
        }
    }
}
