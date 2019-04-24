using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling01
{
    public class Scoreboard2
    {
        private List<Scoreboard.PinsFloored> _throws;
        public Scoreboard2(List<Scoreboard.PinsFloored> throws)
        {
            _throws = throws;
        }

        public int Score
        {
            get
            {
                var throws = _throws.Select(t=>(int)t).ToList();
                var scoredThrows = new List<int>();
                for (var i = 0; i < _throws.Count; i++)
                {
                    scoredThrows.Add(throws[i]);
                }

                return  scoredThrows.Sum();
                ;
            }
        }
    }
}
