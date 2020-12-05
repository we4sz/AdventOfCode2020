using DayChallenge;
using NUnit.Framework;

namespace Day1Test
{
    public class DayTests
    {
        [TestCase(new int[] {1721, 979, 366, 299, 675, 1456}, 514579)]
        public void TestPart1(int[] data, int result)
        {
            Assert.AreEqual(result, Day1.Calculate1(data));
        }

        [TestCase(new int[] {1721, 979, 366, 299, 675, 1456}, 241861950)]
        public void TestPart2(int[] data, int result)
        {
            Assert.AreEqual(result, Day1.Calculate2(data));
        }
    }
}