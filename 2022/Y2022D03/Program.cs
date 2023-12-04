using System;
using System.IO;

namespace Y2022D03;

class Program
{
    static void Main(string[] args)
    {
        var lines = File.ReadAllLines("input.txt");
        var solver = new Solver();

        Console.WriteLine($"Part 1: {solver.SolvePart1(lines)}");
        Console.WriteLine($"Part 2: {solver.SolvePart2(lines)}");
    }
}