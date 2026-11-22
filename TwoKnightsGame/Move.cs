using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoKnightsGame.Figures;

namespace TwoKnightsGame
{
    public class Move
    {
        public Move(int x, int y, IFigure figure)
        {
            this.x = x;
            this.y = y;
            this.figure = figure;
        }

        public int x { get; set; }
        public int y { get; set; }
        public IFigure figure { get; }
    }
}
