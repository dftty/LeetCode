using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_160 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Easy https://leetcode.com/problems/intersection-of-two-linked-lists/description/
	// Use Dictionary
	public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
        Dictionary<ListNode, int> nodes = new Dictionary<ListNode, int>();
        ListNode temp = headA;
        int index = 0;
        while(temp != null){
            nodes.Add(temp, index++);
            temp = temp.next;
        }
        
        temp = headB;
        while(temp != null){
            if(nodes.ContainsKey(temp)){
                return temp;
            }
			temp = temp.next;
        }
        
        return null;
    }

	// Discuss solution 
	public ListNode getIntersectionNode_Diss(ListNode headA, ListNode headB) {
    //boundary check
    if(headA == null || headB == null) return null;
    
    ListNode a = headA;
    ListNode b = headB;
    
    //if a & b have different len, then we will stop the loop after second iteration
    while( a != b){
    	//for the end of first iteration, we just reset the pointer to the head of another linkedlist
        a = a == null? headB : a.next;
        b = b == null? headA : b.next;    
    }
    
    return a;
}
}
