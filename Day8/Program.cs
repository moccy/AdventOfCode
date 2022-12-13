namespace Day8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var trees = File.ReadLines("input.txt")
                            .Select(x => x.Select(y => (int)char.GetNumericValue(y)).ToArray()).ToArray();
            var height = trees.Length;
            var width = trees[0].Length;
            var count = GetVisibleInteriorTrees(trees, height, width) + GetExteriorTreeCount(trees);
            Console.WriteLine(count);
        }

        private static int GetExteriorTreeCount(int[][] trees)
        {
            return 2 * trees.Length + (2 * (trees[0].Length - 2));
        }

        private static int GetVisibleInteriorTrees(int[][] trees, int height, int width)
        {
            var count = 0;
            for (var verticalIndex = 1; verticalIndex < height - 1; verticalIndex++)
            {
                for (var horizontalIndex = 1; horizontalIndex < width - 1; horizontalIndex++)
                {
                    var treeHeight = trees[verticalIndex][horizontalIndex];

                    var leftTrees = trees[verticalIndex][0..horizontalIndex];
                    var rightTrees = trees[verticalIndex][(horizontalIndex + 1)..trees[verticalIndex].Length];
                    var aboveTrees = trees[0..verticalIndex].Select(x => x[horizontalIndex]);
                    var belowTrees = trees[(verticalIndex + 1)..trees.Length].Select(x => x[horizontalIndex]);

                    if (leftTrees.All(t => t < treeHeight) ||
                        rightTrees.All(t => t < treeHeight) ||
                        aboveTrees.All(t => t < treeHeight) ||
                        belowTrees.All(t => t < treeHeight))
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}