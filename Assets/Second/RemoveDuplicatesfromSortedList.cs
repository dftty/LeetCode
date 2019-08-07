using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveDuplicatesfromSortedList : MonoBehaviour
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
    https://leetcode.com/problems/remove-duplicates-from-sorted-list/
     */
    public ListNode DeleteDuplicates(ListNode head) {
        if(head == null){
            return null;
        }
        
        ListNode node = head;
        int val = node.val;
        
        while(node != null){
            ListNode temp = node.next;
            while(temp != null && temp.val == val){
                temp = temp.next;
            }
            
            node.next = temp;
            node = node.next;
            if(node != null){
                val = node.val;
            }
        }
        
        return head;
    }
}
