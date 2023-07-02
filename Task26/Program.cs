using System.Diagnostics;
using NUnit.Framework;

namespace Task26
{

    public class Program
    {
        static void Main(string[] args)
        {
            var task26 = new Solution();
            var nums = new[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            var r = task26.RemoveDuplicates(nums);
            Assert.That(r, Is.EqualTo(5));
            CollectionAssert.AreEqual(nums.Take(5), new []{ 0, 1, 2, 3, 4 });
            Console.ReadKey();
        }
    }

    public class Solution
    {
        public int RemoveDuplicates(int[] nums)
        {
            //Альтернатива с ухудшением по памяти.
            //var newNums = nums.Distinct().ToArray();
            //newNums.CopyTo(nums, 0);
            //return nums.Count();

            //Оптимальное решение.
            var index = 1;
            foreach (var n in nums)
            {
                if (nums[index - 1] != n) 
                    nums[index++] = n;
            }

            return index;
        }
    }
}