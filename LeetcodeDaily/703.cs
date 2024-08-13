using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDaily
{
    public class KthLargest
    {

        private List<int> _list = new List<int>();
        private int _k;
        public KthLargest(int k, int[] nums)
        {
            _k = k;
            Array.Sort(nums);
            _list = nums.ToList();
        }

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
                    _list.Insert(i+1, val);
                    return _list[_list.Count - _k];
                }
                _list.Insert(i, val);
                return _list[_list.Count - _k];
            }
            _list.Add(val);
            return _list[_list.Count - _k];
        }
    }

    public class KthLargest1
    {

        private PriorityQueue<int, int> _queue = new PriorityQueue<int, int>();
        private int _k;
        public KthLargest1(int k, int[] nums)
        {
            _k = k;
            nums = nums.OrderByDescending(c => c).ToArray();
            for (var i = 0; i < _k && i < nums.Count(); i++)
            {
                _queue.Enqueue(nums[i], nums[i]);
            }
        }

        public int Add(int val)
        {
            _queue.Enqueue(val, val);
            if (_queue.Count > _k)
                _queue.Dequeue();
            return _queue.Peek();
        }
    }

    [TestFixture]
    public class Tests703
    {
        [Test]
        [TestCase(new int[] { 4, 5, 8, 2 }, 3, 4)]
        public void Test(int[] arr, int k, int expected)
        {
            var kthLargestk = new KthLargest1(k, arr);
            kthLargestk.Add(3);
            kthLargestk.Add(5);
            kthLargestk.Add(10);
            kthLargestk.Add(9);
            kthLargestk.Add(4);
        }
    }
}
