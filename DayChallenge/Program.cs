using System;

namespace DayChallenge
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var answer1 = Day7.Execute1();
            Console.WriteLine($"Answer1: {answer1}");

            var answer2 = Day7.Execute2();
            Console.WriteLine($"Answer2: {answer2}");
        }
    }
}