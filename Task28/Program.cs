using NUnit.Framework;

namespace Task28
{
    /// <summary>
    /// Given two strings needle and haystack, return the index of the first occurrence of needle in haystack,
    /// or -1 if needle is not part of haystack.
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            var task28 = new Solution();
            Assert.That(task28.StrStr("sadbutsad", "sad"), Is.EqualTo(0));
            Assert.That(task28.StrStr("leetcode", "leeto"), Is.EqualTo(-1));
            Assert.That(task28.StrStr("mississippi", "issip"), Is.EqualTo(4));
            Console.ReadKey();
        }
    }

    public class Solution
    {
        public int StrStr(string haystack, string needle)
        {
            if (needle.Length > haystack.Length) return -1;
            for (var i = 0; i < haystack.Length; i++)
            {
                if (haystack[i] == needle[0])
                {
                    var index = i;
                    for (var j = 0; j < needle.Length && i < haystack.Length; j++)
                    {
                        if (haystack[i] != needle[j]) break;
                        if (j == needle.Length - 1) return index;
                        i++;
                    }

                    i = index;
                }
            }

            return -1;
        }
    }
}