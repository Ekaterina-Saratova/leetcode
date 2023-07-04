using NUnit.Framework;

namespace Task137
{

    public class Program
    {
        static void Main(string[] args)
        {
            var task137 = new Solution();
            Assert.That(task137.SingleNumber(new []{ 2, 2, 3, 2 }), Is.EqualTo(3));
            Assert.That(task137.SingleNumber(new []{ 0, 1, 0, 1, 0, 1, 99 }), Is.EqualTo(99));
            Console.ReadKey();
        }
    }

    public class Solution
    {
        public int SingleNumber(int[] nums)
        {
            //Не оптимально по памяти, но сложность линейная O(n).
            var potentialResult = new HashSet<int>();
            var duplicates = new HashSet<int>();

            foreach (var n in nums)
            {
                if (!duplicates.Add(n))
                    potentialResult.Remove(n);
                else
                    potentialResult.Add(n);
            }
            return potentialResult.First();

            //Корректное официальное решение с памятью O(1).
            //int ones = 0; // Tracks the bits that have appeared once
            //int twos = 0; // Tracks the bits that have appeared twice

            //foreach (int num in nums)
            //{
            //    ones = (ones ^ num) & ~twos;
            //    twos = (twos ^ num) & ~ones;
            //}

            //return ones;
        }
    }
}