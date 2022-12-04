using System;
using System.Collections.Generic;
using System.Linq;

namespace Day4
{
    public class Solver
    {
        public int SolvePart1(IEnumerable<string> lines)
        {
            var pairs = lines.Select(x => x.Split(","));
            var counter = 0;
            foreach (var pair in pairs)
            {
                var ranges = pair.Select(GetRange).ToArray();
                if (DoRangesFullyOverlap(ranges[0], ranges[1])) counter++;
            }
            return counter;
        }

        public int SolvePart2(IEnumerable<string> lines)
        {
            var pairs = lines.Select(x => x.Split(","));
            var counter = 0;
            foreach (var pair in pairs)
            {
                var ranges = pair.Select(GetRange).ToArray();
                if (DoRangesPartiallyOverlap(ranges[0], ranges[1])) counter++;
            }
            return counter;
        }

        static bool DoRangesPartiallyOverlap(Range firstRange, Range secondRange) =>
            firstRange.Start.Value <= secondRange.End.Value && secondRange.Start.Value <= firstRange.End.Value;

        static bool DoRangesFullyOverlap(Range firstRange, Range secondRange) =>
            firstRange.Start.Value <= secondRange.Start.Value && firstRange.End.Value >= secondRange.End.Value ||
            secondRange.Start.Value <= firstRange.Start.Value && secondRange.End.Value >= firstRange.End.Value;

        static Range GetRange(string range) 
        {
            var split = range.Split("-").Select(x => int.Parse(x)).ToArray();
            return new Range(split[0], split[1]);
        }
    }
}