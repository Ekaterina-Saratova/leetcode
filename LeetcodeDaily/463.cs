using NUnit.Framework;

namespace LeetCodeDaily
{
    public class Solution463
    {
        public int IslandPerimeter(int[][] grid)
        {
            var result = 0;
            for (var i = 0; i < grid.Length; i++)
            {
                for (var j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 0)
                        continue;

                    if (j == 0)
                        result++;
                    else if (j != 0 && grid[i][j-1] == 0)
                        result++;
                    if (j == grid[i].Length -1)
                        result++;
                    else if (j != grid[i].Length - 1 && grid[i][j + 1] == 0)
                        result++;

                    if (i == 0)
                        result++;
                    else if (i != 0 && grid[i - 1][j] == 0)
                        result++;
                    if (i != grid.Length - 1 && grid[i + 1][j] == 0)
                        result++;
                    else if (i == grid.Length - 1)
                        result++;
                }
            }

            return result;
        }
    }

    [TestFixture]
    public class Tests463
    {
        [Test]
        public void Test()
        {
            var n = new int[][] { new[] { 0, 1, 0, 0 }, new[] { 0, 1, 0, 0 }, new[] { 0, 1, 0, 0 }, new[] { 1, 1, 0, 0 } };
            var result = new Solution463().IslandPerimeter(n);
            Assert.AreEqual(12, result);
        }
    }
}