using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_116 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    /**
    Java code
    // Medium https://leetcode.com/problems/populating-next-right-pointers-in-each-node/description/
    // 2018/7/26
    // Not allow use c#
    // BFS
    public void connect(TreeLinkNode root) {
        Queue<TreeLinkNode> queue = new LinkedList<>();
        
        if(root == null) return ;
        queue.offer(root);
        
        while(queue.size() > 0){
            TreeLinkNode temp = queue.poll();
            int n = queue.size();
            
            if(temp.left != null) queue.offer(temp.left);
            if(temp.right != null) queue.offer(temp.right);
            
            for(int i = 0; i < n; i++){
                TreeLinkNode node = queue.poll();
                temp.next = node;
                temp = node;
                if(temp.left != null) queue.offer(temp.left);
                if(temp.right != null) queue.offer(temp.right);
            }
            temp.next = null;
        }
         */
         // Discuss solution
        // 从根节点开始，每层从左向右连
        public void connect(TreeLinkNode root) {
            TreeLinkNode level_start=root;
            while(level_start!=null){
                TreeLinkNode cur=level_start;
                while(cur!=null){
                    if(cur.left!=null) cur.left.next=cur.right;
                    if(cur.right!=null && cur.next!=null) cur.right.next=cur.next.left;
                    
                    cur=cur.next;
                }
                level_start=level_start.left;
            }
        }
    }

    



public class TreeLinkNode {
    public int val;
    public TreeLinkNode left, right, next;
    public TreeLinkNode(int x) { val = x; }
}
