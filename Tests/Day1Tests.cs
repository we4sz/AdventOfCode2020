using NUnit.Framework;

namespace Day1Test
{
    public class Day1Tests
    {
        [TestCase(new int[] {1721, 979, 366, 299, 675, 1456}, 514579)]
        public void TestDay1Part1(int[] data, int result)
        {
            Assert.AreEqual(result, Day1.Day1.Calculate1(data));
        }

        [TestCase(new int[] {1721, 979, 366, 299, 675, 1456}, 241861950)]
        public void TestDay1Part2(int[] data, int result)
        {
            Assert.AreEqual(result, Day1.Day1.Calculate2(data));
        }
    }
}