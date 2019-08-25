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

    归并排序解法 需要O(lgn)空间
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

    /**
    O(1)空间解法，使用自底向上归并排序
     */
    public ListNode SortList_Dis(ListNode head) {
        if (head == null || head.next == null) {
            return head;
        }
        
        int length = 0;
        ListNode node = head;
        while(node != null){
            length++;
            node = node.next;
        }
        
        node = new ListNode(int.MinValue);
        node.next = head;
        ListNode left, right, tail;
        
        for (int step = 1; step < length; step <<= 1){
            ListNode cur = node.next;
            tail = node;
            
            while (cur != null){
                left = cur;
                right = split(left, step);
                cur = split(right, step);
                tail = merge(left, right, tail);
            }
        }
        
        return node.next;
    }
    
    ListNode split(ListNode head, int n){
        for (int i = 1; i < n && head != null; i++){
            head = head.next;
        }
        
        if (head == null){
            return null;
        }
        
        ListNode res = head.next;
        head.next = null;
        return res;
    }
    
    ListNode merge(ListNode l1, ListNode l2, ListNode head){
        ListNode cur = head;
        while (l1 != null && l2 != null){
            if (l1.val > l2.val){
                cur.next = l2;
                l2 = l2.next;
            }else{
                cur.next = l1;
                l1 = l1.next;
            }
            cur = cur.next;
        }
        
        cur.next = l1 == null ? l2 : l1;
        while(cur.next != null){
            cur = cur.next;
        }
        
        return cur;
    }
}
