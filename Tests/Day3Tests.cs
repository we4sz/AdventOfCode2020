using System.Collections.Generic;
using DayChallenge;
using NUnit.Framework;

namespace Day3Test
{
    public class DayTests
    {
        private static string[] slope = new string[]
        {
            "..##.......",
            "#...#...#..",
            ".#....#..#.",
            "..#.#...#.#",
            ".#...##..#.",
            "..#.##.....",
            ".#.#.#....#",
            ".#........#",
            "#.##...#...",
            "#...##....#",
            ".#..#...#.#"
        };

        public static IEnumerable<TestCaseData> Part1TestData
        {
            get
            {
                yield return new TestCaseData(slope, (1, 3), 7);
                yield return new TestCaseData(slope, (1, 1), 2);
                yield return new TestCaseData(slope, (1, 5), 3);
                yield return new TestCaseData(slope, (1, 7), 4);
                yield return new TestCaseData(slope, (2, 1), 2);
            }
        }

        public static IEnumerable<TestCaseData> Part2TestData
        {
            get
            {
                yield return new TestCaseData(slope, new List<(int, int)>
                {
                    (1, 1),
                    (1, 3),
                    (1, 5),
                    (1, 7),
                    (2, 1)
                }, 336);
            }
        }


        [TestCaseSource("Part1TestData")]
        public void TestPart1(string[] data, (int, int) slopeData, int result)
        {
            Assert.AreEqual(result, Day3.Calculate1(data, slopeData));
        }


        [TestCaseSource("Part2TestData")]
        public void TestPart2(string[] data, List<(int, int)> slopeData, int result)
        {
            Assert.AreEqual(result, Day3.Calculate2(data, slopeData));
        }
    }
}