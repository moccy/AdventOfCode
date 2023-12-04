using System;
using System.IO;
using System.Linq;

namespace Y2022D02;

internal class Program
{
    static void Main(string[] args)
    {
        var lines = File.ReadAllLines("input.txt");
        var games = lines.Select(x => new Game(x));
        var combinedScore = games.Sum(x => x.GetPlayerScore());
        Console.WriteLine(combinedScore);
    }
}