using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_19 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/remove-nth-node-from-end-of-list/description/
	// 2018/6/23
	// use Dictionary one pass
	public ListNode RemoveNthFromEnd(ListNode head, int n) {
        if(head == null) return head;
        Dictionary<int, ListNode> nodes = new Dictionary<int, ListNode>();
        int index = 0;
        ListNode temp = head;
        while(temp != null){
            nodes.Add(index++, temp);
            temp = temp.next;
        }
        
        if(n - index == 0){
            head = head.next;
        }else if(n == 1){
            if(nodes.ContainsKey(index - 2)){
                nodes[index - 2].next = null;
            }else{
                head = null;
            }
        }else{
            nodes[index - n - 1].next = nodes[index - n + 1];
        }
        
        return head;
    }
}
