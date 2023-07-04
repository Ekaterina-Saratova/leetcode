using NUnit.Framework;

namespace Task27
{
    /// <summary>
    /// Given an integer array nums and an integer val, remove all occurrences of val in nums in-place.
    /// The order of the elements may be changed. Then return the number of elements in nums which are not equal to val.
    ///
    /// Consider the number of elements in nums which are not equal to val be k, to get accepted, you need to do the following things:
    /// - Change the array nums such that the first k elements of nums contain the elements which are not equal to val.
    ///   The remaining elements of nums are not important as well as the size of nums.
    /// - Return k.
    /// 
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            var task137 = new Solution();
            Assert.That(task137.RemoveElement(new[] { 3, 2, 2, 3 }, 2), Is.EqualTo(2));
            Assert.That(task137.RemoveElement(new[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2), Is.EqualTo(5));
            Console.ReadKey();
        }
    }

    public class Solution
    {
        public int RemoveElement(int[] nums, int val)
        {
            var l = nums.Length;
            var uniqueCounter = 0;
            var duplicateCounter = 0;
            for (int i = 0; i < l - duplicateCounter; i++)
            {
                if (nums[i] != val)
                {
                    uniqueCounter++;
                    continue;
                }

                duplicateCounter++;
                nums[i] = nums[l - duplicateCounter];
                i--;
            }

            return uniqueCounter;
            
            //Более лаконичный вариант:
            //int current = 0;

            //for (int i = 0; i < nums.Length; i++)
            //{
            //    if (nums[i] != val)
            //    {
            //        nums[current] = nums[i];
            //        current++;
            //    }
            //}
            //return current;
        }
    }
}