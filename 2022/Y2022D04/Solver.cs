using System;
using System.Collections.Generic;
using System.Linq;

namespace Y2022D04;

public class Solver
{
    public static int SolvePart1(IEnumerable<string> lines)
    {
        var pairs = lines.Select(x => x.Split(","));
        var counter = 0;
        foreach (var pair in pairs)
        {
            var ranges = pair.Select(GetRange);
            if (DoRangesFullyOverlap(ranges.First(), ranges.Last())) counter++;
        }
        return counter;
    }

    public static int SolvePart2(IEnumerable<string> lines)
    {
        var pairs = lines.Select(x => x.Split(","));
        var counter = 0;
        foreach (var pair in pairs)
        {
            var ranges = pair.Select(GetRange);
            if (DoRangesPartiallyOverlap(ranges.First(), ranges.Last())) counter++;
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
        var split = range.Split("-").Select(int.Parse);
        return new Range(split.First(), split.Last());
    }
}