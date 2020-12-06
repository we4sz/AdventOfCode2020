using System;
using System.Linq;

namespace DayChallenge
{
    public class SeatIndex
    {
        public int MinRow { get; set; }

        public int MaxRow { get; set; }

        public int MinColumn { get; set; }

        public int MaxColumn { get; set; }
    }

    public static class Day5
    {
        public static int Calculate1(string data)
        {
            var seat = new SeatIndex {MaxRow = 127, MaxColumn = 7};
            foreach (var c in data)
            {
                _ = c switch
                {
                    'F' => seat.MaxRow = seat.MinRow + (seat.MaxRow - seat.MinRow + 1) / 2 - 1,
                    'B' => seat.MinRow = seat.MinRow + (seat.MaxRow - seat.MinRow + 1) / 2,
                    'L' => seat.MaxColumn = seat.MinColumn + (seat.MaxColumn - seat.MinColumn + 1) / 2 - 1,
                    'R' => seat.MinColumn = seat.MinColumn + (seat.MaxColumn - seat.MinColumn + 1) / 2,
                };
            }

            return seat.MinRow * 8 + seat.MinColumn;
        }

        public static int Execute1()
        {
            return Inputs.Utils.GetAsStringArray(5).Max(Calculate1);
        }

        public static int Execute2()
        {
            var seats = Inputs.Utils.GetAsStringArray(5).Select(Calculate1).OrderBy(x => x).ToList();
            for (int i = 0; i < seats.Count - 1; i++)
            {
                if (Math.Abs(seats[i] - seats[i + 1]) == 2)
                {
                    return Math.Min(seats[i], seats[i + 1]) + 1;
                }
            }

            return -1;
        }
    }
}