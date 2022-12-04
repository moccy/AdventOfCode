using System;
using System.IO;

namespace Day4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadLines("input.txt");
            var solver = new Solver();
            
            Console.WriteLine($"Part 1: {solver.SolvePart1(lines)}");
            Console.WriteLine($"Part 2: {solver.SolvePart2(lines)}");
        }
    }
}