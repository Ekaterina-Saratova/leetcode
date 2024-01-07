using NUnit.Framework;

namespace LeetCodeDaily
{
    public class Solution446
    {
        public int NumberOfArithmeticSlices(int[] nums)
        {
            var result = 0;
            var diffCount = new Dictionary<int, List<Stack<int>>>();

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i+1; j < nums.Length; j++)
                {
                    //if (i == j)
                    //    continue;
                    var diff = nums[j] - nums[i];
                    if (diffCount.ContainsKey(diff))
                    {
                        var stacks = new List<Stack<int>>();
                        foreach (var d in diffCount[diff])
                        {
                            var peek = d.Peek();
                            if (peek >= j)
                                continue;
                            if (nums[j] - nums[peek] == diff)
                                d.Push(j);
                            else
                            {
                                var s = new Stack<int>();
                                s.Push(i);
                                s.Push(j);
                                stacks.Add(s);
                            }
                        }
                        if (stacks.Count > 0)
                            diffCount[diff].AddRange(stacks);
                    }
                    else
                    {
                        var nd = new List<Stack<int>>();
                        var s = new Stack<int>();
                        s.Push(i);
                        s.Push(j);
                        nd.Add(s);
                        diffCount.Add(diff, nd);
                    }
                }
                
            }

            foreach (var diff in diffCount)
            {
                foreach (var d in diff.Value)
                {
                    if (d.Count <= 2)
                        continue;

                    if (diff.Key == 0)
                    {
                        for (var i = 3; i <= d.Count; i++)
                            result += CountCombinations(d.Count, i);
                    }
                    else
                    {
                        //var count = d.Count - 3 + 1;
                        //result += (int)(((double)count / 2) * (1 + count));
                        for (var i = 3; i <= d.Count; i++)
                            result += CountN(i, d.Count);
                    }
                }
            }

            return result;
        }

        public static int CountN(int n, int length)
        {
            var result = 0;
            for (int i = 0; i <= length - n; i++)
            {
                result++;
            }
            return result;
        }

        public static int CountCombinations(int n, int length)
        {
            int count = 0;
            for (int i = 0; i <= n - length; i++)
            {
                count += CountCombinationsRecursive(n, length - 1, i + 1);
            }
            return count;
        }

        private static int CountCombinationsRecursive(int n, int length, int start)
        {
            if (length == 0)
            {
                return 1;
            }

            int count = 0;
            for (int i = start; i <= n - length; i++)
            {
                count += CountCombinationsRecursive(n, length - 1, i + 1);
            }
            return count;
        }
    }

    [TestFixture]
    public class Tests446
    {
        [TestCase(new int[] { 2, 4, 6, 8, 10 }, 7)]
        [TestCase(new int[] { 7, 7, 7, 7, 7 }, 16)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 20)]
        public void TestMatrixIteration(int[] nums, int expected)
        {
            var result = new Solution446().NumberOfArithmeticSlices(nums);
            Assert.AreEqual(expected, result);
        }
    }
}