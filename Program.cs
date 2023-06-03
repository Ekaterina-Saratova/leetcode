namespace LeetCodePractice
{
    //70. Climbing Stairs
    //You are climbing a staircase. It takes n steps to reach the top.
    //Each time you can either climb 1 or 2 steps.In how many distinct ways can you climb to the top?
    public class Task70
    {
        static void Main(string[] args)
        {
            var task70 = new Solution();
            Console.WriteLine(task70.ClimbStairs(5));
        }
    }

    public class Solution
    {
        public int ClimbStairs(int n)
        {
            if (n <= 3)
                return n;
            var first = 2;
            var second = 3;
            var result = 0;
            for (var i = 4; i <= n; i++)
            {
                result = first + second;
                first = second;
                second = result;
            }
            return result;
        }
    }
}
