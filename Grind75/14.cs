using NUnit.Framework;

namespace Grind75
{
    public class Solution14
    {
        // Non optimal
        public string LongestCommonPrefix(string[] strs)
        {
            var result = strs[0];
            var newResult = "";

            foreach (var s in strs)
            {
                for (var i = 0; i < result.Length && i < s.Length; i++)
                {
                    if (s[i] == result[i])
                        newResult += s[i];
                    else
                        break;
                }
                result = newResult;
                newResult = "";
            }

            return result;
        }

        // HashMap
        public int[] TwoSumHash(int[] nums, int target)
        {
            var diffDict = new Dictionary<int, int>();

            for (var i = 0; i < nums.Length; i++)
            {
                if (diffDict.ContainsKey(nums[i]))
                    return new[] { i, diffDict[nums[i]] };
                var diff = target - nums[i];
                if (diff >= 0)
                {
                    diffDict.Add(diff, i);
                }
            }

            return new int[2];
        }
    }

    [TestFixture]
    public class Tests14
    {
        [TestCase(new [] { "flower", "flow", "flight" }, "fl")]
        [TestCase(new [] { "a" }, "a")]
        public void Test1(string [] strs, string expected)
        {
            var actual = new Solution14().LongestCommonPrefix(strs);
            Assert.AreEqual(expected, actual);
        }
    }
}

