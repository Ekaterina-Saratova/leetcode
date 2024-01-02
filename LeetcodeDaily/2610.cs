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

        public IList<IList<int>> FindMatrixFrequencyCounter(int[] nums)
        {
            var frequency = new int[nums.Length + 1];
            var result = new List<IList<int>>();

            foreach (var n in nums)
            {
                if (frequency[n] >= result.Count)
                {
                    result.Add(new List<int>());
                }
                result[frequency[n]].Add(n);
                frequency[n]++;
            }

            return result;
        }
    }

    [TestFixture]
    public class Tests2610
    {
        private readonly List<IList<int>> expected = new()
        {
            new List<int>() { 1, 3, 4, 2 },
            new List<int>() { 1, 3 },
            new List<int>(){ 1}
        };

        [TestCase(new int[] { 1, 3, 4, 1, 2, 3, 1 })]
        public void TestMatrixIteration(int[] nums)
        {
            var result = new Solution2610().FindMatrixIteration(nums);
            Assert.AreEqual(result, expected);
        }

        [TestCase(new int[] { 1, 3, 4, 1, 2, 3, 1 })]
        public void TestMatrixFrequencyCounter(int[] nums)
        {
            var result = new Solution2610().FindMatrixFrequencyCounter(nums);
            Assert.AreEqual(result, expected);
        }
    }
}