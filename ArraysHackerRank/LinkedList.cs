namespace ArraysHackerRank;

public class LinkedList
{
    public ListNode ReverseList(ListNode head) { //https://leetcode.com/problems/reverse-linked-list
        ListNode next = null, prev = null;
        while (head != null){
            next = head.next;
            head.next = prev;
            prev = head;
            head = next;
        }
        return prev;
    }
    
    
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) { //https://leetcode.com/problems/merge-two-sorted-lists
        ListNode final = new();
        ListNode temp = final;
        while(list1 != null && list2 != null){
            if(list1.val <= list2.val){
                temp.next = list1;
                list1 = list1.next;
            }
            else {
                temp.next = list2;
                list2 = list2.next;
            }
            temp = temp.next;
        }
        temp.next = list1 != null ? list1: list2; //Wiring it to the remaining of the notnull list.
        return final.next;
    }

    public bool HasCycle(ListNode head) { https://leetcode.com/problems/linked-list-cycle
     //The algorithm works because if the list has no cycle, the fast pointer will eventually reach null and we know there is no loop.
     //But if there is a cycle, once both pointers are inside it, the fast pointer moves two steps while the slow moves one, so the distance between them decreases by one each time.
     //Eventually the fast pointer catches up to the slow pointer, which proves there is a cycle.
        ListNode slow = head;
        ListNode fast = head;

        while (fast != null && fast.next != null) { 
            slow = slow.next;
            fast = fast.next.next;

            if (slow == fast) return true; //by the name comparison, it regards the object references not the vals, this way diff nodes containing the same vals do not cause trouble.
        }
        return false;
    }
    
    public static void ReorderList(ListNode head) { //https://leetcode.com/problems/reorder-list/
        ListNode slow = head;
        ListNode fast = head.next;
        while (fast != null && fast.next != null) {
            slow = slow.next;
            fast = fast.next.next;
        }

        ListNode second = slow.next;
        ListNode prev = slow.next = null;
        while (second != null) {
            ListNode tmp = second.next;
            second.next = prev;
            prev = second;
            second = tmp;
        }

        ListNode first = head;
        second = prev;
        while (second != null) {
            ListNode tmp1 = first.next;
            ListNode tmp2 = second.next;
            first.next = second;
            second.next = tmp1;
            first = tmp1;
            second = tmp2;
        }
    }
    
    public static ListNode RemoveNthFromEnd(ListNode head, int n) { //https://leetcode.com/problems/remove-nth-node-from-end-of-list/
        ListNode dummy = new();
        dummy.next = head;
        ListNode l = dummy, r = head;

        //First we will move r by n times so that we could keep the gap equal to n between l and r. This way, when r reaches null, we will end the loop and l will be pointing to the node intended to be removed.

        while(n-- > 0)
            r = r.next;

        while(r != null){
            r = r.next;
            l = l.next;
        }

        l.next = l.next.next;

        return dummy.next;
    }
}