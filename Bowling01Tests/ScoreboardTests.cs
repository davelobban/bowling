using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Bowling01;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Tests
{
    public class ScoreboardTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetScore_NoStrikes_ScoreIsSumOfTenRollsAt45()
        {
            var throws = new List<Scoreboard.PinsFloored> { Scoreboard.PinsFloored.Zero, Scoreboard.PinsFloored.One,
                Scoreboard.PinsFloored.Two, Scoreboard.PinsFloored.Three, Scoreboard.PinsFloored.Four,
                Scoreboard.PinsFloored.Five, Scoreboard.PinsFloored.Six, Scoreboard.PinsFloored.Seven,
                Scoreboard.PinsFloored.Eight, Scoreboard.PinsFloored.Nine };
            var expectedThrows = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            AssertActualIsSumOf(throws, expectedThrows);
        }

        private static void AssertActualIsSumOf(List<Scoreboard.PinsFloored> throws, List<int> expectedScores)
        {
            var expected = expectedScores.Sum(t => t);
            var actual = new Scoreboard(throws).Score;
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void GetScore_NoStrikes_ScoreIsSumOfTenRollsAt54()
        {
            var throws = new List<Scoreboard.PinsFloored> { Scoreboard.PinsFloored.Nine, Scoreboard.PinsFloored.One,
                Scoreboard.PinsFloored.Two, Scoreboard.PinsFloored.Three, Scoreboard.PinsFloored.Four,
                Scoreboard.PinsFloored.Five, Scoreboard.PinsFloored.Six, Scoreboard.PinsFloored.Seven,
                Scoreboard.PinsFloored.Eight, Scoreboard.PinsFloored.Nine };
            var expectedThrows = new List<int> { 9, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            AssertActualIsSumOf(throws, expectedThrows);
        }

        [Test]
        public void GetScore_NoStrikes_ScoreIsSumOfTenRollsAt0()
        {
            var throws = new List<Scoreboard.PinsFloored>
            {
                Scoreboard.PinsFloored.Zero, Scoreboard.PinsFloored.Zero,
                Scoreboard.PinsFloored.Zero,Scoreboard.PinsFloored.Zero,
                Scoreboard.PinsFloored.Zero, Scoreboard.PinsFloored.Zero,
                Scoreboard.PinsFloored.Zero,Scoreboard.PinsFloored.Zero,
                Scoreboard.PinsFloored.Zero, Scoreboard.PinsFloored.Zero,
            };
            var expectedThrows = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, };
            AssertActualIsSumOf(throws, expectedThrows);
        }


        [Test]
        public void GetScore_1SpareBeforeTenth_ScoreIsSumOfTenRollsPlusTenAt35()
        {
            //-1: spare
            var throws = new List<Scoreboard.PinsFloored> {
                Scoreboard.PinsFloored.Spare, Scoreboard.PinsFloored.Seven,
                Scoreboard.PinsFloored.Eight, Scoreboard.PinsFloored.Zero,
                Scoreboard.PinsFloored.Zero,Scoreboard.PinsFloored.Zero,
                Scoreboard.PinsFloored.Zero,Scoreboard.PinsFloored.Zero,
                Scoreboard.PinsFloored.Zero,Scoreboard.PinsFloored.Zero
            };
            var expectedScores = new List<int> { 17, 7, 8, 0, 0, 0, 0, 0, 0, 0 };
            AssertActualIsSumOf(throws, expectedScores);
        }
        //[Test]
        //public void GetScore_1SpareBeforeTenth_ScoreIsSumOfTenRollsPlusTenAt40()
        //{
        //    //-1: spare
        //    var throws = new List<int> { Scoreboard.SpareThrown, 9, 8, 4, 0, 0, 0, 0, 0, 0 };
        //    var expectedScores = new List<int> { 19, 9, 8, 4, 0, 0, 0, 0, 0, 0 };
        //    AssertActualIsSumOf(throws, expectedScores);
        //}


    }

}