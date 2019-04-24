using System;
using System.Collections.Generic;

namespace Bowling01
{
    public class StrikeThrowScore : ThrowScore
    {
        public override int GetScoreForThrow(List<Scoreboard.PinsFloored> throws, int i)
        {
            return 10 + GetRawScoreForThrow(throws, i + 1) + GetRawScoreForThrow(throws, i + 2);
        }
    }
}