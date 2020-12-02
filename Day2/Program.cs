using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Inputs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Day2
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var answer1 = Day2.Execute1();
            Console.WriteLine($"Answer1: {answer1}");

            var answer2 = Day2.Execute2();
            Console.WriteLine($"Answer2: {answer2}");
        }
    }


    public static class Day2
    {
        private static PasswordData ParsePasswordData(string s)
        {
            var reg = new Regex("^([0-9]+)-([0-9]+) ([a-z]): (.*)$");
            var match = reg.Match(s);

            return new PasswordData
            {
                Char = match.Groups[3].Value[0],
                Min = int.Parse(match.Groups[1].Value),
                Max = int.Parse(match.Groups[2].Value),
                Password = match.Groups[4].Value
            };
        }

        public static int Calculate1(string[] data)
        {
            return data.Select(ParsePasswordData)
                .Count(p => p.Password.Count(c => c == p.Char).IsWithin(p.Min, p.Max));
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