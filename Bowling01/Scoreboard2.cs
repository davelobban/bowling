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
                var scoredThrows = new List<int>();
                for (var i = 0; i < (_throws.Count>10?10: _throws.Count); i++)
                {
                    var value = GetScoreForThrow(_throws, i);
                    var scoreForThrow = value;

                    //if (currentThrow == Scoreboard.PinsFloored.Spare)
                    //{
                    //    scoreForThrow += GetScoreForThrow(_throws[i + 1]);
                    //}
                    scoredThrows.Add(scoreForThrow);
                }

                return  scoredThrows.Sum();
                ;
            }
        }

        public int GetScoreForThrow(List<Scoreboard.PinsFloored> throws, int i, Scoreboard.PinsFloored lastScore= Scoreboard.PinsFloored.Zero)
        {
            var value = throws[i];
            switch (value)
            {
                //case Scoreboard.PinsFloored.Strike:
                //    return 10 + GetScoreForThrow(throws, i + 1, value);
                case Scoreboard.PinsFloored.Spare:
                    return 10 + GetRawScoreForThrow(throws, i+1);
                default:
                    return (int)value;
            }
        }
        private int GetRawScoreForThrow(List<Scoreboard.PinsFloored> throws, int i)
        {
            var value = throws[i];
            switch (value)
            {
                case Scoreboard.PinsFloored.Strike:
                    return 10;
                case Scoreboard.PinsFloored.Spare:
                    return 10;
                default:
                    return (int)value;
            }
        }

    }
}
