using NUnit.Framework;

namespace LeetCodeDaily
{
    public class Solution2610
    {
        // Iteration solution
        public IList<IList<int>> FindMatrixIteration(int[] nums)
        {
            var result1 = new List<HashSet<int>>();

            foreach (var n in nums)
            {
                var newList = true;
                foreach (var r in result1)
                {
                    if (r.Contains(n)) continue;
                    r.Add(n);
                    newList = false;
                    break;
                }

                if (newList)
                {
                    result1.Add(new HashSet<int>(){n});
                }
            }

            var result = new List<IList<int>>();
            foreach (var r1 in result1)
            {
                result.Add(r1.ToList());
            }

            return result;
        }
    }

    [TestFixture]
    public class Tests2610
    {
        [TestCase(new int[] { 1, 3, 4, 1, 2, 3, 1 })]
        public void TestMatrix(int[] nums)
        {
            var result = new Solution2610().FindMatrixIteration(nums);
            var expected = new List<IList<int>>
            {
                new List<int>() { 1, 3, 4, 2 },
                new List<int>() { 1, 3 },
                new List<int>(){ 1}
            };
            Assert.AreEqual(result, expected);
        }
    }
}