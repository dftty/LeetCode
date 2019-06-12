using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class AddTwoNumbers : MonoBehaviour {

	// Use this for initialization
	void Start () {
		ListNode l1 = new ListNode(2);
		ListNode l1_1 = new ListNode(4);
		ListNode l1_2 = new ListNode(3);
		l1.next = l1_1;
		l1_1.next = l1_2;

		ListNode l2 = new ListNode(5);
		ListNode l2_1 = new ListNode(6);
		ListNode l2_2 = new ListNode(4);
		l2.next = l2_1;
		l2_1.next = l2_2;
		AddTwoNumber(l1, l2);
		char c = '1';
		int temp = c - '0';

		int[][] arr = new int[1][];
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	https://leetcode.com/problems/add-two-numbers/
	Add Two Numbers
	You are given two non-empty linked lists representing two non-negative integers. 
	The digits are stored in reverse order and each of their nodes contain a single digit.
	Add the two numbers and return it as a linked list.

	You may assume the two numbers do not contain any leading zero, except the number 0 itself.

	StringBuilder 调用append方法添加非char和string类型时，会调用该类型的ToString方法
	char c = '1';
	int temp = c - '0';
	char类型转为int类型时，需要减去 '0' 
	 */
	public ListNode AddTwoNumber(ListNode l1, ListNode l2) {
        StringBuilder sb1 = new StringBuilder();
        StringBuilder sb2 = new StringBuilder();
		
        
        while(l1 != null){
            sb1.Append(l1.val);
            l1 = l1.next;
        }
        
        while(l2 != null){
            sb2.Append(l2.val);
            l2 = l2.next;
        }
        int n = 0;
        int m = 0;
        int temp = 0;
        ListNode root = new ListNode(0);
        ListNode node = root;
        while(m < sb1.Length || n < sb2.Length){
            if(m < sb1.Length) temp += sb1[m++] - '0';
            if(n < sb2.Length) temp += sb2[n++] - '0';
            node.next = new ListNode(temp % 10);
            node = node.next;
            temp = temp / 10;
        }
        
        if(temp != 0){
            node.next = new ListNode(temp);
        }
        
        return root.next;
    }

	/**
	其实并不需要stringbuilder， 直接判断链表是否为空即可
	 */
	public ListNode AddTwoNumber_(ListNode l1, ListNode l2) {
        int temp = 0;
        ListNode root = new ListNode(0);
        ListNode node = root;
        while(l1 != null || l2 != null){
            if(l1 != null) {
				temp += l1.val;
				l1 = l1.next;
			}
            if(l2 != null){
				temp += l2.val;
				l2 = l2.next;
			} 
            node.next = new ListNode(temp % 10);
            node = node.next;
            temp = temp / 10;
        }
        
        if(temp != 0){
            node.next = new ListNode(temp);
        }
        
        return root.next;
    }

	public class ListNode {
		public int val;
		public ListNode next;
		public ListNode(int x) { val = x; }
	}
}
