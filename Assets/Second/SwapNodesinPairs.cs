using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapNodesinPairs : MonoBehaviour
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
    https://leetcode.com/problems/swap-nodes-in-pairs/

    创建一个ListNode指向head， 然后每次遍历两个节点，并且交换即可
     */
    public ListNode SwapPairs(ListNode head) {
        if(head == null) return null;
        ListNode res = new ListNode(0);
        ListNode node = res;
        
        res.next = head;
        while(node.next != null && node.next.next != null){
            ListNode temp = node.next;
            node.next = node.next.next;
            temp.next = node.next.next;
            node.next.next = temp;
            
            node = node.next.next;
        }
        
        return res.next;
    }
}
