using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_61 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/rotate-list/description/
	// 2018/6/26
	// First, count list length, then use k mod length 
	public ListNode RotateRight(ListNode head, int k) {
        if(head == null || head.next == null) return head;
        int len = 1;
        ListNode temp = head;
        while(temp.next != null){
            len++;
            temp = temp.next;
        }
        
        k = k % len;
        ListNode middle = head;
        for(int i = 0; i < len - k - 1; i++){
            middle = middle.next;
        }
        
        temp.next = head;
        head = middle.next;
        middle.next = null;
        return head;
    }
}
