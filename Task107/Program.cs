using NUnit.Framework;
using System.Collections.Generic;

namespace Tas107
{
    public class Program
    {
        static void Main(string[] args)
        {
            var task107 = new Solution();
            var tree1 = new TreeNode(3, new TreeNode(9, null, null), new TreeNode(20, new TreeNode(15), new TreeNode(7)));
            Assert.That(task107.MaxDepth(tree1), Is.EqualTo(3));
            Console.ReadKey();
        }
    }
    //Definition for a binary tree node.
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

    public class Solution
    {
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            var leftDepth = MaxDepth(root.left);
            var rightDepth = MaxDepth(root.right);

            return Math.Max(leftDepth, rightDepth) + 1;
        }

        //Обход в глубину.
        public void DepthTraverse(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            Console.WriteLine(node.val);
            DepthTraverse(node.left);
            DepthTraverse(node.right);
        }

        //Обход в ширину
        void WidthTraversal(TreeNode root)
        {
            if (root == null)
                return;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                Console.WriteLine(current.val);
                if (current.left != null)
                    queue.Enqueue(current.left);
                if (current.right != null)
                    queue.Enqueue(current.right);
            }
        }
    }

    //Плохое решение, но пригодится для получения списка элементов одного уровня.
    //public int MaxDepth(TreeNode root)
    //{
    //    if (root == null)
    //        return 0;
    //    var counter = 1;
    //    var list = new List<TreeNode>();
    //    if (root.left != null)
    //        list.Add(root.left);
    //    if (root.right != null)
    //        list.Add(root.right);
    //    if (list.Count > 0)
    //        Traverse(list, ref counter);
    //    return counter;
    //}

    //public void Traverse(List<TreeNode> nodeList, ref int counter)
    //{
    //    counter++;
    //    var nextLevelList = new List<TreeNode>();
    //    foreach (var l in nodeList)
    //    {
    //        if (l.left != null)
    //            nextLevelList.Add(l.left);
    //        if (l.right != null)
    //            nextLevelList.Add(l.right);
    //    }
    //    if (nextLevelList.Count > 0)
    //        Traverse(nextLevelList, ref counter);
    //}

    //Подсчет элементов.
    //public int MaxDepth(TreeNode root)
    //{
    //    var counter = 0;
    //    Traverse(root, ref counter);
    //    return counter;
    //}

    //public void Traverse(TreeNode node, ref int counter)
    //{
    //    if (node == null) return;
    //    Traverse(node.left, ref counter);
    //    Traverse(node.right, ref counter);
    //    counter++;
    //}
}