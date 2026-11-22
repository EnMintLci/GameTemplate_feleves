using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoKnightsGame.Figures;

namespace TwoKnightsGame
{
    public class Board
    {
        public int size { get; }
        public object[,] boardGrid { get; private set; }
        public int[] winningSpot { get; }
        public IFigure KnightA { get; }
        public IFigure KnightB { get; }
        public Board()
        {
            size = 5;
            winningSpot = new int[2];
            boardGrid = new object[size,size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    boardGrid[i, j] = 0;
                }
            }
            
            Random random = new Random();
            winningSpot[0] = 0;
            winningSpot[1] = 0;
            while (winningSpot[0] == 0 && winningSpot[1] == 0 || winningSpot[0] == 1 && winningSpot[1] == 1)
            {
                winningSpot[0] = random.Next(0, size);
                winningSpot[1] = random.Next(0, size);
            }

            KnightA = new Knight();
            KnightB = new Knight();
            KnightA.X = 0;
            KnightB.Y = 0;
            boardGrid[0,0] = KnightA;
            KnightB.X = size - 1;
            KnightB.Y = size - 1;
            boardGrid[size - 1, size - 1] = KnightB;
        }
        public bool IsWinningSpot(IFigure figure)
        {
            return figure.X == winningSpot[0] && figure.Y == winningSpot[1];
        }
        public bool MakeMove( Move move)
        {
            IFigure figure = move.figure;
            int _x = move.x;
            int _y = move.y;
            if ( ValidSpot(_x,_y) && boardGrid[_x,_y].Equals(0))
            {
                if(figure.TryMove(_x,_y))
                {
                boardGrid[figure.X,figure.Y] = 0;
                boardGrid[_x,_y] = figure;
                figure.X = _x;
                figure.Y = _y;
                boardGrid[_x,_y] = figure;
                    return true;
                }
            }
            return false;
        }
        private bool ValidSpot(int _x,int _y)
        {
            return _x >= 0 && _x < size && _y >= 0 && _y < size;
        }
    }
}
