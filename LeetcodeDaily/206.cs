using NUnit.Framework;

namespace LeetCodeDaily
{
    public class Solution206
    {
        public ListNode ReverseList(ListNode head)
        {
            if (head == null)
                return head;
            var reversedList = new List<int>();
            reversedList.Add(head.val);
            while (head.next != null)
            {
                head = head.next;
                reversedList.Add(head.val);
            }

            head = new ListNode(reversedList.Last());
            var result = head;
            for (var i = reversedList.Count - 2; i >= 0; i--)
            {
                head.next = new ListNode(reversedList[i]);
                head = head.next;
            }

            return result;
        }
    }
}