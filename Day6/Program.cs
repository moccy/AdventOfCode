using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dataStream = File.ReadAllText("input.txt");
            Console.WriteLine($"Part 1: {GetStartOfPacketMarker(dataStream)}");
            Console.WriteLine($"Part 2: {GetStartOfMessageMarker(dataStream)}");
        }

        public static int GetStartOfPacketMarker(string dataStream)
        {
            var queue = new Queue<char>();

            for (var i = 0; i < dataStream.Length; i++)
            {
                if (queue.Distinct().Count() == 4)
                {
                    return i;
                }
                queue.Enqueue(dataStream[i]);
                if (queue.Count() > 4)
                {
                    queue.Dequeue();
                }
            }

            return 0;
        }

        public static int GetStartOfMessageMarker(string dataStream)
        {
            var queue = new Queue<char>();

            for (var i = 0; i < dataStream.Length; i++)
            {
                if (queue.Distinct().Count() == 14)
                {
                    return i;
                }
                queue.Enqueue(dataStream[i]);
                if (queue.Count() > 14)
                {
                    queue.Dequeue();
                }
            }

            return 0;
        }
    }
}