using NUnit.Framework;

namespace LeetCodeDaily
{
    public class Solution876
    {
        public ListNode MiddleNodeList(ListNode head)
        {
            var visited = new List<ListNode>();

            while (head is not null)
            {
                visited.Add(head);
                head = head.next;
            }

            var count = visited.Count;
            return visited[count/2];
        }

        public ListNode MiddleNodePointers(ListNode head)
        {
            var slow = head;

            while (true)
            {
                if (head?.next == null)
                    return slow;
                head = head.next.next;
                slow = slow.next;
            }
        }
}

    [TestFixture]
    public class Test876
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
            //head4.next = head2;
            var result = new Solution876().MiddleNodeList(head1);
            Assert.AreEqual(head3.val, result.val);
        }
    }
}