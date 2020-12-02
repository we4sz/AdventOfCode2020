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
        private static PasswordData ParseRule(string s)
        {
            var reg = new Regex("^([0-9]+)-([0-9]+) ([a-z]): (.*)$");
            var match = reg.Match(s);

            return new PasswordData
            {
                Char = match.Groups[3].Value[0],
                Max = int.Parse(match.Groups[2].Value),
                Min = int.Parse(match.Groups[1].Value),
                Password = match.Groups[4].Value
            };
        }

        public static int Calculate1(string[] data)
        {
            var a = data.Select(ParseRule)
                .Count(p => p.Password.Count(c => c == p.Char).IsWithin(p.Min, p.Max));

            return a;
        }

        public static int Calculate2(string[] data)
        {
            var a = data.Select(ParseRule)
                .Count(p => p.Password[p.Min - 1] == p.Char ^ p.Password[p.Max - 1] == p.Char);

            return a;
        }


        public static int Execute1()
        {
            var input = Inputs.Utils.GetAsStringArray(2);
            return Calculate1(input);
        }


        public static int Execute2()
        {
            var input = Inputs.Utils.GetAsStringArray(2);
            return Calculate2(input);
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