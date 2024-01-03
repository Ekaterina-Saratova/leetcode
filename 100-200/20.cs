using NUnit.Framework;

namespace Grind75
{
    public class Solution20
    {
        public bool IsValid(string s)
        {
            var openBrackets = new HashSet<char>() { '(', '[', '{'};
            var stack = new Stack<char>();

            foreach (var symbol in s)
            {
                if (openBrackets.Contains(symbol))
                {
                    stack.Push(symbol);
                    continue;
                }

                if (symbol == ')' && (stack.Count == 0 || stack.Pop() != '('))
                    return false;
                if (symbol == ']' && (stack.Count == 0 || stack.Pop() != '['))
                    return false;
                if (symbol == '}' && (stack.Count == 0 || stack.Pop() != '{'))
                    return false;
            }

            return stack.Count == 0;
        }

        // Nice and clean stack
        public bool IsValidStack(string s)
        {
            var stack = new Stack<char>();

            foreach (var symbol in s)
            {
                if (symbol == '(')
                    stack.Push(')');
                else if (symbol == '[')
                    stack.Push(']');
                else if (symbol == '{')
                    stack.Push('}');
                else if (stack.Count == 0 || stack.Pop() != symbol)
                    return false;
            }

            return stack.Count == 0;
        }
    }

    [TestFixture]
    public class Tests20
    {
        [TestCase("()")]
        [TestCase("()[]{}")]
        public void ReturnTrue(string s)
        {
            var result = new Solution20().IsValidStack(s);
            Assert.IsTrue(result);
        }

        [TestCase("(]")]
        [TestCase("]")]
        public void ReturnFalse(string s)
        {
            var result = new Solution20().IsValidStack(s);
            Assert.IsFalse(result);
        }
    }
}

