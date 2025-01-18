using NUnit.Framework;
using System.Linq;

namespace LeetCodeDaily
{
    public class Solution1930
    {
        public int CountPalindromicSubsequence(string s)
        {
            var map = new HashSet<string>();
            var dict = new Dictionary<char, (int First, int Last)>();

            for (var i = 0; i < s.Length; i++)
            {
                if (dict.ContainsKey(s[i]))
                    dict[s[i]] = (dict[s[i]].First, i);
                else
                    dict.Add(s[i], (i, i));
            }

            foreach (var d in dict)
            {
                var first = d.Value.First;
                var last = d.Value.Last;
                if (d.Value.First == d.Value.Last)
                    continue;
                for (int i = first+1; i < last; i++)
                {
                    map.Add($"{d.Key}{s[i]}{d.Key}");
                }
            }

            return map.Count;
        }
    }

    [TestFixture]
    public class Test1930
    {
        [Test]
        [TestCase("bbcbaba", 4)]
        public void Test(string s, int expectedCount)
        {
            var solution = new Solution1930();
            var actual = solution.CountPalindromicSubsequence(s);
            Assert.AreEqual(expectedCount, actual);
        }
    }
}
