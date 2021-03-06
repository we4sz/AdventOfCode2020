using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Inputs
{
    public class Utils
    {
        public static int[] GetAsIntArray(int day)
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,
                $"day{day}.txt");

            return File.ReadAllLines(path).Where(x => !string.IsNullOrWhiteSpace(x)).Select(int.Parse).ToArray();
        }

        public static string[] GetAsStringArray(int day, bool removeEmpty = true)
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,
                $"day{day}.txt");

            var rows = File.ReadAllLines(path);

            if (removeEmpty)
            {
                return rows.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            }

            return rows.ToArray();
        }
    }

    public static class Extensions
    {
        public static bool IsWithin(this int value, int min, int max)
        {
            return value >= min && value <= max;
        }

        public static IEnumerable<T> WhereIndexIsModulo<T>(this IEnumerable<T> data, int checkValue)
        {
            return data
                .Select((currentRow, rowIndex) => new {Index = rowIndex, Data = currentRow})
                .Where(x => x.Index % checkValue == 0)
                .Select(x => x.Data);
        }

        public static IEnumerable<IEnumerable<T>> SplitOn<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            return source.Aggregate(new List<List<T>> {new List<T>()},
                (list, value) =>
                {
                    if (predicate(value))
                    {
                        list.Add(new List<T>());
                    }
                    else
                    {
                        list.Last().Add(value);
                    }

                    return list;
                });
        }

        public static List<T> ReplaceAtIndex<T>(this List<T> source, int index, T item)
        {
            var a = source
                .Select((listItem, listIndex) => new {item = listItem, index = listIndex})
                .Where(x => x.index != index).Select(x => x.item)
                .ToList();
            
            a.Insert(index, item);
            return a;
        }
    }
}