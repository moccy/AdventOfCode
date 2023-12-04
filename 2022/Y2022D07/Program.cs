using System;
using System.Collections.Generic;
using System.Linq;

namespace Y2022D07;

public class Program
{
    static void Main(string[] args)
    {
        var lines = System.IO.File.ReadLines("input.txt");
        Console.WriteLine(Part1(lines));
        Console.WriteLine(Part2(lines));
    }

    public static long Part1(IEnumerable<string> lines)
    {
        var fileSystem = new FileSystem();
        fileSystem.Process(lines);
        return fileSystem.Directories.Where(d => d.Size <= 100000).Sum(d => d.Size);
    }

    public static long Part2(IEnumerable<string> lines)
    {
        const long totalDiskSpace = 70000000;
        const long updateSize = 30000000;

        var fileSystem = new FileSystem();
        fileSystem.Process(lines);

        var remainingDiskSpace = totalDiskSpace - fileSystem.RootDirectory.Size;
        var neededSpace = updateSize - remainingDiskSpace;
        return fileSystem.Directories.Where(d => d.Size > neededSpace).OrderBy(x => x.Size).First().Size;
    }
}