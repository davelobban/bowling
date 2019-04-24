using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling01
{
    public class Scoreboard
    {
        public const int SpareThrown = -1;
        private const int Ten = 10;
        private List<int> _throws;

        public Scoreboard(List<int> throws)
        {
            _throws = throws;
        }

        public int Score
        {
            get
            {
                var lastWasSpare = false;
                var rewardedScores = new List<int>();
                _throws.ForEach(t =>
                {
                    if (lastWasSpare)
                    {
                        if (t != SpareThrown)
                        {
                            lastWasSpare = false;
                        }

                        rewardedScores.Add((t == SpareThrown ? Ten : t) + 10);
                    }

                    if (t == SpareThrown)
                    {
                        lastWasSpare = true;
                    }

                    rewardedScores.Add((t == SpareThrown ? Ten : t));
                });
                return rewardedScores.Sum();
            }
        }

        //_throws.Sum(t => t==SpareThrown?Ten:t);
    }
}
