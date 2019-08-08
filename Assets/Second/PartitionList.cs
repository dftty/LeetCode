using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartitionList : MonoBehaviour
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
    https://leetcode.com/problems/partition-list/

    分割列表，创建两个链表即可
     */
    public ListNode Partition(ListNode head, int x) {
        ListNode res = new ListNode(0);
        
        ListNode maxNode = new ListNode(0);
        ListNode maxNodeHead = maxNode;
        ListNode minNode = res;
        ListNode node = head;
        
        while(node != null){
            if(node.val >= x){
                maxNode.next = node;
                maxNode = maxNode.next;
            }else{
                minNode.next = node;
                minNode = minNode.next;
            }
            node = node.next;
            
            maxNode.next = null;
            minNode.next = null;
        }
        
        minNode.next = maxNodeHead.next;
        
        return res.next;
    }
}
