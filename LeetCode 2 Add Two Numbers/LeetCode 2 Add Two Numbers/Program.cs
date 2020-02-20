using System;

namespace LeetCode_2_Add_Two_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList test1 = new LinkedList(new ListNode(1));
            LinkedList test2 = new LinkedList(new ListNode(3));
            test2.AddNodeToHead(new ListNode(9));

            ListNode answer = Solution.AddTwoNumbers(test1.head, test2.head);

            LinkedList answerList = new LinkedList(answer);
            answerList.PrintList();
        }
    }

    static public class Solution
    {
        static public int carry = 0;
        static public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            LinkedList listOne = new LinkedList(l1);
            LinkedList listTwo = new LinkedList(l2);
            LinkedList sumList = new LinkedList(null);

            ListNode pointer1 = l1;
            ListNode pointer2 = l2;

            do
            {
                sumList.AddNodeToHead(NodeSum(pointer1, pointer2));
                pointer1 = pointer1 == null ? null : pointer1.next;
                pointer2 = pointer2 == null ? null : pointer2.next;
            } while (pointer1 != null || pointer2 != null);

            return sumList.head;
        }
        static public ListNode NodeSum(ListNode a, ListNode b)
        {
            int aValue = a == null ? 0 : a.val;
            int bValue = b == null ? 0 : b.val;
            int sum = aValue + bValue + carry;
            int onesDigit = sum % 10;
            int tensDigit = sum - onesDigit;
            carry = tensDigit / 10;
            ListNode newNode = new ListNode(onesDigit);
            return newNode;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; next = null; }
    }

    public class LinkedList
    {
        public ListNode head;

        public LinkedList(ListNode node) { this.head = node; }

        public void AddNodeToHead(ListNode node)
        {
            ListNode oldHead = this.head;
            this.head = node;
            this.head.next = oldHead;
        }

        public void PrintList()
        {
            ListNode current = this.head;
            while (current != null)
            {
                Console.Write(current.val);
                current = current.next;
            }
            Console.Write("\n");
        }
    }
}
