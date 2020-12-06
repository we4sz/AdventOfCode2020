using System.Linq;
using System.Text.RegularExpressions;
using Inputs;

namespace DayChallenge
{
    public static class Day2
    {
        private static (int, int, char, string) ParsePasswordData(string s)
        {
            var reg = new Regex("^([0-9]+)-([0-9]+) ([a-z]): (.*)$");
            var match = reg.Match(s);

            return (
                int.Parse(match.Groups[1].Value),
                int.Parse(match.Groups[2].Value),
                match.Groups[3].Value[0],
                match.Groups[4].Value
            );
        }

        public static int Calculate1(string[] data)
        {
            return data.Select(ParsePasswordData)
                .Count(p => p.Item4.Count(c => c == p.Item3).IsWithin(p.Item1, p.Item2));
        }

        public static int Calculate2(string[] data)
        {
            return data.Select(ParsePasswordData)
                .Count(p => p.Item4[p.Item1 - 1] == p.Item3 ^ p.Item4[p.Item2 - 1] == p.Item3);
        }

        public static int Execute1()
        {
            return Calculate1(Inputs.Utils.GetAsStringArray(2));
        }

        public static int Execute2()
        {
            return Calculate2(Inputs.Utils.GetAsStringArray(2));
        }
    }
}