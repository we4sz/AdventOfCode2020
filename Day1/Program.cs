using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Day1
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var answer1 = Day1.Execute1();
            Console.WriteLine($"Answer1: {answer1}");

            var answer2 = Day1.Execute2();
            Console.WriteLine($"Answer2: {answer2}");
        }
    }

    public static class Day1
    {
        public static int Calculate1(int[] data)
        {
            var pair = data
                .SelectMany(a => data.Select(b => new[] {a, b}))
                .FirstOrDefault(x => x[0] + x[1] == 2020);

            if (pair != null)
            {
                return pair[0] * pair[1];
            }

            return -1;
        }

        public static int Calculate2(int[] data)
        {
            var pair = data
                .SelectMany(a => data.SelectMany(b => data.Select(c => new[] {a, b, c})))
                .FirstOrDefault(x => x[0] + x[1] + x[2] == 2020);

            if (pair != null)
            {
                return pair[0] * pair[1] * pair[2];
            }

            return -1;
        }

        public static int Execute1()
        {
            var input = Inputs.Utils.GetAsIntArray(1, 1);
            return Calculate1(input);
        }

        public static int Execute2()
        {
            var input = Inputs.Utils.GetAsIntArray(1, 1);
            return Calculate2(input);
        }
    }
}