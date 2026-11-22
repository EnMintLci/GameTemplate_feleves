using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoKnightsGame.Figures
{
    public class Knight: IFigure
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool TryMove(int x, int y)
        {
            int diffx = x - X;
            int diffy = y - Y;
            if(Math.Abs(diffx) == 2 && Math.Abs(diffy) == 1 || Math.Abs(diffx) == 1 && Math.Abs(diffy) == 2)
            { return true; }
            return false;
        }
    }
}
