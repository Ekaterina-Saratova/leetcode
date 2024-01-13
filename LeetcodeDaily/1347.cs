using NUnit.Framework;

namespace LeetCodeDaily
{
    public class Solution1347
    {
        public int MinSteps(string s, string t)
        {
            var sDict = new Dictionary<char, int>();

            foreach (var ch in s)
            {
                if (sDict.ContainsKey(ch))
                    sDict[ch]++;
                else
                    sDict.Add(ch, 1);
            }

            var result = 0;

            foreach (var ch in t)
            {
                if (sDict.ContainsKey(ch) && sDict[ch] > 0)
                    sDict[ch]--;
                else
                    result++;
            }

            return result;
        }
    }

    [TestFixture]
    public class Tests1347
    {
        [TestCase("bab", "aba", 1)]
        [TestCase("leetcode", "practice", 5)]
        [TestCase("anagram", "mangaar", 0)]
        public void TestOperations(string s, string t,  int expected)
        {
            var result = new Solution1347().MinSteps(s, t);
            Assert.AreEqual(expected, result);
        }
    }
}