using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseNodesinkGroup : MonoBehaviour
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
    https://leetcode.com/problems/reverse-nodes-in-k-group/

    递归算法
    其中有反转链表的方法
     */
    public ListNode ReverseKGroup(ListNode head, int k) {
        ListNode cur = head;
        int count = 0;
        
        while(cur != null && count < k){
            cur = cur.next;
            count++;
        }
        
        if(count == k){
            cur = ReverseKGroup(cur, k);
            
            while(count-- > 0){
                ListNode temp = head.next;
                head.next = cur;
                cur = head;
                head = temp;
            }
            
            head = cur;
        }
        
        return head;
    }
}
