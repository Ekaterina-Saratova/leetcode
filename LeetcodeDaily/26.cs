using NUnit.Framework;

namespace LeetCodeDaily
{
    public class Solution26
    {
        public int StrStr(string haystack, string needle)
        {
            for (var i = 0; i < haystack.Length; i++)
            {
                var index = 0;
                while (index < needle.Length && index + i < haystack.Length && haystack[i + 1] == needle[index])
                {
                    index++;
                }
                if (index == needle.Length)
                    return i;
            }
            return -1;
        }
    }

    [TestFixture]
    public class Test26
    {
        [Test]
        [TestCase("sadbutsad", "sad", 2)]
        public void Test(string haystack, string needle, int expectedCount)
        {
            var solution = new Solution26();
            var actual = solution.StrStr(haystack, needle);
            Assert.AreEqual(expectedCount, actual);
        }
    }
}
