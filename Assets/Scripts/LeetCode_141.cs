using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_141 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Easy https://leetcode.com/problems/linked-list-cycle/description/
	// 2018/6/30
	public bool HasCycle(ListNode head) {
        while(head != null && head.next != null){
            if(head == head.next) return true;
            head.next = head.next.next;
            head = head.next;
        }
        return false;
    }
}
