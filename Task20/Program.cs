using NUnit.Framework;

namespace Task20
{
    /// <summary>
    /// Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
    /// An input string is valid if:
    /// Open brackets must be closed by the same type of brackets.
    /// Open brackets must be closed in the correct order.
    /// Every close bracket has a corresponding open bracket of the same type.
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            var task20 = new Solution();
            Assert.That(task20.IsValid("()"), Is.True);
            Assert.That(task20.IsValid("()[]{}"), Is.True);
            Assert.That(task20.IsValid("(]"), Is.False);
            Assert.That(task20.IsValid("(((]"), Is.False);
            Assert.That(task20.IsValid("([)]"), Is.False);
            Console.ReadKey();
        }
    }

    public class Solution
    {
        public bool IsValid(string s)
        {
            var stack = new Stack<char>();
            foreach (var ch in s)
            {
                if (ch == '(' || ch == '{' || ch == '[')
                    stack.Push(ch);
                if (ch == ')')
                {
                    if (stack.Count == 0 || stack.Pop() != '(')
                        return false;
                }
                if (ch == '}')
                {
                    if (stack.Count == 0 || stack.Pop() != '{')
                        return false;
                }
                if (ch == ']')
                {
                    if (stack.Count == 0 || stack.Pop() != '[')
                        return false;
                }
            }

            return stack.Count == 0;
        }
    }
}