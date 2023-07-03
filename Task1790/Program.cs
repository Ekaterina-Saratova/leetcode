using NUnit.Framework;

namespace Task1790
{
    /// <summary>
    /// You are given two strings s1 and s2 of equal length.
    /// A string swap is an operation where you choose two indices in a string (not necessarily different)
    /// and swap the characters at these indices.
    /// 
    /// Return true if it is possible to make both strings equal by performing at most one string swap
    /// on exactly one of the strings. Otherwise, return false.
    ///
    /// Constraints:
    /// 
    /// 1 >= s1.length, s2.length <= 100
    /// s1.length == s2.length
    /// s1 and s2 consist of only lowercase English letters.
    /// 
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            var task1790 = new Solution();
            try
            {
                Assert.That(task1790.AreAlmostEqual("ab", "ba"), Is.True);
                Assert.That(task1790.AreAlmostEqual("ab", "ab"), Is.True);
                Assert.That(task1790.AreAlmostEqual("abac", "abad"), Is.False);
                Assert.That(task1790.AreAlmostEqual("aa", "aa"), Is.True);
                Assert.That(task1790.AreAlmostEqual("abab", "abab"), Is.True);
                Console.WriteLine("Success!");
            }
            catch
            {
                Console.WriteLine("Fail...");
            }
            Console.ReadKey();
        }
    }

    public class Solution
    {
        public bool AreAlmostEqual(string s1, string s2)
        {
            if (s1.Equals(s2))
                return true;
            var counter = 0;
            char letterS1 = '\0';
            char letterS2 = '\0';
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] == s2[i]) continue;
                counter++;
                if (counter > 2)
                    return false;
                if (counter == 1)
                {
                    letterS1 = s1[i];
                    letterS2 = s2[i];
                }

                if (counter == 2 && (letterS1 != s2[i] || letterS2 != s1[i]))
                    return false;
            }

            return counter != 1;
        }
    }
}