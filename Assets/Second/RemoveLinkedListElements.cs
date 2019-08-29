using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveLinkedListElements : MonoBehaviour
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
    https://leetcode.com/problems/remove-linked-list-elements/
     */
    public ListNode RemoveElements(ListNode head, int val) {
        ListNode res = new ListNode(0);
        res.next = head;
        ListNode node = res;
        while(node.next != null){
            if(node.next.val == val){
                node.next = node.next.next;
            }else{
                node = node.next;
            }
        }
        return res.next;
    }
}
