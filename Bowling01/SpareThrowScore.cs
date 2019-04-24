using System;
using System.Collections.Generic;

namespace Bowling01
{
    public class SpareThrowScore : ThrowScore
    {
        public SpareThrowScore()
        {
        }

        public override int GetScoreForThrow(List<Scoreboard.PinsFloored> throws, int i)
        {
            var value = throws[i];
            switch (value)
            {
                //case Scoreboard.PinsFloored.Strike:
                //    return 10 + GetScoreForThrow(throws, i + 1, value);
                case Scoreboard.PinsFloored.Spare:
                    return 10 + GetRawScoreForThrow(throws, i+1);
                default:
                    throw new InvalidOperationException();
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