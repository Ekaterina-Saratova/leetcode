using NUnit.Framework;

namespace LeetCodeDaily
{
    /// <summary>
    /// Heap via PriorityQueue solution.
    /// </summary>
    public class KthLargest1
    {
        private PriorityQueue<int, int> _queue = new PriorityQueue<int, int>();
        private int _k;
        public int Add(int val)
        {
            _queue.Enqueue(val, val);
            if (_queue.Count > _k)
                _queue.Dequeue();
            return _queue.Peek();
        }
        public KthLargest1(int k, int[] nums)
        {
            _k = k;
            nums = nums.OrderByDescending(c => c).ToArray();
            for (var i = 0; i < _k && i < nums.Count(); i++)
            {
                _queue.Enqueue(nums[i], nums[i]);
            }
        }
    }

    /// <summary>
    /// Naive solution with heap via sorted list.
    /// </summary>
    public class KthLargest
    {
        private readonly List<int> _list;
        private readonly int _k;

        public int Add(int val)
        {
            if (_list.Count == 0)
            {
                _list.Add(val);
                return _list[0];
            }

            if (_list[0] > val)
            {
                _list.Insert(0, val);
            }

            for (var i = 0; i < _list.Count; i++)
            {
                if (val > _list[i])
                    continue;
                if (val == _list[i])
                {
                    _list.Insert(i + 1, val);
                    return _list[^_k];
                }
                _list.Insert(i, val);
                return _list[^_k];
            }
            _list.Add(val);
            return _list[^_k];
        }
        public KthLargest(int k, int[] nums)
        {
            _k = k;
            Array.Sort(nums);
            _list = nums.ToList();
        }
    }

    [TestFixture]
    public class Tests703
    {
        [Test]
        [TestCase(new int[] { 4, 5, 8, 2 }, 3, new int[] { 3, 5, 10, 9, 4 }, new int[] { 4, 5, 5, 8, 8 })]
        public void Test(int[] arr, int k, int[] add, int[] expected)
        {
            var kthLargest = new KthLargest1(k, arr);
            for (var i =0; i < add.Length; i++)
            {
                Assert.AreEqual(expected[i], kthLargest.Add(add[i]));
            }
        }
    }
}
