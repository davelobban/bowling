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
            Zero = 0,
            One = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Spare = -1,
            Strike = -2
        }

        private const int Ten = 10;
        private List<PinsFloored> _throws;
        private PinsFloored _lastThrow = PinsFloored.Zero;
        private PinsFloored _secondToLastThrow = PinsFloored.Zero;
        public Scoreboard(List<PinsFloored> throws)
        {
            _throws = throws;
        }

        public int Score
        {
            get
            {

                var rewardedScores = new List<int>();
                var processingFinalThrowCount = 0;
                _throws.ForEach(t =>
                {
                    var thisThrowScore = (t == PinsFloored.Strike || t == PinsFloored.Spare) ? Ten : (int)t;
                    var secondToLastWasStrike = _secondToLastThrow == PinsFloored.Strike;
                    processingFinalThrowCount += rewardedScores.Count == 10 ? 1 : 0;
                    if (secondToLastWasStrike && rewardedScores.Count >= 2)
                    {
                        if (processingFinalThrowCount < 2)
                        {
                            rewardedScores[rewardedScores.Count - 2] += thisThrowScore;
                        }
                        else
                        {
                            rewardedScores[rewardedScores.Count - 1] += thisThrowScore;
                        }
                    }
                    if (processingFinalThrowCount < 2 && (LastWasStrike || LastWasSpare))
                    {
                        rewardedScores[rewardedScores.Count - 1] += thisThrowScore;
                    }

                    if (rewardedScores.Count < 10)
                    {
                        rewardedScores.Add(thisThrowScore);
                    }


                    _secondToLastThrow = _lastThrow;
                    _lastThrow = t;
                });

                return rewardedScores.Sum();
            }
        }

        private bool LastWasStrike => _lastThrow == PinsFloored.Strike;

        private bool LastWasSpare => _lastThrow == PinsFloored.Spare;
    }
}
