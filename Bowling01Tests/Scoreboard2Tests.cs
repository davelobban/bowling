using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Bowling01;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Tests
{
    public class Scoreboard2Tests
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
            var actual = new Scoreboard2(throws).Score;
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
        [Test]
        public void GetScore_1SpareBeforeTenth_ScoreIsSumOfTenRollsPlusTenAt40()
        {
            var throws = new List<Scoreboard.PinsFloored> {
                Scoreboard.PinsFloored.Spare, Scoreboard.PinsFloored.Seven,
                Scoreboard.PinsFloored.Eight, Scoreboard.PinsFloored.Zero,
                Scoreboard.PinsFloored.Five,Scoreboard.PinsFloored.Zero,
                Scoreboard.PinsFloored.Zero,Scoreboard.PinsFloored.Zero,
                Scoreboard.PinsFloored.Zero,Scoreboard.PinsFloored.Zero
            };
            var expectedScores = new List<int> { 17, 7, 8, 0, 5, 0, 0, 0, 0, 0 };
            AssertActualIsSumOf(throws, expectedScores);
        }

        [Test]
        public void GetScore_2SparesBeforeTenth_ScoreIsSumOfTenRollsPlusTenAt66()
        {
            var throws = new List<Scoreboard.PinsFloored> {
                Scoreboard.PinsFloored.Spare, Scoreboard.PinsFloored.Seven,
                Scoreboard.PinsFloored.Eight, Scoreboard.PinsFloored.Zero,
                Scoreboard.PinsFloored.Five,Scoreboard.PinsFloored.Zero,
                Scoreboard.PinsFloored.Zero,Scoreboard.PinsFloored.Zero,
                Scoreboard.PinsFloored.Spare,Scoreboard.PinsFloored.Eight
            };
            var expectedScores = new List<int> { 17, 7, 8, 0, 5, 0, 0, 0, 18, 8 };
            AssertActualIsSumOf(throws, expectedScores);
        }
        [Test]
        public void GetScore_2SparesBeforeTenthAndOnTenthGetASpareWithAnEight_ScoreIsComputedCorrectlyAt75()
        {
            var throws = new List<Scoreboard.PinsFloored> {
                Scoreboard.PinsFloored.Spare, Scoreboard.PinsFloored.Seven,
                Scoreboard.PinsFloored.Eight, Scoreboard.PinsFloored.Zero,
                Scoreboard.PinsFloored.Five,Scoreboard.PinsFloored.Zero,
                Scoreboard.PinsFloored.Zero,Scoreboard.PinsFloored.Zero,
                Scoreboard.PinsFloored.Spare,Scoreboard.PinsFloored.Spare,
                Scoreboard.PinsFloored.Eight
            };
            var expectedScores = new List<int> { 17, 7, 8, 0, 5, 0, 0, 0, 20, 18 };
            AssertActualIsSumOf(throws, expectedScores);
        }

        [Test]
        public void GetScore_1StrikeBeforeTenth_ScoreIsComputedCorrectly()
        {
            var throws = new List<Scoreboard.PinsFloored> {
                Scoreboard.PinsFloored.Strike, Scoreboard.PinsFloored.Seven,
                Scoreboard.PinsFloored.Eight, Scoreboard.PinsFloored.Zero,
                Scoreboard.PinsFloored.Zero,Scoreboard.PinsFloored.Zero,
                Scoreboard.PinsFloored.Zero,Scoreboard.PinsFloored.Zero,
                Scoreboard.PinsFloored.Zero,Scoreboard.PinsFloored.Zero
            };
            var expectedScores = new List<int> { 17+8, 7, 8, 0, 0, 0, 0, 0, 0, 0 };
            AssertActualIsSumOf(throws, expectedScores);
        }

        [Test]
        public void GetScore_2StrikesBeforeTenth_ScoreIsComputedCorrectly()
        {
            var throws = new List<Scoreboard.PinsFloored> {
                Scoreboard.PinsFloored.Strike, Scoreboard.PinsFloored.Seven,
                Scoreboard.PinsFloored.Eight, Scoreboard.PinsFloored.Zero,
                Scoreboard.PinsFloored.Strike,Scoreboard.PinsFloored.Five,
                Scoreboard.PinsFloored.Four,Scoreboard.PinsFloored.Zero,
                Scoreboard.PinsFloored.Zero,Scoreboard.PinsFloored.Zero
            };
            var expectedScores = new List<int> { 17 + 8, 7, 8, 0, 10+5+4, 5, 4, 0, 0, 0 };
            AssertActualIsSumOf(throws, expectedScores);
        }

        [Test]
        public void GetScore_2StrikesOneSpareBeforeTenth_ScoreIsComputedCorrectly()
        {
            var throws = new List<Scoreboard.PinsFloored> {
                Scoreboard.PinsFloored.Strike, Scoreboard.PinsFloored.Seven,
                Scoreboard.PinsFloored.Eight, Scoreboard.PinsFloored.Zero,
                Scoreboard.PinsFloored.Strike,Scoreboard.PinsFloored.Spare,
                Scoreboard.PinsFloored.Four,Scoreboard.PinsFloored.Zero,
                Scoreboard.PinsFloored.Zero,Scoreboard.PinsFloored.Zero
            };
            var expectedScores = new List<int> { 17 + 8, 7, 8, 0, 10 + 10 + 4, 10+4, 4, 0, 0, 0 };
            AssertActualIsSumOf(throws, expectedScores);
        }

        [Test]
        public void GetScore_2StrikesOneSpareBeforeTenthStrikeOnTenthFollowedByEightAndNine_ScoreIsComputedCorrectly()
        {
            var throws = new List<Scoreboard.PinsFloored> {
                Scoreboard.PinsFloored.Strike, Scoreboard.PinsFloored.Seven,
                Scoreboard.PinsFloored.Eight, Scoreboard.PinsFloored.Zero,
                Scoreboard.PinsFloored.Strike,Scoreboard.PinsFloored.Spare,
                Scoreboard.PinsFloored.Four,Scoreboard.PinsFloored.Zero,
                Scoreboard.PinsFloored.Zero,Scoreboard.PinsFloored.Strike,
                Scoreboard.PinsFloored.Eight, Scoreboard.PinsFloored.Nine
            };
            var expectedScores = new List<int> { 17 + 8, 7, 8, 0, 10 + 10 + 4, 10 + 4, 4, 0, 0, 10 + 8 + 9 };
            AssertActualIsSumOf(throws, expectedScores);
        }

        [Test]
        public void GetScore_2StrikesOneSpareBeforeTenthStrikeOnTenthFollowedByStrikeAndNine_ScoreIsComputedCorrectly()
        {
            var throws = new List<Scoreboard.PinsFloored> {
                Scoreboard.PinsFloored.Strike, Scoreboard.PinsFloored.Seven,
                Scoreboard.PinsFloored.Eight, Scoreboard.PinsFloored.Zero,
                Scoreboard.PinsFloored.Strike,Scoreboard.PinsFloored.Spare,
                Scoreboard.PinsFloored.Four,Scoreboard.PinsFloored.Zero,
                Scoreboard.PinsFloored.Zero,Scoreboard.PinsFloored.Strike,
                Scoreboard.PinsFloored.Strike, Scoreboard.PinsFloored.Nine
            };
            var expectedScores = new List<int> { 17 + 8, 7, 8, 0, 10 + 10 + 4, 10 + 4, 4, 0, 0, 10 + 10 + 9 };
            AssertActualIsSumOf(throws, expectedScores);
        }
        [Test]
        public void GetScore_2StrikesOneSpareBeforeTenthStrikeOnTenthFollowedByStrikeAndStrike_ScoreIsComputedCorrectly()
        {
            var throws = new List<Scoreboard.PinsFloored> {
                Scoreboard.PinsFloored.Strike, Scoreboard.PinsFloored.Seven,
                Scoreboard.PinsFloored.Eight, Scoreboard.PinsFloored.Zero,
                Scoreboard.PinsFloored.Strike,Scoreboard.PinsFloored.Spare,
                Scoreboard.PinsFloored.Four,Scoreboard.PinsFloored.Zero,
                Scoreboard.PinsFloored.Zero,Scoreboard.PinsFloored.Strike,
                Scoreboard.PinsFloored.Strike, Scoreboard.PinsFloored.Strike
            };
            var expectedScores = new List<int> { 17 + 8, 7, 8, 0, 10 + 10 + 4, 10 + 4, 4, 0, 0, 10 + 10 + 10 };
            AssertActualIsSumOf(throws, expectedScores);
        }

        [Test]
        public void GetScore_2StrikesOneSpareBeforeTenthStrikeOnTenthFollowedByStrikeAndSpare_ScoreIsComputedCorrectly()
        {
            var throws = new List<Scoreboard.PinsFloored> {
                Scoreboard.PinsFloored.Strike, Scoreboard.PinsFloored.Seven,
                Scoreboard.PinsFloored.Eight, Scoreboard.PinsFloored.Zero,
                Scoreboard.PinsFloored.Strike,Scoreboard.PinsFloored.Spare,
                Scoreboard.PinsFloored.Four,Scoreboard.PinsFloored.Zero,
                Scoreboard.PinsFloored.Zero,Scoreboard.PinsFloored.Strike,
                Scoreboard.PinsFloored.Strike, Scoreboard.PinsFloored.Spare
            };
            var expectedScores = new List<int> { 17 + 8, 7, 8, 0, 10 + 10 + 4, 10 + 4, 4, 0, 0, 10 + 10 + 10 };
            AssertActualIsSumOf(throws, expectedScores);
        }
        [Test]
        public void GetScore_2StrikesOneSpareBeforeTenthStrikeOnTenthFollowedByZeroAndZero_ScoreIsComputedCorrectly()
        {
            var throws = new List<Scoreboard.PinsFloored> {
                Scoreboard.PinsFloored.Strike, Scoreboard.PinsFloored.Seven,
                Scoreboard.PinsFloored.Eight, Scoreboard.PinsFloored.Zero,
                Scoreboard.PinsFloored.Strike,Scoreboard.PinsFloored.Spare,
                Scoreboard.PinsFloored.Four,Scoreboard.PinsFloored.Zero,
                Scoreboard.PinsFloored.Zero,Scoreboard.PinsFloored.Strike,
                Scoreboard.PinsFloored.Zero, Scoreboard.PinsFloored.Zero
            };
            var expectedScores = new List<int> { 17 + 8, 7, 8, 0, 10 + 10 + 4, 10 + 4, 4, 0, 0, 10 };
            AssertActualIsSumOf(throws, expectedScores);
        }
    }

}