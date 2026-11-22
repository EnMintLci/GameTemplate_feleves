using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoKnightsGame
{
    public class GameRecord
    {
        public int Id { get; set; }

        public DateTime StartedAt { get; set; }
        public DateTime FinishedAt { get; set; }

        public List<Move> MoveHistory { get; set; } = new();
    }
}
