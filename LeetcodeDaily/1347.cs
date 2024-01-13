using NUnit.Framework;

namespace LeetCodeDaily
{
    public class Solution1347
    {
        public int MinSteps(string s, string t)
        {
            var sDict = new Dictionary<char, int>();

            for (var i = 0; i < s.Length; i++)
            {
                if (sDict.ContainsKey(s[i]))
                    sDict[s[i]]--;
                else
                    sDict.Add(s[i], -1);
                if (sDict.ContainsKey(t[i]))
                    sDict[t[i]]++;
                else
                    sDict.Add(t[i], 1);
            }

            var result = 0;

            foreach (var d in sDict)
            {
                if (d.Value > 0)
                    result += d.Value;
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