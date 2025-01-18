using NUnit.Framework;
using System.Linq;

namespace LeetCodeDaily
{
    public class Solution3223
    {
        public int MinimumLength(string s)
        {
            var dict = new Dictionary<char, int>();
            foreach (var ch in s)
            {
                if (dict.ContainsKey(ch))
                    dict[ch] += 1;
                else
                    dict.Add(ch, 1);
            }

            var result = 0;
            foreach (var d in dict)
            {
                if (d.Value < 3)
                {
                    result += d.Value;
                    continue;
                }
                result += d.Value % 2 == 0 ? 2 : 1;
            }
            return result;
        }
    }

    [TestFixture]
    public class Test3223
    {
        [Test]
        [TestCase("ucvbutgkohgbcobqeyqwppbxqoynxeuuzouyvmydfhrprdbuzwqebwuiejoxsxdhbmuaiscalnteocghnlisxxawxgcjloevrdcj", 38)]
        public void Test(string s, int expectedCount)
        {
            var solution = new Solution3223();
            var actual = solution.MinimumLength(s);
            Assert.AreEqual(expectedCount, actual);
        }
    }
}
