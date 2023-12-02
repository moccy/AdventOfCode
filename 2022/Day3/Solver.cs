using System;
using System.Collections.Generic;
using System.Linq;

namespace Day3
{
    public class Solver
    {
        public int SolvePart1(string[] lines)
        {
            string commonItems = string.Concat(lines.Select(x => FindCommonItemInCompartments(x)));
            return commonItems.Sum(x => GetCharValue(x));
        }

        public int SolvePart2(string[] lines)
        {
            var bagCollections = lines.Chunk(3);
            var badges = bagCollections.Select(x => FindCommonItemInBagCollection(x));
            return badges.Sum(x => GetCharValue(x));
        }

        private static char FindCommonItemInBagCollection(IList<string> bagCollection)
        {
            return bagCollection[0]
                .Intersect(bagCollection[1])
                .Intersect(bagCollection[2])
                .First();
        }

        private static char FindCommonItemInCompartments(string bag)
        {
            if (bag.Length == 0) throw new ArgumentException("Bag is empty.");
            var c1 = bag[..(bag.Length / 2)].ToCharArray();
            var c2 = bag[(bag.Length / 2)..].ToCharArray();
            if (c1.Length != c2.Length) throw new ArgumentException("Compartments are different sizes in bag.");
            var common = c1.Intersect(c2);
            if (common.Count() != 1) throw new ArgumentException("More than 1 common item found in both compartments.");
            return common.First();
        }

        private static int GetCharValue(char c)
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