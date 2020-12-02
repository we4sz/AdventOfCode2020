using NUnit.Framework;

namespace Day1Test
{
    public class Day2Tests
    {
        [TestCase(new string[] {"1-3 a: abcde","1-3 b: cdefg","2-9 c: ccccccccc"}, 2)]
        public void TestDay2Part1(string[] data, int result)
        {
            Assert.AreEqual(result, Day2.Day2.Calculate1(data));
        }
        
        [TestCase(new string[] {"1-3 a: abcde","1-3 b: cdefg","2-9 c: ccccccccc"}, 1)]
        public void TestDay2Part2(string[] data, int result)
        {
            Assert.AreEqual(result, Day2.Day2.Calculate2(data));
        }
    }
}