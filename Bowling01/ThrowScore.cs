using System.Collections.Generic;

namespace Bowling01
{
    public abstract class ThrowScore
    {
        public abstract int GetScoreForThrow(List<Scoreboard.PinsFloored> throws, int i);
        protected int GetRawScoreForThrow(List<Scoreboard.PinsFloored> throws, int i)
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