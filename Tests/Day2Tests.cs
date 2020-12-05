using DayChallenge;
using NUnit.Framework;

namespace Day2Test
{
    public class DayTests
    {
        [TestCase(new string[] {"1-3 a: abcde","1-3 b: cdefg","2-9 c: ccccccccc"}, 2)]
        public void TestPart1(string[] data, int result)
        {
            Assert.AreEqual(result, Day2.Calculate1(data));
        }
        
        [TestCase(new string[] {"1-3 a: abcde","1-3 b: cdefg","2-9 c: ccccccccc"}, 1)]
        public void TestPart2(string[] data, int result)
        {
            Assert.AreEqual(result, Day2.Calculate2(data));
        }
    }
}