using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_142 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/linked-list-cycle-ii/description/
	// 2018/6/30
	// use dictionary
	public ListNode DetectCycle(ListNode head) {
        Dictionary<ListNode, int> temp = new Dictionary<ListNode, int>();
        
        int index = 0;
        ListNode node = head;
        while(node != null){
            if(temp.ContainsKey(node)) return node;
			temp.Add(node, index++);
            node = node.next;
        }
        
        return null;
    }

	// Discuss solution, use two pointers
    // first point jump 1 node each loop, second point jump 2 node each loop
    // Error been Made: after this loop, forget to check if second pointer point to null
	public ListNode DetectCycle_(ListNode head) {
        if(head == null || head.next == null) return null;
        ListNode first = head,second = head;
        while(first != null && second.next.next != null){
            first = first.next;
            second = second.next.next;
            
            if(second.next == null) return null;
            
            if(first == second) {
                break;
            }
        }
        
        if(second.next == null || second.next.next == null) return null;
        
        first = head;
        while(first != second){
            first = first.next;
            second = second.next;
        }
        
        return first;
    }
}
