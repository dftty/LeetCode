using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_109 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/convert-sorted-list-to-binary-search-tree/description/
	// 2018/7/19
	// Discuss solution 
	// Use Recursion
	public TreeNode SortedListToBST(ListNode head) {
        if(head == null) return null;
        return Generate(head, null);
    }
    
    public TreeNode Generate(ListNode head, ListNode tail){
        ListNode fast = head;
        ListNode slow = head;
        
        if(head == tail) return null;
        while(fast != tail && fast.next != tail){
            fast = fast.next.next;
            slow = slow.next;
        }
        
        TreeNode node = new TreeNode(slow.val);
        node.left = Generate(head, slow);
        node.right = Generate(slow.next, tail);
        
        return node;
    }


	private ListNode node;

	// Another solution
	public TreeNode sortedListToBST(ListNode head) {
		if(head == null){
			return null;
		}
		
		int size = 0;
		ListNode runner = head;
		node = head;
		
		while(runner != null){
			runner = runner.next;
			size ++;
		}
		
		return inorderHelper(0, size - 1);
	}

	public TreeNode inorderHelper(int start, int end){
		if(start > end){
			return null;
		}
		
		int mid = start + (end - start) / 2;
		TreeNode left = inorderHelper(start, mid - 1);
		
		TreeNode treenode = new TreeNode(node.val);
		treenode.left = left;
		node = node.next;

		TreeNode right = inorderHelper(mid + 1, end);
		treenode.right = right;
		
		return treenode;
	}
}
