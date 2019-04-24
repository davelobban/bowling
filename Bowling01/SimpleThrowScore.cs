using System.Collections.Generic;

namespace Bowling01
{
    public class SimpleThrowScore: ThrowScore
    {
        public override int GetScoreForThrow(List<Scoreboard.PinsFloored> throws, int i)
        {
            var value = throws[i];
            return (int) value;
        }
    }
}