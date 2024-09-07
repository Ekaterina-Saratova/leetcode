using System.Text;
using NUnit.Framework;

namespace Grind75
{
    public class Solution476
    {
        //Should use bit mask instead.
        public int FindComplement(int num)
        {
            var s = Convert.ToString(num, 2);
            var newNum = new StringBuilder(s.Length);
            foreach (var ch in s)
            {
                newNum.Append(ch == '1' ? '0' : '1');
            }
            return Convert.ToInt32(newNum.ToString(), 2);
        }
    }

    [TestFixture]
    public class Tests476
    {
        [TestCase( 5, 2)]
        [TestCase( 1, 0)]
        [TestCase( 2, 1)]
        public void Check(int target, int expected)
        {
            var actual = new Solution476().FindComplement(target);
            Assert.AreEqual(expected, actual);
        }
    }
}

