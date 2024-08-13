using NUnit.Framework;

namespace Grind75
{
    public class Solution125
    {
        public bool IsPalindrome(string s)
        {
            var a  = "abcdefghijklmnopqrstuvwxyz0123456789".ToHashSet();

            var j = s.Length - 1;
            for (var i = 0; i < s.Length && j >= 0; i++)
            {
                while (!a.Contains(char.ToLower(s[i])) && i < s.Length - 1)
                    i++;

                while (!a.Contains(char.ToLower(s[j])) && j > 0)
                    j--;

                if (i == j || (j == 0 && i == s.Length - 1))
                    break;

                if (char.ToLower(s[i]) != char.ToLower(s[j]))
                    return false;

                j--;
            }

            return true;
        }
    }

    [TestFixture]
    public class Tests125
    {
        [TestCase("A man, a plan, a canal: Panama")]
        [TestCase(" ")]
        [TestCase(",.")]
        [TestCase("a.")]
        [TestCase("Never a foot too far, even.")]
        public void ReturnTrue(string s)
        {
            var result = new Solution125().IsPalindrome(s);
            Assert.IsTrue(result);
        }

        [TestCase("0P")]
        public void ReturnFalse(string s)
        {
            var result = new Solution125().IsPalindrome(s);
            Assert.IsFalse(result);
        }
    }
}

