using System;
using System.Linq;

namespace Day7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const long totalDiskSpace = 70000000;
            const long updateSize = 30000000;
            var lines = System.IO.File.ReadLines("input.txt");
            var fileSystem = new FileSystem();
            fileSystem.Process(lines);

            Console.WriteLine(fileSystem.Directories.Where(d => d.Size <= 100000).Sum(d => d.Size));

            var remainingDiskSpace = totalDiskSpace - fileSystem.RootDirectory.Size;
            var neededSpace = updateSize - remainingDiskSpace;
            Console.WriteLine(fileSystem.Directories.Where(d => d.Size > neededSpace).OrderBy(x => x.Size).First().Size);
        }
    }
}