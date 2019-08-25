using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OddEvenLinkedList : MonoBehaviour
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
    https://leetcode.com/problems/odd-even-linked-list/
     */
    public ListNode OddEvenList(ListNode head) {
        ListNode odd = new ListNode(0);
        ListNode even = new ListNode(0);
        
        ListNode temp_odd = odd;
        ListNode temp_even = even;
        
        int count = 1;
        while(head != null){
            if (count++ % 2 == 0){
                temp_even.next = head;
                temp_even = temp_even.next;
            }else{
                temp_odd.next = head;
                temp_odd = temp_odd.next;
            }
            
            head = head.next;
        }
        
        temp_odd.next = even.next;
        temp_even.next = null;
        return odd.next;
    }
}
