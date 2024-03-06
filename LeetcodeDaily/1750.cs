using NUnit.Framework;

namespace LeetCodeDaily
{
    public class Solution1750
    {
        public int MinimumLength(string s)
        {
            var numsCount = s.Length;

            var startPointer = 0;
            var endPointer = numsCount - 1;

            switch (numsCount)
            {
                case 1:
                    return 1;
                case 2:
                    return s[0] == s[1] ? 0 : 2;
                case 3 when s[0] != s[1] && s[1] != s[2] && s[0] != s[2]:
                    return 3;
            }

            var flagSymbol = 'd';

            while (startPointer < endPointer)
            {
                if (flagSymbol == 'd')
                {
                    if (s[startPointer] == s[endPointer])
                        flagSymbol = s[startPointer];

                    startPointer++;
                    endPointer--;
                    continue;
                }

                if (s[startPointer] == s[endPointer])
                {
                    startPointer++;
                    endPointer--;
                }
                else if (s[startPointer-1] == s[endPointer])
                    endPointer--;
                else if (s[startPointer] == s[endPointer+1])
                    startPointer++;
                else
                    break;
            }

            if (endPointer == startPointer && s[endPointer] == s[startPointer - 1])
                return 0;

            return endPointer - startPointer + 1;
        }
    }

    [TestFixture]
    public class Tests1750
    {
        [TestCase("abc", 3)]
        [TestCase("c", 1)]
        [TestCase("ca", 2)]
        [TestCase("bcacbb", 1)]
        [TestCase("caac", 0)]
        [TestCase("cabaabac", 0)]
        [TestCase("aabccabba", 3)]
        [TestCase("abbba", 0)]
        [TestCase("bbbbbbbbbbbbbbbbbbbbbbbbbbbabbbbbbbbbbbbbbbccbcbcbccbbabbb", 1)]
        public void Test(string s, int expected)
        {
            var result = new Solution1750().MinimumLength(s);
            Assert.AreEqual(expected, result);
        }
    }
}