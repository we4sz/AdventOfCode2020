using System;
using System.Collections.Generic;
using System.Linq;
using Inputs;

namespace DayChallenge
{
    public static class Day8
    {
        private static (string, int) ParseInstruction(string s)
        {
            var values = s.Split(" ");
            return (values[0], int.Parse(values[1]));
        }

        private static int Calc1Helper(List<(string, int)> instructions, int index, IEnumerable<int> visitedIndices)
        {
            if (visitedIndices.Contains(index))
            {
                return 0;
            }

            return instructions[index].Item1 switch
            {
                "acc" => instructions[index].Item2 + Calc1Helper(instructions, index + 1, visitedIndices.Append(index)),
                "jmp" => Calc1Helper(instructions, index + instructions[index].Item2, visitedIndices.Append(index)),
                _ => Calc1Helper(instructions, index + 1, visitedIndices.Append(index)),
            };
        }

        public static int Calculate1(string[] data)
        {
            return Calc1Helper(data.Select(ParseInstruction).ToList(), 0, new int[] { });
        }


        private static int Calc2Helper(List<(string, int)> instructions, int index, IEnumerable<int> visitedIndices)
        {
            if (visitedIndices.Contains(index))
            {
                return -100000;
            }

            if (index >= instructions.Count)
            {
                return 0;
            }

            return instructions[index].Item1 switch
            {
                "acc" => instructions[index].Item2 + Calc2Helper(instructions, index + 1, visitedIndices.Append(index)),
                "jmp" => Calc2Helper(instructions, index + instructions[index].Item2, visitedIndices.Append(index)),
                _ => Calc2Helper(instructions, index + 1, visitedIndices.Append(index)),
            };
        }


        public static int Calculate2(string[] data)
        {
            var instructions = data.Select(ParseInstruction).ToList();

            var a = instructions.Select((x,i) => x.Item1 switch
            {
                "nop" => instructions.ReplaceAtIndex(i, ("jmp", x.Item2)),
                "jmp" => instructions.ReplaceAtIndex(i, ("nop", x.Item2)),
                "acc" => null
            }).Where(x=> x!= null).Append(instructions).ToList();


            return a.Max(x => Calc2Helper(x, 0, new int[] { }));
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