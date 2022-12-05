using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode2022;

namespace Day5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");
            var initialCrates = lines.TakeWhile(x => x != string.Empty).ToList();
            var instructions = lines.SkipWhile(x => x != string.Empty).Skip(1).ToList();
            var stackedCrates = Utils.Transpose(initialCrates.SkipLast(1).Reverse())
                                        .Where(x => !"[]".Contains(x.First()))
                                        .Select(x => new Stack<char>(x.Where(c => char.IsLetter(c))))
                                        .Where(x => x.Count > 0)
                                        .ToArray();

            foreach(var instruction in instructions)
            {
                var queue = new Queue<char>();
                var moveAmount = int.Parse(string.Join("", instruction[5..].TakeWhile(x => x != ' ')));
                var fromIndex = int.Parse(instruction.Substring(instruction.IndexOf("from ") + 5, 1));
                var toIndex = int.Parse(instruction.Substring(instruction.IndexOf("to ") + 3, 1));

                for(var i = 0; i < moveAmount; i++)
                {
                    queue.Enqueue(stackedCrates[fromIndex - 1].Pop());
                    stackedCrates[toIndex - 1].Push(queue.Dequeue());
                }
            }

            Console.WriteLine(string.Join("", stackedCrates.Select(sc => sc.Peek())));
        }
    }     
}