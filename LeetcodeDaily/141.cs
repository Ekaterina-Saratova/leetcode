using NUnit.Framework;

namespace LeetCodeDaily
{
    public class Solution141
    {
        public bool HasCycle(ListNode head)
        {
            var visited = new HashSet<ListNode>();

            while (head is not null)
            {
                if (!visited.Add(head))
                    return true;
                
                head = head.next;
            }
            return false;
        }
    }

    [TestFixture]
    public class Tests141
    {
        [Test]
        public void Test()
        {
            //3,2,0,-4
            var head1 = new ListNode(3);
            var head2 = new ListNode(2);
            var head3 = new ListNode(0);
            var head4 = new ListNode(-4);
            head1.next = head2;
            head2.next = head3;
            head3.next = head4;
            head4.next = head2;
            var result = new Solution141().HasCycle(head1);
            Assert.AreEqual(true, result);
        }
    }


    //Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int x)
        {
            val = x;
            next = null;
        }
    }

}