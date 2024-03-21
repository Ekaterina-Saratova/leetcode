using NUnit.Framework;
using System.Linq;

namespace LeetCodeDaily
{
    public class Solution57
    {
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            var n = intervals.Length;
            var i = 0;
            var res = new List<int[]>();

            // Case 1: No overlapping before merging intervals
            while (i < n && intervals[i][1] < newInterval[0])
            {
                res.Add(intervals[i]);
                i++;
            }

            // Case 2: Overlapping and merging intervals
            while (i < n && newInterval[1] >= intervals[i][0])
            {
                newInterval[0] = Math.Min(newInterval[0], intervals[i][0]);
                newInterval[1] = Math.Max(newInterval[1], intervals[i][1]);
                i++;
            }

            res.Add(newInterval);

            // Case 3: No overlapping after merging newInterval
            while (i < n)
            {
                res.Add(intervals[i]);
                i++;
            }

            // Convert List to array
            return res.ToArray();
        }
    }

    [TestFixture]
    public class Tests57
    {
        [Test]
        public void Test()
        {
            var nums = new int[][]
            {
                new int[] { 1, 2 },
                new int[] { 3, 5 },
                new int[] { 6, 7 },
                new int[] { 8, 10 },
                new int[] { 12, 16 },
            };
            var newInterval = new int[] { 4, 8 };
            var result = new Solution57().Insert(nums, newInterval);
            //Assert.AreEqual(expected, result);
        }

        [Test]
        public void Test2()
        {
            var nums = new int[][]
            {
                new int[] { 0, 5 },
                new int[] { 9, 12 },
            };
            var newInterval = new int[] { 7, 16 };
            var result = new Solution57().Insert(nums, newInterval);
        }
    }
}