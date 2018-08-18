using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_143 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		ListNode l1 = new ListNode(1);
		ListNode l2 = new ListNode(2);
		ListNode l3 = new ListNode(3);
		ListNode l4 = new ListNode(4);
		ListNode l5 = new ListNode(5);

		l1.next = l2;
		//l2.next = l3;
		//l3.next = l4;
		//l4.next = l5;
		ReorderList(l1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/reorder-list/description/
	// 2018/7/1
	// 首先计算链表长度，
	// 然后每次循环将临时头指向最后一个节点
	// O(n^2)
	public void ReorderList(ListNode head) {
        int length = 0;
        if(head == null || head.next == null) return;
        
        ListNode node = head;
        while(node != null){
            length++;
            node = node.next;
        }
        
        int index = 0;
        ListNode tempHead = head;
        while(index < length / 2){
            ListNode temp = tempHead.next;
            int nodeIndex = length - index * 2 - 2;
            node = tempHead;
            
            if(nodeIndex > 0){
                while(nodeIndex > 0){
                    node = node.next;
                    nodeIndex--;
                }

                if(node != null){
                    tempHead.next = node.next;
                    node.next = node.next.next;
                    tempHead.next.next = temp;
                    tempHead = temp;
                }
            }
            
            index++;
        }
    }

    
    // Discuss solution 
    // first, find this list's middle node
    // reverse the nodes after middle node
    // recombine list
	public void ReorderList_(ListNode head) {
        if(head == null || head.next == null) return;
        ListNode middle = head, p1 = head.next.next;
        while(p1 != null && middle != null){
            middle = middle.next;
            if(p1.next != null) {
                p1 = p1.next.next;   
            }else {
                p1 = null;   
            }
            
        }
        
        ListNode current = middle.next;
        while(current.next != null){
            ListNode currentNext = current.next;
            current.next = currentNext.next;
            currentNext.next = middle.next;
            middle.next = currentNext;
        }
        
        p1 = head;
        
        while(p1 != middle){
            current = middle.next;
            middle.next = current.next;
            current.next = p1.next;
            p1.next = current;
            p1 = current.next;
        }
        
        return ;
    }
}
