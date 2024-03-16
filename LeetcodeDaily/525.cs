using NUnit.Framework;

namespace LeetCodeDaily
{
    public class Solution525
    {
        public int FindMaxLength(int[] nums)
        {
            var sumArr = new int[nums.Length];
            var sumDict = new Dictionary<int, int>();
            var max = 0;
            sumArr[0] = nums[0] == 0 ? -1 : 1;
            sumDict.Add(sumArr[0], 0);

            for (var i = 1; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                    sumArr[i] = sumArr[i - 1] - 1;
                else
                    sumArr[i] = sumArr[i - 1] + 1;

                if (!sumDict.TryAdd(sumArr[i], i))
                {
                    max = Math.Max(max, i - sumDict[sumArr[i]]);
                }

                if (sumArr[i] == 0)
                    max = i + 1;
            }
            return max;
        }
    }

    [TestFixture]
    public class Tests525
    {
        [Test]
        [TestCase(new int[]{ 1, 0, 1, 0 }, 4)]
        [TestCase(new int[]{ 0, 1, 0 }, 2)]
        [TestCase(new int[]{ 0, 1, 1 }, 2)]
        public void Test(int[] n, int expected)
        {
            var result = new Solution525().FindMaxLength(n);
            Assert.AreEqual(expected, result);
        }
    }
}