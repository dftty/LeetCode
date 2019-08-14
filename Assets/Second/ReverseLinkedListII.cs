using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseLinkedListII : MonoBehaviour
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
    https://leetcode.com/problems/reverse-linked-list-ii/

    反转中间链表，然后前后连接
     */
    public ListNode ReverseBetween(ListNode head, int m, int n) {
        ListNode res = new ListNode(0);
        res.next = head;
        
        int reverseCount = n - m + 1;
        
        if(reverseCount == 1){
            return res.next;
        }
        
        ListNode reverseHead = res;
        while(m-- > 1){
            reverseHead = reverseHead.next;
        }
        
        ListNode reverseTail = reverseHead.next;
        ListNode tail = null;
        
        ListNode node = reverseHead.next;
        ListNode cur = null;
        while(reverseCount-- > 0){
            if(reverseCount == 0){
                tail = node.next;
            }
            
            ListNode temp = node.next;
            node.next = cur;
            cur = node;
            node = temp;
        }
        
        reverseHead.next = cur;
        reverseTail.next = tail;
        
        return res.next;
    }


    /**
    Discuss 解法，只用了四个ListNode指针
     */
    public ListNode ReverseBetween_(ListNode head, int m, int n) {
        ListNode res =  new ListNode(0);
        res.next = head;
        
        ListNode pre = res;
        for (int i = 0; i < m - 1; i++)
        {
            pre = pre.next;    
        }
        
        ListNode start = pre.next;
        ListNode then = start.next;
        
        for (int i = 0; i < n - m; i++)
        {
            start.next = then.next;
            then.next = pre.next;
            pre.next = then;
            then = start.next;
        }
        
        return res.next;
    }
}
