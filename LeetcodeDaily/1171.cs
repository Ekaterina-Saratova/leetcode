using NUnit.Framework;

namespace LeetCodeDaily
{
    public class Solution1171
    {
        public ListNode1171 RemoveZeroSumSublists(ListNode1171 head)
        {
            var list = new List<ListNode1171>();
            while (head != null)
            {
                list.Add(head);
                head = head.next;
            }

            var sumWasFound = true;
            while (sumWasFound)
            {
                var visited = new Dictionary<int, int>();
                var start = -1;
                var end = -1;
                for (var i = 0; i < list.Count; i++)
                {
                    foreach (var v in visited)
                    {
                        if (v.Value + list[i].val == 0)
                        {
                            start = v.Key;
                            end = i;
                            break;
                        }

                        visited[v.Key] += list[i].val;
                    }
                    visited.Add(i, list[i].val);
                    if (start != -1)
                        break;
                }
                if (start != -1)
                    list.RemoveRange(start, end - start + 1);
                else
                    sumWasFound = false;
            }

            if (list.Count == 0)
                return null;
            var newHead = list[0];
            newHead.next = null;
            var result = newHead;
            for (var i = 1; i < list.Count; i++)
            {
                newHead.next = list[i];
                newHead = list[i];
            }

            return result;
        }
    }

    [TestFixture]
    public class Tests1171
    {
        [Test]
        public void Test()
        {
            //1,2,3,-3,4
            var node1 = new ListNode1171(1);
            var node2 = new ListNode1171(-1);
            //var node3 = new ListNode1171(3);
            //var nodeM3 = new ListNode1171(-3);
            //var nodeM2 = new ListNode1171(-2);
            //var node4 = new ListNode1171(4);
            node1.next = node2;
            //node3.next = nodeM3;
            //nodeM3.next = nodeM2;
            //nodeM2.next = node4;

            var result = new Solution1171().RemoveZeroSumSublists(node1);
        }
    }

 // Definition for singly-linked list.
     public class ListNode1171
     {
     public int val;
     public ListNode1171 next;

     public ListNode1171(int val = 0, ListNode1171 next = null)
     {
         this.val = val;
         this.next = next;
     }
 }

}