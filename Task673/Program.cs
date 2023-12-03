using NUnit.Framework;
using System;

namespace Task673
{
    public class Program
    {
        static void Main(string[] args)
        {
            var t = new Solution();
            t.FindNumberOfLIS(new []{ 1, 3, 5, 4, 7 });

            Task.Run(() => t.Test());

            Console.ReadKey();
        }
    }

    

    public class Solution
    {
        public async IAsyncEnumerable<int> GetDataAsync()
        {
            // Simulate fetching data asynchronously
            for (int i = 10; i > 0; i--)
            {
                await Task.Delay(100 * i); // Simulate delay
                yield return i;
            }
        }

        public async Task Test()
        {
            await foreach (var item in GetDataAsync())
            {
                // Process the item asynchronously
                Console.WriteLine(item);
            }
        }

        public int FindNumberOfLIS(int[] nums)
        {
            int n = nums.Length;
            int[] length = new int[n];
            int[] count = new int[n];

            Array.Fill(length, 1);
            Array.Fill(count, 1);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] < nums[i])
                    {
                        if (length[j] + 1 > length[i])
                        {
                            length[i] = length[j] + 1;
                            count[i] = 0;
                        }
                        if (length[j] + 1 == length[i])
                        {
                            count[i] += count[j];
                        }
                    }
                }
            }

            int maxLength = 0;
            int result = 0;

            foreach (int len in length)
            {
                maxLength = Math.Max(maxLength, len);
            }

            for (int i = 0; i < n; i++)
            {
                if (length[i] == maxLength)
                {
                    result += count[i];
                }
            }

            return result;
        }
    }
}