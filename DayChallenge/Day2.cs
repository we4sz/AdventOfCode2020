using System.Linq;
using System.Text.RegularExpressions;
using Inputs;

namespace DayChallenge
{
    public static class Day2
    {
        private static PasswordData ParsePasswordData(string s)
        {
            var reg = new Regex("^([0-9]+)-([0-9]+) ([a-z]): (.*)$");
            var match = reg.Match(s);

            return new PasswordData
            {
                Min = int.Parse(match.Groups[1].Value),
                Max = int.Parse(match.Groups[2].Value),
                Char = match.Groups[3].Value[0],
                Password = match.Groups[4].Value
            };
        }

        public static int Calculate1(string[] data)
        {
            return data.Select(ParsePasswordData)
                .Count(p => Enumerable.Count<char>(p.Password, c => c == p.Char).IsWithin(p.Min, p.Max));
        }

        public static int Calculate2(string[] data)
        {
            return data.Select(ParsePasswordData)
                .Count(p => p.Password[p.Min - 1] == p.Char ^ p.Password[p.Max - 1] == p.Char);
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

    public class PasswordData
    {
        public int Min { get; set; }

        public int Max { get; set; }

        public char Char { get; set; }

        public string Password { get; set; }
    }
}