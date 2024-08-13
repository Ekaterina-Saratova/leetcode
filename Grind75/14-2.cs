using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100_200
{
    public class Solution14_2
    {
        public string LongestCommonPrefix(string[] strs)
        {
            var common = strs[0].ToList();

            foreach (var s in strs)
            {
                for (var i = 0; i < s.Length; i++)
                {
                    if (common.Count > i && s[i] == common[i])
                        continue;
                    common.RemoveRange(i, common.Count - i);
                    break;
                }
                if (common.Count > s.Length)
                    common.RemoveRange(s.Length, common.Count - s.Length);
            }

            return string.Concat(common.ToArray());
        }
    }

    [TestFixture]
    public class Tests14_2
    {
        [TestCase(new[] { "flower", "flow", "flight"}, "fl")]
        [TestCase(new[] { "ab", "a" }, "a")]
        public void Check(string[] strs, string expected)
        {
            var actual = new Solution14_2().LongestCommonPrefix(strs);
            Assert.AreEqual(expected, actual);
        }
    }
}
