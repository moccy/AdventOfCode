namespace Day8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var trees = File.ReadLines("input.txt")
                            .Select(x => x.Select(y => (int)char.GetNumericValue(y)).ToArray()).ToArray();
            
            Console.WriteLine($"Part 1: {Part1(trees)}");
            Console.WriteLine($"Part 2: {Part2(trees)}");
        }

        static int Part1(int[][] trees) => GetVisibleInteriorTrees(trees) + GetExteriorTreeCount(trees);
        static int Part2(int[][] trees) => GetTreeSceneryScores(trees).SelectMany(x => x).Max();
        
        private static int GetExteriorTreeCount(int[][] trees)
        {
            return 2 * trees.Length + (2 * (trees[0].Length - 2));
        }

        private static int GetVisibleInteriorTrees(int[][] trees)
        {
            var count = 0;

            for (var verticalIndex = 1; verticalIndex < trees.Length - 1; verticalIndex++)
            {
                for (var horizontalIndex = 1; horizontalIndex < trees[0].Length - 1; horizontalIndex++)
                {
                    var treeHeight = trees[verticalIndex][horizontalIndex];

                    var (leftTrees, rightTrees) = GetHorizontalTrees(trees, horizontalIndex, verticalIndex);
                    var (aboveTrees, belowTrees) = GetVerticalTrees(trees, horizontalIndex, verticalIndex);

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

        private static int[][] GetTreeSceneryScores(int[][] trees)
        {
            var output = new int[trees.Length][];
            for(var y = 0; y < trees.Length; y++)
            {
                output[y] = new int[trees[y].Length];
                for(var x = 0; x < trees[0].Length; x++)
                {
                    var sceneryScore = GetSceneryScore(trees, x, y);
                    output[y][x] = sceneryScore;
                }
            }

            return output;
        }

        private static int GetSceneryScore(int[][] trees, int x, int y)
        {
            var (leftTrees, rightTrees) = GetHorizontalTrees(trees, x, y);
            var (aboveTrees, belowTrees) = GetVerticalTrees(trees, x, y);

            var count = 1;
            var currentTree = trees[y][x];
            if (leftTrees.Length == 0 || rightTrees.Length == 0 || aboveTrees.Length == 0 || belowTrees.Length == 0)
            {
                return 0;
            }
            count *= GetViewScore(currentTree, aboveTrees.Reverse().ToArray());
            count *= GetViewScore(currentTree, leftTrees.Reverse().ToArray());
            count *= GetViewScore(currentTree, belowTrees);
            count *= GetViewScore(currentTree, rightTrees);
            return count;
        }

        private static int GetViewScore(int tree, int[] treeList)
        {
            var viewScore = 0;
            foreach (var curr in treeList)
            {
                if (curr < tree)
                {
                    viewScore++;
                }
                else
                {
                    viewScore++; break;
                }
            }

            return viewScore == 0 ? 1 : viewScore;
        }

        private static (int[] leftTrees, int[] rightTrees) GetHorizontalTrees(int[][] trees, int x, int y)
            => (trees[y][0..x], trees[y][(x + 1)..trees[y].Length]);

        private static (int[] aboveTrees, int[] belowTrees) GetVerticalTrees(int[][] trees, int x, int y)
            => (trees[0..y].Select(tl => tl[x]).ToArray(), trees[(y + 1)..trees.Length].Select(tl => tl[x]).ToArray());
    }
}