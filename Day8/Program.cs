namespace Day8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var trees = File.ReadLines("input.txt")
                            .Select(x => x.Select(y => (int)char.GetNumericValue(y)).ToList())
                            .ToList();
            var height = trees.Count();
            var width = trees.First().Count();
            var count = GetVisibleInteriorTrees(trees, height, width) + GetExteriorTreeCount(trees);
            Console.WriteLine(count);
        }

        private static int GetExteriorTreeCount(List<List<int>> trees)
        {
            return 2 * trees.Count() + (2 * (trees.First().Count() - 2));
        }

        private static int GetVisibleInteriorTrees(List<List<int>> trees, int height, int width)
        {
            var count = 0;
            for (var i = 1; i < height - 1; i++)
            {
                for (var j = 1; j < width - 1; j++)
                {
                    var treeHeight = trees[i][j];
                    var (leftTrees, rightTrees) = GetHorizontalTrees(trees, i, j);
                    var (aboveTrees, belowTrees) = GetVerticalTrees(trees, i, j);

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

        private static (IEnumerable<int> leftTrees, IEnumerable<int> rightTrees) GetHorizontalTrees(List<List<int>> trees, int horizontalIndex, int verticalIndex)
        {
            var leftTrees = new List<int>();
            var rightTrees = new List<int>();

            // Get left trees
            for (var i = 0; i < horizontalIndex; i++)
            {
                leftTrees.Add(trees[verticalIndex][i]);
            }

            // Get right trees
            for (var i = horizontalIndex + 1; i < trees[verticalIndex].Count(); i++)
            {
                rightTrees.Add(trees[verticalIndex][i]);
            }

            return (leftTrees, rightTrees);
        }

        private static (IEnumerable<int> aboveTrees, IEnumerable<int> belowTrees) GetVerticalTrees(List<List<int>> trees, int horizontalIndex, int verticalIndex)
        {
            var aboveTrees = new List<int>();
            var belowTrees = new List<int>();

            // Get above trees
            for (var i = 0; i < verticalIndex; i++)
            {
                aboveTrees.Add(trees[i][horizontalIndex]);
            }

            // Get below trees
            for (var i = verticalIndex + 1; i < trees.Count(); i++)
            {
                belowTrees.Add(trees[i][horizontalIndex]);
            }

            return (aboveTrees, belowTrees);
        }
    }
}