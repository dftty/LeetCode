using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_148 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/sort-list/description/
	// 2018/7/2
	// Discuss solution Divide and Conquer
	public ListNode SortList(ListNode head) {
        if(head == null || head.next == null) return head;
        
        ListNode h1 = head, middle;
        middle = head.next.next;
        while(h1 != null && middle != null){
            h1 = h1.next;
            if(middle.next == null) break;
            middle = middle.next.next;
        }

        ListNode l2 = h1.next;
        h1.next = null;
        
        ListNode left = SortList(head);
        ListNode right = SortList(l2);
        
        return Merge(left, right);
    }
    
    public ListNode Merge(ListNode left, ListNode right){
        ListNode result = new ListNode(0);
        ListNode node = result;
        while(left != null || right != null){
            ListNode temp = new ListNode(0);
            if(left != null && right != null){
                if(left.val > right.val){
                    temp.val = right.val;
                    right = right.next;
                }else{
                    temp.val = left.val;
                    left = left.next;
                }
                node.next = temp;
            }else if(left != null){
                temp.val = left.val;
                left = left.next;
            }else{
                temp.val = right.val;
                right = right.next;
            }
            node.next = temp;
            node = temp;
        }
        
        return result.next;
    }
}
