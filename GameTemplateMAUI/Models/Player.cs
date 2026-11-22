using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoKnightsGame;

namespace GameTemplateMAUI.Models
{
    public class Player
    {
        public string Name { get; set; }
        public List<GameEngine> Games { get; set; } = new List<GameEngine> ();  
    }
}
