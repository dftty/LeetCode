using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveNthNodeFromEndofList : MonoBehaviour
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
    https://leetcode.com/problems/remove-nth-node-from-end-of-list/

    首先遍历一遍记录列表长度，然后再遍历一遍去掉目标值
    
    two pass
     */
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        int len = 0;
        ListNode temp = head;
        while(temp != null){
            len++;
            temp = temp.next;
        }
        
        temp = new ListNode(0);
        temp.next = head;
        len = len - n;
        ListNode node = temp;
        while(len > 0){
            len--;
            node = node.next;
        }
        
        if(node.next != null){
            node.next = node.next.next;
        }
        
        return temp.next;
    }
}
