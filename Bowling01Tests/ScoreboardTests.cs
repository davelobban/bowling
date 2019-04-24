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
            var throws = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            AssertActualIsSumOf(throws);
        }

        private static void AssertActualIsSumOf(List<int> throws, List<int> expectedScores = null)
        {
            var expected = (expectedScores ?? throws).Sum(t => t);
            var actual = new Scoreboard(throws).Score;
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void GetScore_NoStrikes_ScoreIsSumOfTenRollsAt54()
        {
            var throws = new List<int> { 9, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            AssertActualIsSumOf(throws);
        }

        [Test]
        public void GetScore_NoStrikes_ScoreIsSumOfTenRollsAt0()
        {
            var throws = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            AssertActualIsSumOf(throws);
        }


        [Test]
        public void GetScore_1SpareBeforeTenth_ScoreIsSumOfTenRollsPlusTenAt34()
        {
            //-1: spare
            var throws = new List<int> { -1, 7, 8, 0, 0, 0, 0, 0, 0, 0 };
            var expectedScores = new List<int> { 17, 9, 8, 0, 0, 0, 0, 0, 0, 0 };
            AssertActualIsSumOf(throws, expectedScores);
        }
        [Test]
        public void GetScore_1SpareBeforeTenth_ScoreIsSumOfTenRollsPlusTenAt40()
        {
            //-1: spare
            var throws = new List<int> { -1, 9, 8, 4, 0, 0, 0, 0, 0, 0 };
            var expectedScores = new List<int> { 19, 9, 8, 4, 0, 0, 0, 0, 0, 0 };
            AssertActualIsSumOf(throws, expectedScores);
        }


    }

}