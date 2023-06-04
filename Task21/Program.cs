namespace Task21
{
    //70. Climbing Stairs
    //You are climbing a staircase. It takes n steps to reach the top.
    //Each time you can either climb 1 or 2 steps.In how many distinct ways can you climb to the top?
    public class Program
    {
        static void Main(string[] args)
        {
            var task21 = new Solution();
            var list1 = ListNode.EnumerableToListNode(new List<int>() { 1, 2, 3, 4, 5 });
            var list2 = ListNode.EnumerableToListNode(new List<int>() { 1, 4, 8 });
            var result = task21.MergeTwoLists(list1, list2);
            Console.WriteLine(result);
        }
    }

    //Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }

        public static ListNode EnumerableToListNode(IEnumerable<int> values)
        {
            var result = new ListNode();
            var head = result;
            var i = 0;
            foreach (var v in values)
            {
                result.next = new ListNode(v);
                result = result.next;
                if (i == 0)
                {
                    head = result;
                    i++;
                }
            }
            return head;
        }
    }
    public class Solution
    {
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            var head = new ListNode(0);
            var l = head;
            while (list1 != null && list2 != null)
            {
                if (list1.val <= list2.val)
                {
                    l.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    l.next = list2;
                    list2 = list2.next;
                }
                l = l.next;
            }
            if (list1 != null)
                l.next = list1;
            if (list2 != null)
                l.next = list2;
            return head.next;
        }
    }
}