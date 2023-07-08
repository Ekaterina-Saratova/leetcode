using NUnit.Framework;

namespace Task349
{
    /// <summary>
    /// Given two integer arrays nums1 and nums2, return an array of their intersection.
    /// Each element in the result must be unique and you may return the result in any order.
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            var task349 = new Solution();
            var nums = new[] { 1, 2, 3, 0, 0, 0 };
            CollectionAssert.AreEqual(new[] { 2 }, task349.Intersection(new []{1,2,2,1}, new []{2,2}));
            CollectionAssert.AreEqual(new[] { 9,4 }, task349.Intersection(new []{4,9,5}, new []{9,4,9,8,4}));
            Console.ReadKey();
        }
    }

    public class Solution
    {
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            var uniqueNums1 = new HashSet<int>();
            var result = new HashSet<int>();
            foreach (var n in nums1)
            {
                uniqueNums1.Add(n);
            }
            foreach (var n in nums2)
            {
                if (uniqueNums1.Contains(n))
                    result.Add(n);
            }
            return result.ToArray();
        }
    }
}