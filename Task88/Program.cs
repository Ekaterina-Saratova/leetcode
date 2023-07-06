using NUnit.Framework;

namespace Task88
{

    public class Program
    {
        static void Main(string[] args)
        {
            var task88 = new Solution();
            var nums = new[] { 1, 2, 3, 0, 0, 0 };
            task88.Merge(nums, 3, new[] { 2, 5, 6 }, 3);
            task88.Merge(new []{1}, 1, new int[0], 0);
            CollectionAssert.AreEqual( new[] { 1, 2, 2, 3, 5, 6 }, nums);
            Console.ReadKey();
        }
    }

    public class Solution
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            //Просто и понятно, но О(m + (n+m)Log(n+m))
            //nums2.CopyTo(nums1, m);
            //Array.Sort(nums1);

            //О(n+m), но плюс один массив m в памяти.
            //var nums1Copy = nums1.ToArray();
            //var j = 0;
            //var i = 0;
            //for (var k = 0; k < m + n; k++)
            //{
            //    if (j >= n && i < m)
            //        nums1[k] = nums1Copy[i];
            //    if (i < m && j < n && nums1Copy[i] <= nums2[j])
            //    {
            //        nums1[k] = nums1Copy[i];
            //        i++;
            //    }
            //    else if (j < n)
            //    {
            //        nums1[k] = nums2[j];
            //        j++;
            //    }
            //}

            // O(m+n) и без лишнего массива в памяти - просто заполнять надо с конца.
            var i = m - 1;
            var j = n - 1; 
            var k = nums1.Length - 1; 
            while (j >= 0)
            {
                if (i >= 0 && nums1[i] > nums2[j])
                {
                    nums1[k] = nums1[i];
                    k--;
                    i--; 
                }
                else
                {
                    nums1[k] = nums2[j];
                    k--;
                    j--; 
                }
            }
        }
    }
}