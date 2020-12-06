using System;
using System.Linq;
using Inputs;

namespace DayChallenge
{
    public static class Day6
    {
        public static int Calculate1(string[] data)
        {
            return data.SplitOn(string.IsNullOrWhiteSpace)
                .Sum(g => g.SelectMany(g => g).Distinct().Count());
        }

        public static int Calculate2(string[] data)
        {
            return data.SplitOn(string.IsNullOrWhiteSpace)
                .Select(l => l.ToList())
                .Sum(group => group[0].Count(c => group.All(s => s.Contains(c))));
        }

        public static int Execute1()
        {
            return Calculate1(Inputs.Utils.GetAsStringArray(6, false));
        }

        public static int Execute2()
        {
            return Calculate2(Inputs.Utils.GetAsStringArray(6, false));
        }
    }
}