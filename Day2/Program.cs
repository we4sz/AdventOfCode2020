using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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

        }
    }

    public class PasswordCheck
    {
        public int Min { get; set; }

        public int Max { get; set; }

        public char Char { get; set; }

        public string Password { get; set; }
    }

    public static class Day2
    {

        private static PasswordCheck  ParseRule(string s)
        {
            var reg = new Regex("^([0-9]+)-([0-9]+) ([a-z]): (.*)$");
            var match = reg.Match(s);

            return new PasswordCheck
            {
                Char = match.Groups[3].Value[0], 
                Max = int.Parse(match.Groups[2].Value),
                Min = int.Parse(match.Groups[1].Value), 
                Password = match.Groups[4].Value
            };
        }
        
        public static int Calculate1(string[] data)
        {
           var a =   
                data.Select(ParseRule)
                    .Count(p =>
                    {
                        var count = p.Password.Count(c => c == p.Char);
                        return count >= p.Min && count <= p.Max;
                    });

           return a;
        }


        public static int Execute1()
        {
            var input = Inputs.Utils.GetAsStringArray(2, 1);
            return Calculate1(input);
        }

    }
}