using NUnit.Framework;

namespace LeetCodeDaily
{
    public class Solution2870
    {
        public int MinOperations(int[] nums)
        {
            var frequencies = new Dictionary<int, int>();
            var result = 0;
            foreach (var n in nums)
            {
                if (frequencies.ContainsKey(n))
                    frequencies[n]++;
                else
                    frequencies.Add(n, 1);
            }

            foreach (var f in frequencies)
            {
                if (f.Value == 1)
                    return -1;

                //result += (f.Value + 2) / 3;
                result += (int)Math.Ceiling((double)f.Value / 3);

                //man... I'm bad at math...
                //switch (f.Value % 3)
                //{
                //    case 0:
                //        result += f.Value / 3;
                //        break;
                //    case 2:
                //        result += f.Value / 3 + 1;
                //        break;
                //    case 1:
                //        if ((f.Value - 2) % 3 == 0)
                //            result += ((f.Value - 2) / 3) + 1;
                //        else if ((f.Value - 4) % 3 == 0)
                //            result += ((f.Value - 4) / 3) + 2;
                //        break;
                //    default:
                //        return -1;
                //}
            }

            return result;
        }
    }

    [TestFixture]
    public class Tests2870
    {
        [TestCase(new[] { 2, 3, 3, 2, 2, 4, 2, 3, 4 }, 4)]
        [TestCase(new[] { 14, 12, 14, 14, 12, 14, 14, 12, 12, 12, 12, 14, 14, 12, 14, 14, 14, 12, 12 }, 7)]
        [TestCase(new[] { 2, 1, 2, 2, 3, 3 }, -1)]
        public void TestOperations(int[] nums, int count)
        {
            var result = new Solution2870().MinOperations(nums);
            Assert.AreEqual(count, result);
        }
    }
}