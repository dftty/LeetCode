using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateList : MonoBehaviour
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
    https://leetcode.com/problems/rotate-list/

    
     */
    public ListNode RotateRight(ListNode head, int k) {
        if(head == null) return null;
        int len = 0;
        ListNode node = head;
        while(node != null){
            len++;
            node = node.next;
        }
        
        k = len - k % len;
        
        if(k == 0 || k == len) return head;
        
        node = head;
        while(k-- > 1){
            node = node.next;
        }
        
        ListNode temp = node.next;
        node.next = null;
        node = temp;
        while(node != null){
            if(node.next == null){
                node.next = head;
                break;
            }
            
            node = node.next;
        }
        
        return temp;
    }
}
