using NUnit.Framework;

namespace Task859
{
    //Given two strings s and goal, return true if you can swap two letters in s so the result is equal to goal, otherwise, return false.
    //Swapping letters is defined as taking two indices i and j(0-indexed) such that i != j and swapping the characters at s[i] and s[j].
    //For example, swapping at indices 0 and 2 in "abcd" results in "cbad".
    public class Program
    {
        static void Main(string[] args)
        {
            var task859 = new Solution();
            try
            {
                Assert.That(task859.BuddyStrings("ab", "ba"), Is.True);
                Assert.That(task859.BuddyStrings("ab", "ab"), Is.False);
                Assert.That(task859.BuddyStrings("abac", "abad"), Is.False);
                Assert.That(task859.BuddyStrings("aa", "aa"), Is.True);
                Assert.That(task859.BuddyStrings("abab", "abab"), Is.True);
                Assert.That(task859.BuddyStrings("ab", "babbb"), Is.False);
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
        public bool BuddyStrings(string s, string goal)
        {
            var counter = 0;
            char sLetter = '\0';
            char goalLetter = '\0';
            var hasDoubleLetters = false;
            var hashLetters = new HashSet<char>();
            if (s.Length != goal.Length)
                return false;
            for (int i = 0; i < s.Length; i++)
            {
                hashLetters.Add(s[i]);
                if (s[i] == goal[i]) continue;
                counter++;
                if (counter > 2)
                    return false;

                if (counter == 1)
                {
                    sLetter = s[i];
                    goalLetter = goal[i];
                }

                if (counter == 2 && (sLetter != goal[i] || goalLetter != s[i]))
                    return false;
            }

            if (counter == 1) return false;
            return counter == 2 || (hashLetters.Count > 2 && hashLetters.Count < s.Length) || (s.Length > 1 && hashLetters.Count < s.Length);
        }
    }
}