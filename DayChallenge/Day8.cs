using System;
using System.Collections.Generic;
using System.Linq;
using Inputs;

namespace DayChallenge
{
    public static class Day8
    {
        public static int Calculate1(string[] data)
        {
            return data.Length;
        }

        public static int Calculate2(string[] data)
        {
            return data.Length;
        }

        public static int Execute1()
        {
            return Calculate1(Inputs.Utils.GetAsStringArray(8));
        }

        public static int Execute2()
        {
            return Calculate2(Inputs.Utils.GetAsStringArray(8));
        }
    }
}