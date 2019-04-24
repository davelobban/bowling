using System.Collections.Generic;

namespace Bowling01
{
    public abstract class ThrowScore
    {
        public abstract int GetScoreForThrow(List<Scoreboard.PinsFloored> throws, int i);
    }
}