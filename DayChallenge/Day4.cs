using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Inputs;

namespace DayChallenge
{
    public static class Day4
    {
        private static readonly HashSet<string> eyeColor = new HashSet<string> {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"};
        private static readonly Regex hclRegex = new Regex("[0-9a-f]{6}");
        private static readonly Regex passportDataRegex = new Regex("([a-z]{3}):([a-z0-9A-Z#]+)");
        
        private static Dictionary<Regex, Func<string, bool>> hgtValidation =
            new Dictionary<Regex, Func<string, bool>>
            {
                {new Regex("^([0-9]+)cm$"), s => int.Parse(s).IsWithin(150, 193)},
                {new Regex("^([0-9]+)in$"), s => int.Parse(s).IsWithin(59, 76)}
            };

        private static readonly Dictionary<string, Func<string, bool>> fieldValidation =
            new Dictionary<string, Func<string, bool>>
            {
                {"byr", (s) => s.Length == 4 && s.All(char.IsDigit) && int.Parse(s).IsWithin(1920, 2002)},
                {"iyr", (s) => s.Length == 4 && s.All(char.IsDigit) && int.Parse(s).IsWithin(2010, 2020)},
                {"eyr", (s) => s.Length == 4 && s.All(char.IsDigit) && int.Parse(s).IsWithin(2020, 2030)},
                {"hgt", (s) => hgtValidation.Any(v => v.Key.IsMatch(s) && v.Value(v.Key.Match(s).Groups[1].Value))},
                {"hcl", (s) => s.Length == 7 && s[0] == '#' && hclRegex.IsMatch(s.Substring(1))},
                {"ecl", (s) => eyeColor.Contains(s)},
                {"pid", (s) => s.Length == 9 && s.All(char.IsDigit)}
            };

        private static Dictionary<string, string> ParseData(string data)
        {
            return passportDataRegex.Matches(data).ToDictionary(x => x.Groups[1].Value, x => x.Groups[2].Value);
        }

        private static IEnumerable<Dictionary<string, string>> ParsePassportData(string[] data)
        {
            return data.SplitOn(string.IsNullOrWhiteSpace)
                .Select(x => ParseData(string.Join(" ", x)));
        }

        public static int Calculate1(string[] data)
        {
            return ParsePassportData(data).Count(p => fieldValidation
                .All(fv => p.ContainsKey(fv.Key)));
        }

        public static int Calculate2(string[] data)
        {
            return ParsePassportData(data).Count(p => fieldValidation
                .All(fv => p.ContainsKey(fv.Key) && fv.Value(p[fv.Key])));
        }

        public static int Execute1()
        {
            return Calculate1(Inputs.Utils.GetAsStringArray(4, false));
        }

        public static int Execute2()
        {
            return Calculate2(Inputs.Utils.GetAsStringArray(4, false));
        }
    }
}