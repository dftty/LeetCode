using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_24 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/swap-nodes-in-pairs/description/
	// 2018/6/24
	//
    public ListNode SwapPairs(ListNode head) {
        if(head == null || head.next == null) return head;
        ListNode temp = null;
        ListNode first = head;
        ListNode second = head.next;
        ListNode currentHead = null;
        
        if(first != null && second != null){
            head = second;
            first.next = second.next;
            second.next = first;
            currentHead = first;
            temp = first.next;
        }
        
        while(temp != null){
            first = temp;
            second = temp.next;
            if(first != null && second != null){
                currentHead.next = second;
                first.next = second.next;
                second.next = first;
                currentHead = first;
                temp = first.next;
            }else{
                temp = temp.next;
            }
        }
        
        return head;
    }

	// Discuss solution 
	// 递归
	public ListNode swapPairs(ListNode head) {
        if ((head == null)||(head.next == null))
            return head;
        ListNode n = head.next;
        head.next = swapPairs(head.next.next);
        n.next = head;
        return n;
    }
}
