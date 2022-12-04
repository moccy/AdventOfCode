using System;
using System.IO;

namespace Day4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadLines("input.txt");
            Console.WriteLine($"Part 1: {Solver.SolvePart1(lines)}");
            Console.WriteLine($"Part 2: {Solver.SolvePart2(lines)}");
        }
    }
}