using System.Collections.Generic;
using DayChallenge;
using NUnit.Framework;

namespace Day5Test
{
    public class DayTests
    {

        [TestCase("FBFBBFFRLR", 357)]
        [TestCase("BFFFBBFRRR", 567)]
        [TestCase("FFFBBBFRRR", 119)]
        [TestCase("BBFFBBFRLL", 820)]
        public void TestPart1(string data, int result)
        {
            Assert.AreEqual(result, Day5.Calculate1(data));
        }
        
    }
}