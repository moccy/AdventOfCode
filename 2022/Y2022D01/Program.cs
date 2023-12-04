using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;

namespace Y2022D01;

internal class Program
{
    static void Main(string[] args)
    {
        var lines = File.ReadAllLines("input.txt");
        var calories = new List<int>();

        int count = 0;

        foreach (var line in lines)
        {
            if (line == string.Empty)
            {
                calories.Add(count);
                count = 0;
                continue;
            }
            count += int.Parse(line);
        }

        Console.WriteLine(calories.Max());
        Console.WriteLine(calories.OrderBy(x => x).TakeLast(3).Sum());
    }
}