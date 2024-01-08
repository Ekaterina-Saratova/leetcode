using NUnit.Framework;

namespace LeetCodeDaily
{
    public class Solution446
    {
        public int NumberOfArithmeticSlices(int[] nums)
        {
            var result = 0;
            var diffCount = new Dictionary<long, List<List<int>>>();

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i+1; j < nums.Length; j++)
                {
                    var diff = (long)nums[j] - (long)nums[i];
                    if (diffCount.ContainsKey(diff))
                    {
                        var stacks = new List<List<int>>();
                        foreach (var d in diffCount[diff])
                        {
                            var peek = d.Last();
                            if (peek >= j)
                                continue;
                            if (nums[j] - nums[peek] == diff)
                            {
                                if (j != nums.Length-1)
                                {
                                    var t = d.ToArray();
                                    stacks.Add(t.ToList());
                                }
                                d.Add(j);

                                if (d.Count >= 3)
                                    result++;
                            }
                        }
                        var s = new List<int>();
                        s.Add(i);
                        s.Add(j);
                        stacks.Add(s);

                        if (stacks.Count > 0)
                            diffCount[diff].AddRange(stacks);
                    }
                    else
                    {
                        var nd = new List<List<int>>();
                        var s = new List<int>();
                        s.Add(i);
                        s.Add(j);
                        nd.Add(s);
                        diffCount.Add(diff, nd);
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
        [TestCase(new int[] { 0, 2000000000, -294967296 }, 0)]
        public void TestMatrixIteration(int[] nums, int expected)
        {
            var result = new Solution446().NumberOfArithmeticSlices(nums);
            Assert.AreEqual(expected, result);
        }
    }
}