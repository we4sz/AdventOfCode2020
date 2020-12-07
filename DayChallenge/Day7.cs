using System;
using System.Collections.Generic;
using System.Linq;
using Inputs;

namespace DayChallenge
{
    public static class Day7
    {
        private static (string, Dictionary<string, int>) ParseBag(string s)
        {
            var bags =
                s.Split(new string[] {" contain ", ", ", "."}, StringSplitOptions.RemoveEmptyEntries);

            return (
                bags[0].Substring(0, bags[0].Length - 4).Trim(),
                bags.Skip(1).Where(x => char.IsDigit(x[0]))
                    .ToDictionary(x => x.Substring(x.IndexOf(" ") + 1, x.IndexOf("bag") - x.IndexOf(" ") - 2),
                        x => int.Parse(x.Substring(0, x.IndexOf(" "))))
            );
        }

        private static int Calc1Helper(Dictionary<string, Dictionary<string, int>> rules,
            string bag, HashSet<string> checkedBags = null)
        {
            if ((checkedBags ??= new HashSet<string>()).Contains(bag))
            {
                return 0;
            }

            checkedBags.Add(bag);
            return rules
                .Where(x => x.Value.ContainsKey(bag))
                .Aggregate(1, (sum, current) => sum + Calc1Helper(rules, current.Key, checkedBags));
        }

        public static int Calculate1(string[] data, string bag)
        {
            return Calc1Helper(data.Select(ParseBag)
                .ToDictionary(x => x.Item1, x => x.Item2), bag) - 1;
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