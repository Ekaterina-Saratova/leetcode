
using NUnit.Framework;

namespace LeetCodeDaily
{
    internal class Solution988
    {
        private string st = "";
        public string SmallestFromLeaf(TreeNode root)
        {
            PreorderTraversal(root, st);
            Console.WriteLine(st);
            return st;
        }

        void PreorderTraversal(TreeNode node, String currentString)
        {
            if (node != null)
            {
                Console.Write(node.val + " ");
                currentString = (char)(node.val + 'a') + currentString;
                if (node.left == null && node.right == null)
                {
                    if (st == "" || String.Compare(st, currentString) > 0)
                        st = currentString;
                }
                PreorderTraversal(node.left, currentString);
                PreorderTraversal(node.right, currentString);
            }
        }
        void PostorderTraversal(TreeNode node)
        {
            if (node != null)
            {
                PostorderTraversal(node.left);
                PostorderTraversal(node.right);
                Console.Write(node.val + " ");

            }
        }
        void InorderTraversal(TreeNode node)
        {
            if (node != null)
            {
                InorderTraversal(node.left);
                Console.Write(node.val + " ");
                InorderTraversal(node.right);
            }
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    [TestFixture]
    public class Tests988
    {
        [Test]
        public void TestContentCount()
        {
            var node = new TreeNode();
            node.val = 0;
            var node1 = new TreeNode();
            node1.val = 1;
            var node2 = new TreeNode();
            node2.val = 2;
            var node3 = new TreeNode();
            node3.val = 3;
            var node4 = new TreeNode();
            node4.val = 4;
            var node5 = new TreeNode();
            node5.val = 5;
            node.left = node1;
            node.right = node2;
            node1.left = node3;
            node1.right = node4;
            node2.left = node5;
            var result = new Solution988().SmallestFromLeaf(node);
        }
    }
}
