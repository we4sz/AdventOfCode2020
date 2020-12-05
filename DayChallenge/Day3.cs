using System.Collections.Generic;
using System.Linq;
using Inputs;

namespace DayChallenge
{
    public class SlopeData
    {
        public int Right { get; set; }

        public int Down { get; set; }
    }

    public class TraversingData
    {
        public int ColumnIndex { get; set; }
        public int AmountOfTrees { get; set; }
    }

    public static class Day3
    {
        public static int Calculate1(string[] data, SlopeData slopeData)
        {
            return data.WhereIndexIsModulo(slopeData.Down)
                .Aggregate(new TraversingData(), (traversingData, currentRow) => new TraversingData
                {
                    ColumnIndex = (traversingData.ColumnIndex + slopeData.Right) % currentRow.Length,
                    AmountOfTrees = traversingData.AmountOfTrees + (currentRow[traversingData.ColumnIndex] == '#' ? 1 : 0)
                }).AmountOfTrees;
        }

        public static int Calculate2(string[] data, List<SlopeData> slopesData)
        {
            return slopesData.Aggregate(1, (i, slopeData) =>
                i * Calculate1(data, slopeData));
        }

        public static int Execute1()
        {
            return Calculate1(Inputs.Utils.GetAsStringArray(3), new SlopeData {Down = 1, Right = 3});
        }

        public static int Execute2()
        {
            return Calculate2(Inputs.Utils.GetAsStringArray(3), new List<SlopeData>
            {
                new SlopeData {Down = 1, Right = 1},
                new SlopeData {Down = 1, Right = 3},
                new SlopeData {Down = 1, Right = 5},
                new SlopeData {Down = 1, Right = 7},
                new SlopeData {Down = 2, Right = 1}
            });
        }
    }
}