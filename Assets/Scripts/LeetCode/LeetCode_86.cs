using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LeetCode_86 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Medium https://leetcode.com/problems/partition-list/description/
    // 2018/6/26
    // 先循环到最近的小于x的node处，然后向后循环，找到小于x的数插入当前位置。
	public ListNode Partition(ListNode head, int x) {
        if(head == null || head.next == null) return head;
        ListNode result = new ListNode(-1);
        result.next = head;
        ListNode insert = result;
        
        while(insert.next != null && insert.next.val < x){
            insert = insert.next;
        }
        
        ListNode temp = insert;
        while(temp != null && temp.next != null){
            if(temp.next.val < x){
                ListNode insertNext = insert.next;
                insert.next = temp.next;
                temp.next = insert.next.next;
                insert.next.next = insertNext;
                insert = insert.next;
            }else{
                temp = temp.next;
            }
        }
    
        return result.next;
    }
}
