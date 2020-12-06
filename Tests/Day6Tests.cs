using System.Collections.Generic;
using DayChallenge;
using NUnit.Framework;

namespace Day6Test
{
    public class DayTests
    {
        [TestCase(new string[]
        {
            "abc",
            "",
            "a",
            "b",
            "c",
            "",
            "ab",
            "ac",
            "",
            "a",
            "a",
            "a",
            "a",
            "",
            "b"
        }, 11)]
        public void TestPart1(string[] data, int result)
        {
            Assert.AreEqual(result, Day6.Calculate1(data));
        }
        
        [TestCase(new string[]
        {
            "abc",
            "",
            "a",
            "b",
            "c",
            "",
            "ab",
            "ac",
            "",
            "a",
            "a",
            "a",
            "a",
            "",
            "b"
        }, 6)]
        public void TestPart2(string[] data, int result)
        {
            Assert.AreEqual(result, Day6.Calculate2(data));
        }
        
        
    }
}