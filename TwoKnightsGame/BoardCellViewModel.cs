using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoKnightsGame
{
    public class BoardCellViewModel
    {
        public int X { get; set; }
        public int Y { get; set; }

        public string DisplayText { get; set; } = "";

        public bool IsWinningSpot { get; set; }
    }
}
