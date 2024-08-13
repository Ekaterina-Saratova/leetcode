using NUnit.Framework;

namespace Grind75
{
    public class Solution13
    {
        private readonly Dictionary<char, int> dict = new Dictionary<char, int>
    {
        {'I', 1},
        {'V', 5},
        {'X', 10},
        {'L', 50},
        {'C', 100},
        {'D', 500},
        {'M', 1000},
    };
        public int RomanToInt(string s)
        {
            var sum = 0;
            for (var i = 0; i < s.Length; i++)
            {
                var j = i + 1;
                if (i == s.Length - 1)
                {
                    sum += dict[s[i]];
                    break;
                }

                if (dict[s[i]] >= dict[s[j]])
                {
                    sum += dict[s[i]];
                }
                else
                {
                    sum += dict[s[j]] - dict[s[i]];
                    i++;
                }
            }

            return sum;
        }
    }

    [TestFixture]
    public class Tests13
    {
        [TestCase("III", 3)]
        [TestCase("LVIII", 58)]
        [TestCase("MCMXCIV", 1994)]
        public void Check(string s, int expected)
        {
            var actual = new Solution13().RomanToInt(s);
            Assert.AreEqual(expected, actual);
        }
    }
}

