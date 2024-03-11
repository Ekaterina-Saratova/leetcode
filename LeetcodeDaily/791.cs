using System.Text;
using NUnit.Framework;

namespace LeetCodeDaily
{
    /// <summary>
    /// https://leetcode.com/problems/custom-sort-string
    /// </summary>
    public class Solution791
    {
        public string CustomSortString(string order, string s)
        {
            var result = new StringBuilder();
            var visited = new HashSet<int>();
            foreach (var o in order)
            {
                for (var i = 0; i < s.Length; i++)
                {
                    if (s[i] == o && visited.Add(i))
                        result.Append(s[i]);
                }
            }
            for (var i = 0; i < s.Length; i++)
            {
                if (!visited.Contains(i))
                    result.Append(s[i]);
            }
            return result.ToString();
        }
    }

    [TestFixture]
    public class Tests791
    {
        [Test]
        [TestCase("cba", "abcd", "cbad")]
        public void Test(string order, string s, string expected)
        {
            var result = new Solution791().CustomSortString(order, s);
            Assert.AreEqual(expected, result);
        }
    }
}