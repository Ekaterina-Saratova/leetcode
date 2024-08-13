using NUnit.Framework;

namespace Grind75
{
    //Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode? next;

        public ListNode(int val = 0, ListNode? next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Solution21
    {
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list2 == null)
                return list1;
            if (list1 == null)
                return list2;

            var result = new ListNode();
            var result1 = result;

            while (list1 != null && list2 != null)
            {
                if (list1.val < list2.val)
                {
                    result.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    result.next = list2;
                    list2 = list2.next;
                }
                result = result.next;
            }

            if (list1 != null)
                result.next = list1;
            if (list2 != null)
                result.next = list2;

            return result1.next;
        }
    }

    [TestFixture]
    public class Tests21
    {
        [Test]
        public void ReturnTrue()
        {
            var list1 = new ListNode(1, new ListNode(2, new ListNode(4, null)));
            var list2 = new ListNode(1, new ListNode(3, new ListNode(4, null)));
            var result = new Solution21().MergeTwoLists(list1, list2);
            var expected = new ListNode(1,
                new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(4, null))))));
        }
    }
}

