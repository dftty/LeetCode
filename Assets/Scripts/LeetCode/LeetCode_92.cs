using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_92 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Medium https://leetcode.com/problems/reverse-linked-list-ii/description/
    // 2018/6/27
    // use dictionary
	public ListNode ReverseBetween(ListNode head, int m, int n) {
        ListNode result = new ListNode(0);
        result.next = head;
        int index = 0;
        int reverseIndex = 0;
        Dictionary<int, ListNode> reverse = new Dictionary<int, ListNode>();
        ListNode temp = result;
        ListNode left = result;
        ListNode end = null;
        while(temp != null && index <= n){
            if(m == (index + 1)) left = temp;
            if(n == index) end = temp.next;
            if(index >= m){
                reverse.Add(reverseIndex++, temp);
            }
            index++;
            temp = temp.next;
        }
        
        for(int i = reverse.Count - 1; i >= 0; i--){
            left.next = reverse[i];
            left = left.next;
        }
        
        left.next = end;
        return result.next;
    }

    public ListNode ReverseBetween_(ListNode head, int m, int n) {
        if(head == null) return null;
        ListNode dummy = new ListNode(0); // create a dummy node to mark the head of this list
        dummy.next = head;
        ListNode pre = dummy; // make a pointer pre as a marker for the node before reversing
        for(int i = 0; i<m-1; i++) pre = pre.next;
        
        ListNode start = pre.next; // a pointer to the beginning of a sub-list that will be reversed
        ListNode then = start.next; // a pointer to a node that will be reversed
        
        // 1 - 2 -3 - 4 - 5 ; m=2; n =4 ---> pre = 1, start = 2, then = 3
        // dummy-> 1 -> 2 -> 3 -> 4 -> 5
        
        for(int i=0; i<n-m; i++)
        {
            start.next = then.next;
            then.next = pre.next;
            pre.next = then;
            then = start.next;
        }
        
        // first reversing : dummy->1 - 3 - 2 - 4 - 5; pre = 1, start = 2, then = 4
        // second reversing: dummy->1 - 4 - 3 - 2 - 5; pre = 1, start = 2, then = 5 (finish)
        
        return dummy.next;
    }
}
