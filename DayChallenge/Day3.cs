using System.Collections.Generic;
using System.Linq;
using Inputs;

namespace DayChallenge
{
    public static class Day3
    {
        public static int Calculate1(string[] data, (int, int) slopeData)
        {
            return data.WhereIndexIsModulo(slopeData.Item1)
                .Aggregate((0, 0), (traversingData, currentRow) =>
                    (
                        (traversingData.Item1 + slopeData.Item2) % currentRow.Length,
                        traversingData.Item2 + (currentRow[traversingData.Item1] == '#' ? 1 : 0))
                ).Item2;
        }

        public static int Calculate2(string[] data, List<(int, int)> slopesData)
        {
            return slopesData.Aggregate(1, (i, slopeData) =>
                i * Calculate1(data, slopeData));
        }

        public static int Execute1()
        {
            return Calculate1(Inputs.Utils.GetAsStringArray(3), (1, 3));
        }

        public static int Execute2()
        {
            return Calculate2(Inputs.Utils.GetAsStringArray(3), new List<(int, int)>
            {
                (1, 1),
                (1, 3),
                (1, 5),
                (1, 7),
                (2, 1)
            });
        }
    }
}