using NUnit.Framework;

namespace LeetCodeDaily
{
    public class Solution2125
    {
        public int NumberOfBeams(string[] bank)
        {
            var result = 0;
            var previous = bank[0];

            for (var i = 1; i < bank.Length; i++)
            {
                var currentCount = bank[i].Count(x => x == '1');
                result += previous.Count(x => x == '1') * currentCount;

                if (currentCount != 0)
                    previous = bank[i];
            }

            return result;
        }
    }

    [TestFixture]
    public class Tests2125
    {
        [TestCase(new string[]{ "011001", "000000", "010100", "001000" }, 8)]
        [TestCase(new string[]{ "011001", "000000", "000000", "000000", "010100", "001000" }, 8)]
        [TestCase(new string[]{ "000", "111", "000" }, 0)]
        public void TestBeams(string[] bank, int beamCount)
        {
            var result = new Solution2125().NumberOfBeams(bank);
            Assert.AreEqual(beamCount, result);
        }
    }
}