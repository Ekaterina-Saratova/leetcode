using NUnit.Framework;

namespace LeetCodeDaily
{
    public class Solution916
    {
        public IList<string> WordSubsets(string[] words1, string[] words2)
        {
            var result = new List<string>();
            var counts = new int[26];

            for (var i = 0; i < 26; ++i)
            {
                counts[i] = 0;
            }

            foreach (var word in words2)
            {
                var newCount = new int[26];

                foreach (var c in word)
                {
                    newCount[c - 'a']++;
                }
                for (var i = 0; i < 26; ++i)
                {
                    counts[i] = Math.Max(counts[i], newCount[i]);
                }
            }

            foreach (var word in words1)
            {
                var newCount = new int[26];

                foreach (var c in word)
                {
                    newCount[c - 'a']++;
                }
                var isSubset = true;
                for (var i = 0; i < 26; ++i)
                {
                    if (counts[i] > newCount[i])
                    {
                        isSubset = false;
                        break;
                    }
                }
                if (isSubset) result.Add(word);
            }
            return result;
        }
    }

    [TestFixture]
    public class Test916
    {
        [Test]
        [TestCase(new[] { "amazon", "apple", "facebook", "google", "leetcode" }, new[] {"e", "o"}, new[] {"facebook", "google", "leetcode"})]
        public void Test(string[] words1, string[] words2, string[] expected)
        {
            var solution = new Solution916();
            var actual = solution.WordSubsets(words1, words2);
            Assert.AreEqual(expected, actual);
        }
    }
}
