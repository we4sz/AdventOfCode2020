using System;
using System.Linq;

namespace DayChallenge
{
    public static class Day5
    {
        public static int Calculate1(string data)
        {
            var seatIndex = data.Aggregate((0, 127, 0, 7), (seat, c) =>
                c switch
                {
                    'B' => (seat.Item1 + (seat.Item2 - seat.Item1 + 1) / 2, seat.Item2, seat.Item3, seat.Item4),
                    'F' => (seat.Item1, seat.Item1 + (seat.Item2 - seat.Item1 + 1) / 2 - 1, seat.Item3, seat.Item4),
                    'R' => (seat.Item1, seat.Item2, seat.Item3 + (seat.Item4 - seat.Item3 + 1) / 2, seat.Item4),
                    'L' => (seat.Item1, seat.Item2, seat.Item3, seat.Item3 + (seat.Item4 - seat.Item3 + 1) / 2 - 1),
                    _ => seat
                }
            );

            return seatIndex.Item1 * 8 + seatIndex.Item3;
        }

        public static int Execute1()
        {
            return Inputs.Utils.GetAsStringArray(5).Max(Calculate1);
        }

        public static int Execute2()
        {
            var seats = Inputs.Utils.GetAsStringArray(5).Select(Calculate1).OrderBy(x => x).ToList();
            return Enumerable.Range(seats.Min(), seats.Max()).Except(seats).FirstOrDefault();
        }
    }
}