using NUnit.Framework;

namespace Grind75
{
    public class Solution125Copy
    {
        public bool IsPalindrome(string s)
        {
            var allphabet = "abcdefghijklmnopqrstuvwxyz0123456789";
            var s1 = s.ToLower();
            var i = 0;
            var j = s.Length - 1;
            while (i < j)
            {
                while (!allphabet.Contains(s1[i]) && i < s.Length - 1)
                    i++;
                while (!allphabet.Contains(s1[j]) && j > 0)
                    j--;
                if (i != s.Length -1 && j != 0 && s1[i] != s1[j])
                    return false;
                j--;
                i++;
            }
            return true;
        }
    }

    [TestFixture]
    public class Tests125Copy
    {
        [Test]
        [TestCase("0P", false)]
        [TestCase(".,", true)]
        public void ReturnTrue(string s, bool expected)
        {
            var result = new Solution125Copy().IsPalindrome(s);
            Assert.AreEqual(expected, result);
        }
    }
}

