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
                    var scorer = GetScorerFor(_throws[i]);
                    var value = scorer.GetScoreForThrow(_throws, i);
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

        public ThrowScore GetScorerFor(Scoreboard.PinsFloored value)
        {
            switch (value)
            {
                case Scoreboard.PinsFloored.Spare:
                    return new SpareThrowScore();
                case Scoreboard.PinsFloored.Strike:
                    return new StrikeThrowScore();
                default:
                    return new SimpleThrowScore();
            }
        }
    }
}
