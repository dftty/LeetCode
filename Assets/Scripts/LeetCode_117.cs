using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_117 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    // Medium https://leetcode.com/problems/populating-next-right-pointers-in-each-node-ii/description/
    // 2018/7/27
    //   java code
    // 类似116 但不是完全二叉树，因此需要自己去寻找左右节点，然后连接
    public void connect(TreeLinkNode root) {
        TreeLinkNode start = root;
        TreeLinkNode cur = root;
        while(start != null){
            cur = start;
            TreeLinkNode curLink = FindN(cur, null);
            while(curLink != null){
                TreeLinkNode n = FindN(cur, curLink);
                curLink.next = n;
                curLink = n;
            }
            
            start = FindNextLevel(start);
        }
    }

    public TreeLinkNode FindN(TreeLinkNode cur, TreeLinkNode left){
        TreeLinkNode result = null;
        while(cur != null){
            if(cur.left != null && cur.left.next == null && cur.left != left) return cur.left;
            if(cur.right != null && cur.right.next == null && cur.right != left) {
                result = cur.right;
                cur = cur.next;
                return result;
            }
            cur = cur.next;
        }
        return null;
    }

    public TreeLinkNode FindNextLevel(TreeLinkNode node){
        while(node != null){
            if(node.left != null) return node.left;
            if(node.right != null) return node.right;
            node = node.next;
        }
        return null;
    }

    // Discuss solution
    public void connect_(TreeLinkNode root) {
        if (root == null) return;
        TreeLinkNode curP = root;
        TreeLinkNode nextDummyHead = new TreeLinkNode(0);
        TreeLinkNode p = nextDummyHead;
        while (curP != null) {
            if (curP.left != null) {
                p.next = curP.left;
                p = p.next;
            }
            if (curP.right != null) {
                p.next = curP.right;
                p = p.next;
            }
            if (curP.next != null) {
                curP = curP.next;
            }
            else {
                curP = nextDummyHead.next;
                nextDummyHead.next = null;
                p = nextDummyHead;
            }
        }
    }

}


