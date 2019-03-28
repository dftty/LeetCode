using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_21 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Easy https://leetcode.com/problems/merge-two-sorted-lists/description/
	// 2018/6/21
	public ListNode MergeTwoLists(ListNode l1, ListNode l2) {
        ListNode root = new ListNode(0);
        ListNode node = root;
        
        while(l1 != null || l2 != null){
            if(l1 == null){
                ListNode temp = new ListNode(l2.val);
                node.next = temp;
                node = temp;
                l2 = l2.next;
            }else if(l2 == null){
                ListNode temp = new ListNode(l1.val);
                node.next = temp;
                node = temp;
                l1 = l1.next;
            }else{
                if(l1.val > l2.val){
                    ListNode temp = new ListNode(l2.val);
                    node.next = temp;
                    node = temp;
                    l2 = l2.next;
                }else{
                    ListNode temp = new ListNode(l1.val);
                    node.next = temp;
                    node = temp;
                    l1 = l1.next;
                }
            }
        }
        
        return root.next; 
    }
}

public class ListNode {
     public int val;
     public ListNode next;
     public ListNode(int x) { val = x; }
 }
