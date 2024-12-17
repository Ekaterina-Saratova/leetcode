using NUnit.Framework;

namespace LeetCodeDaily
{
    public class Solution3264
    {
        public int[] GetFinalState(int[] nums, int k, int multiplier)
        {
            var priorityQueue = new PriorityQueue<int, QueueItem>(Comparer<QueueItem>.Create((a, b) =>
            {
                if (a.Value == b.Value)
                    return a.Index.CompareTo(b.Index);
                return a.Value.CompareTo(b.Value);

            }));

            for (var i = 0; i < nums.Length; i++)
            {
                priorityQueue.Enqueue(i, new QueueItem(i, nums[i]));
            }

            while (k > 0)
            {
                var minIndex = priorityQueue.Dequeue();
                nums[minIndex] = nums[minIndex] * multiplier;
                priorityQueue.Enqueue(minIndex, new QueueItem(minIndex, nums[minIndex]));
                k--;
            }

            return nums;
        }
    }

    public class QueueItem(int index, int value)
    {
        public int Index { get; set; } = index;
        public int Value { get; set; } = value;
    }

    [TestFixture]
    public class Test13264
    {
        [Test]
        [TestCase(new int[] { 2, 1, 3, 5, 6 }, 5, 2, new int[] { 8, 4, 6, 5, 6 })]
        public void Test(int[] nums, int k, int multiplier, int[] expected)
        {
            var solution = new Solution3264();
            Assert.AreEqual(expected, solution.GetFinalState(nums, k, multiplier));
        }
    }
}
