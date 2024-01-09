using NUnit.Framework;
using System.Collections;

namespace LeetCodeDaily
{
    public class Solution872
    {
        public bool LeafSimilar(TreeNode root1, TreeNode root2)
        {
            var leaves1 = new List<int>();
            var leaves2 = new List<int>();
            Dfs(root1, leaves1);
            Dfs(root2, leaves2);

            if (leaves1.Count != leaves2.Count)
                return false;

            return leaves2.SequenceEqual(leaves1);
        }

        public void Dfs(TreeNode? node, List<int> leafValues)
        {
            if (node != null)
            {
                if (node.left == null && node.right == null)
                    leafValues.Add(node.val);

                Dfs(node.left, leafValues);
                Dfs(node.right, leafValues);
            }
        }
    }

    [TestFixture]
    public class Tests872
    {
        //public void TestContentCount()
        //{
        //    var t1 = new TreeNode();
        //    var result = new Solution455().FindContentChildren(greed, size);
        //    Assert.AreEqual(result, contentCount);
        //}
    }

    public class TreeNode
    {
        public int val;
        public TreeNode? left;
        public TreeNode? right;

        public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}