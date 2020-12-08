using System.Collections.Generic;
using DayChallenge;
using NUnit.Framework;

namespace Day8Test
{
    public class DayTests
    {
        [TestCase(new string[]
        {
            "nop +0",
            "acc +1",
            "jmp +4",
            "acc +3",
            "jmp -3",
            "acc -99",
            "acc +1",
            "jmp -4",
            "acc +6"
        }, 5)]
        public void TestPart1(string[] data, int result)
        {
            Assert.AreEqual(result, Day8.Calculate1(data));
        }
        
        [TestCase(new string[]
        {
            "nop +0",
            "acc +1",
            "jmp +4",
            "acc +3",
            "jmp -3",
            "acc -99",
            "acc +1",
            "jmp -4",
            "acc +6"
        }, 8)]
        public void TestPart2(string[] data, int result)
        {
            Assert.AreEqual(result, Day8.Calculate2(data));
        }

    }
}