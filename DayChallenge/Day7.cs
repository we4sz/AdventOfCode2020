using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Inputs;

namespace DayChallenge
{
    public static class Day7
    {
        private static Regex bagRegex = new Regex("([0-9]+) ([a-z]+ [a-z]+)");

        private static (string, Dictionary<string, int>) ParseBag(string s)
        {
            var bags = s.Split(" bags contain ", StringSplitOptions.RemoveEmptyEntries);
            var matches = bagRegex.Matches(bags[1]);

            return (
                bags[0],
                matches.ToDictionary(x => x.Groups[2].Value, x => int.Parse(x.Groups[1].Value))
            );
        }

        private static IEnumerable<string> Calc1Helper(Dictionary<string, Dictionary<string, int>> rules, string bag)
        {
            return new List<string> {bag}
                .Union(rules
                    .Where(x => x.Value.ContainsKey(bag))
                    .SelectMany(x => Calc1Helper(rules, x.Key)))
                .Distinct();
        }

        public static int Calculate1(string[] data, string bag)
        {
            return Calc1Helper(data.Select(ParseBag)
                .ToDictionary(x => x.Item1, x => x.Item2), bag).Count() - 1;
        }

        private static int Calc2Helper(Dictionary<string, Dictionary<string, int>> rules, string bag)
        {
            return rules[bag]
                .Aggregate(1, (sum, current) => sum + current.Value * Calc2Helper(rules, current.Key));
        }

        public static int Calculate2(string[] data, string bag)
        {
            return Calc2Helper(data.Select(ParseBag)
                .ToDictionary(x => x.Item1, x => x.Item2), bag) - 1;
        }

        public static int Execute1()
        {
            return Calculate1(Inputs.Utils.GetAsStringArray(7), "shiny gold");
        }

        public static int Execute2()
        {
            return Calculate2(Inputs.Utils.GetAsStringArray(7), "shiny gold");
        }
    }
}