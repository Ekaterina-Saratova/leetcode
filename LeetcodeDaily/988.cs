using NUnit.Framework;
using Utils;

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

        public bool HasPathSum(TreeNode root, int targetSum)
        {
            if (root == null)
                return false;

            targetSum -= root.val;

            if (root.left == null && root.right == null)
            {
                return targetSum == 0;
            }

            return HasPathSum(root.left, targetSum) || HasPathSum(root.right, targetSum);
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


            var n = new TreeNode();
            n.val = 5;
            n.left = new TreeNode(4);
            n.right = new TreeNode(8);

            n.right.left = new TreeNode(13);

            n.right.right = new TreeNode(4);
            n.right.right.right = new TreeNode(1);

            n.left.left = new TreeNode(11);
            n.left.left.left = new TreeNode(7);
            n.left.left.right = new TreeNode(2);
            var r2 = new Solution988().HasPathSum(n, 22);

            var t = new TreeNode(1);
            t.left = new TreeNode(-2);
            t.right = new TreeNode(-3);
            t.left.right = new TreeNode(3);
            t.left.left = new TreeNode(1);
            t.right.right = new TreeNode(-1);
            //var r3 = new Solution988().HasPathSum(t, 3);
        }
    }
}
