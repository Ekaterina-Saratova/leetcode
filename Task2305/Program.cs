namespace Task2305
{

    public class Program
    {
        static void Main(string[] args)
        {
            var task2305 = new Solution();
            var nums = new[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };

            Console.ReadKey();
        }
    }

    public class Solution
    {
        public int DistributeCookies(int[] cookies, int k)
        {
            return 0;
        }
    }
}
//Algorithm
// 
// Create an array distribute of length k initialized with all zeros, which represents the unfairness of each child.
// 
// Define the recursive function dfs(i, zero_count) to distribute the ithith cookie:
// If the number of undistributed cookies is less than zero_count, which is n - i < zero_count, return a large integer like float('inf'), implying that the current distribution is invalid.
// If i = n, return the maximum value of distribute which is the unfairness of this distribution.
// Otherwise, set answer as float('inf') and continue with step 3.
// 
// Iterate through distribute and for each child j:
// Increment distribute[j] by cookie[i], if distribute[i] is 0 before the distribution, decrement zero_count by 1.
// Recursively call dfs(i + 1, zero_count) and update answer as the minimum unfairness encountered, answer = min(answer, dfs(i + 1, zero_count)).
// Decrement distribute[j] by cookie[i], if distribute[i] is 0 after the process, increment zero_count by 1. (This is the backtrack step)
// 
// Return answer after the iteration is complete.
// 
// Return dfs(0, distribute).
// 

//class Solution
//{
//    private int dfs(int i, int[] distribute, int[] cookies, int k, int zeroCount)
//    {
//        // If there are not enough cookies remaining, return Integer.MAX_VALUE
//        // as it leads to an invalid distribution.
//        if (cookies.length - i < zeroCount)
//        {
//            return Integer.MAX_VALUE;
//        }

//        // After distributing all cookies, return the unfairness of this
//        // distribution.
//        if (i == cookies.length)
//        {
//            int unfairness = Integer.MIN_VALUE;
//            for (int value : distribute)
//            {
//                unfairness = Math.max(unfairness, value);
//            }
//            return unfairness;
//        }

//        // Try to distribute the i-th cookie to each child, and update answer
//        // as the minimum unfairness in these distributions.
//        int answer = Integer.MAX_VALUE;
//        for (int j = 0; j < k; ++j)
//        {
//            zeroCount -= distribute[j] == 0 ? 1 : 0;
//            distribute[j] += cookies[i];

//            // Recursively distribute the next cookie.
//            answer = Math.min(answer, dfs(i + 1, distribute, cookies, k, zeroCount));

//            distribute[j] -= cookies[i];
//            zeroCount += distribute[j] == 0 ? 1 : 0;
//        }

//        return answer;
//    }

//    public int distributeCookies(int[] cookies, int k)
//    {
//        int[] distribute = new int[k];

//        return dfs(0, distribute, cookies, k, k);
//    }
//}