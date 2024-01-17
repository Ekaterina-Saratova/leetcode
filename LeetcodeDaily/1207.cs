using NUnit.Framework;

namespace LeetCodeDaily
{
    public class Solution1207
    {
        public bool UniqueOccurrences(int[] arr)
        {
            var occurrences = new Dictionary<int, int>();
            foreach (var item in arr)
            {
                if (occurrences.ContainsKey(item))
                    occurrences[item]++;
                else
                    occurrences.Add(item, 1);
            }

            var unique = new HashSet<int>();
            foreach (var item in occurrences)
            {
                if (!unique.Add(item.Value))
                    return false;
            }

            return true;
        }
    }

    [TestFixture]
    public class Tests1207
    {
        [TestCase(new int[] { 1, 2, 2, 1, 1, 3 }, true)]
        [TestCase(new int[] { 1, 2 }, false)]
        [TestCase(new int[] { -3, 0, 1, -3, 1, 1, 1, -3, 10, 0 }, true)]
        public void Test(int[] arr, bool expected)
        {
            var result = new Solution1207().UniqueOccurrences(arr);
            Assert.AreEqual(expected, result);
        }
    }
}