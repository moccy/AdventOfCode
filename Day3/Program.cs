using System;
using System.IO;
using System.Linq;

namespace Day3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");
            string commonItems = "";
            foreach(var line in lines)
            {
                if (line.Length == 0) continue;
                var c1 = line.Substring(0, line.Length / 2).ToCharArray();
                var c2 = line.Substring(line.Length / 2).ToCharArray();
                if (c1.Length != c2.Length) throw new InvalidOperationException();
                var common = c1.Intersect(c2);
                if (common.Count() != 1) throw new InvalidOperationException();
                commonItems += common.First();
            }

            Console.WriteLine(commonItems.Sum(x => GetCharValue(x)));
        }

        static int GetCharValue(char c)
        {
            if (!char.IsAscii(c) || !char.IsLetter(c)) 
                throw new ArgumentException("Invalid character.");

            var chars = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            var caseAgnosticValue = Array.IndexOf(chars, char.ToLower(c)) + 1;

            return char.IsUpper(c) ?
                caseAgnosticValue + chars.Length :
                caseAgnosticValue;
        }
    }
}