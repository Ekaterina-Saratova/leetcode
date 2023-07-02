namespace Task373
{

    public class Program
    {
        static void Main(string[] args)
        {
            var task373 = new Solution();
            var r = task373.KSmallestPairs(
                new[] { 1, 7, 11 },
                new[] { 2, 4, 6 },
                3
            );
            //var r = task373.KSmallestPairs(
            //    new[] { 1, 2},
            //    new[] { 3 },
            //    3
            //);
            Console.WriteLine(r);
            Console.ReadKey();
        }
    }

    public class Solution
    {
        public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {
            var result = new List<IList<int>>();
            var n = nums1.Length;
            var m = nums2.Length;

            var minHeap = new PriorityQueue<int[], int>();
            var visited = new HashSet<ValueTuple<int ,int>>();
            minHeap.Enqueue(new[] { nums1[0] + nums2[0], 0, 0 }, nums1[0] + nums2[0]);
            visited.Add((0, 0));
            while (k-- > 0 && minHeap.Count > 0)
            {
                var min = minHeap.Dequeue();
                var index1 = min[1];
                var index2 = min[2];
                result.Add(new List<int> { nums1[index1], nums2[index2] });


                if (index1 + 1 < n && visited.Add((index1 + 1, index2)))
                {
                    minHeap.Enqueue(new[] { nums1[index1 + 1] + nums2[index2], index1 + 1, index2 },
                        nums1[index1 + 1] + nums2[index2]);
                }
                if (index2 + 1 < m && visited.Add((index1, index2 + 1)))
                {
                    minHeap.Enqueue(new[] { nums1[index1] + nums2[index2 + 1], index1, index2 + 1 },
                        nums1[index1] + nums2[index2 + 1]);
                }

            }

            return result;
        }
    }
}