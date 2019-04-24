using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling01
{
    public class Scoreboard
    {
        public enum PinsFloored
        {
            Zero =0,
            One = 1,
            Two = 2,
            Three= 3,
            Four= 4,
            Five= 5,
            Six=6,
            Seven=7,
            Eight=8,
            Nine=9,
            Spare=-1,
            Strike=-2
        }

        public const int SpareThrown = -1;
        private const int Ten = 10;
        private List<PinsFloored> _throws;

        public Scoreboard(List<PinsFloored> throws)
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
                    int? throwTotal = null;
                    if (lastWasSpare)
                    {
                        if (t != PinsFloored.Spare && t != PinsFloored.Strike)
                        {
                            lastWasSpare = false;
                        }

                        throwTotal = (t == PinsFloored.Spare ? Ten : (int)t) + 10;
                    }

                    if (t == PinsFloored.Spare)
                    {
                        lastWasSpare = true;
                    }

                    if (throwTotal.HasValue == false)
                    {
                        throwTotal = (t == PinsFloored.Spare ? Ten : (int)t);
                    }
                    rewardedScores.Add((int) throwTotal);
                });
                return rewardedScores.Sum();
            }
        }

        //_throws.Sum(t => t==SpareThrown?Ten:t);
    }
}
