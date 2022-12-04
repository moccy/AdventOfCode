using System;
using System.IO;
using System.Linq;

namespace Day4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadLines("input.txt");
            var pairs = lines.Select(x => x.Split(","));
            var fullOverlapCounter = 0;
            var partialOverlapCounter = 0;

            foreach (var pair in pairs)
            {
                var firstRange = pair[0].Split("-").Select(x => int.Parse(x)).ToArray();
                var secondRange = pair[1].Split("-").Select(x => int.Parse(x)).ToArray();

                if (DoRangesFullyOverlap(firstRange, secondRange)) fullOverlapCounter++;
                if (DoRangesPartiallyOverlap(firstRange, secondRange)) partialOverlapCounter++;
            }

            Console.WriteLine(fullOverlapCounter);
            Console.WriteLine(partialOverlapCounter);
        }

        static bool DoRangesPartiallyOverlap(int[] firstRange, int[] secondRange) =>
            firstRange[0] <= secondRange[1] && secondRange[0] <= firstRange[1];

        static bool DoRangesFullyOverlap(int[] firstRange, int[] secondRange) =>
            firstRange[0] <= secondRange[0] && firstRange[1] >= secondRange[1] ||
            secondRange[0] <= firstRange[0] && secondRange[1] >= firstRange[1];
    }
}