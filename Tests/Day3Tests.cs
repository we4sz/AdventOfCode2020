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
                yield return new TestCaseData(slope, new SlopeData {Down = 1, Right = 3}, 7);
                yield return new TestCaseData(slope, new SlopeData {Down = 1, Right = 1}, 2);
                yield return new TestCaseData(slope, new SlopeData {Down = 1, Right = 5}, 3);
                yield return new TestCaseData(slope, new SlopeData {Down = 1, Right = 7}, 4);
                yield return new TestCaseData(slope, new SlopeData {Down = 2, Right = 1}, 2);
            }
        }

        public static IEnumerable<TestCaseData> Part2TestData
        {
            get
            {
                yield return new TestCaseData(slope, new List<SlopeData>
                {
                    new SlopeData {Down = 1, Right = 1},
                    new SlopeData {Down = 1, Right = 3},
                    new SlopeData {Down = 1, Right = 5},
                    new SlopeData {Down = 1, Right = 7},
                    new SlopeData {Down = 2, Right = 1}
                }, 336);
            }
        }


        [TestCaseSource("Part1TestData")]
        public void TestPart1(string[] data, SlopeData slopeData, int result)
        {
            Assert.AreEqual(result, Day3.Calculate1(data, slopeData));
        }


        [TestCaseSource("Part2TestData")]
        public void TestPart2(string[] data, List<SlopeData> slopeData, int result)
        {
            Assert.AreEqual(result, Day3.Calculate2(data, slopeData));
        }
    }
}