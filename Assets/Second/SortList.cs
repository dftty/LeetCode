using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortList : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
    https://leetcode.com/problems/sort-list/

    归并排序解法
     */
    public ListNode SortList_Discuss(ListNode head) {
        if(head == null || head.next == null){
            return head;
        }
        
        ListNode pre = null, slow = head, fast = head;
        
        while(fast != null && fast.next != null){
            pre = slow;
            slow = slow.next;
            fast = fast.next.next;
        }
        
        pre.next = null;
        
        ListNode l1 = SortList_Discuss(head);
        ListNode l2 = SortList_Discuss(slow);
        
        return merge(l1, l2);
    }
    
    ListNode merge(ListNode l1, ListNode l2){
        ListNode res = new ListNode(0);
        ListNode node = res;
        while(l1 != null && l2!= null){
            if(l1.val > l2.val){
                node.next = l2;
                l2 = l2.next;
            }else{
                node.next = l1;
                l1 = l1.next;
            }
            node = node.next;
        }
        
        while(l1 != null){
            node.next = l1;
            l1 = l1.next;
            node = node.next;
        }
        
        while(l2 != null){
            node.next = l2;
            l2 = l2.next;
            node = node.next;
        }
        
        return res.next;
    }
}
