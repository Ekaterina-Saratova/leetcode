using NUnit.Framework;

namespace LeetCodeDaily
{
    public class Solution455
    {
        public int FindContentChildren(int[] greed, int[] size)
        {
            Array.Sort(greed);
            Array.Sort(size);
            
            var result = 0;

            var childPointer = 0;
            var sizePointer = 0;

            while (childPointer < greed.Length && sizePointer < size.Length)
            {
                if (greed[childPointer] <= size[sizePointer])
                {
                    result++;
                    childPointer++;
                    sizePointer++;
                }
                else
                {
                    sizePointer++;
                }
            }

            return result;
        }
    }

    [TestFixture]
    public class Tests445
    {
        [TestCase(new int[] { 1, 2, 3 }, new int[] {1,1}, 1)]
        [TestCase(new int[] { 1, 2 }, new int[] {1,2,3}, 2)]
        [TestCase(new int[] { }, new int[] {}, 0)]
        [TestCase(new int[] { 1 }, new int[] {}, 0)]
        public void TestContentCount(int[] greed, int[] size, int contentCount)
        {
            var result = new Solution455().FindContentChildren(greed, size);
            Assert.AreEqual(result, contentCount);
        }
    }
}