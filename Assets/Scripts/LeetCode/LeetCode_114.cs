using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_114 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/flatten-binary-tree-to-linked-list/description/
	// 2018/7/25
	// DFS 从左到右递归地将左子树设置为右子树。
	public void Flatten(TreeNode root) {
        if(root == null) return;
        root = Flaten(root);
    }
    

    public TreeNode Flaten(TreeNode root){
        if(root == null) return null;
        
        TreeNode left = Flaten(root.left);
        TreeNode right = Flaten(root.right);
        if(left != null){
            root.right = left;
            while(left.right != null) left = left.right;
            left.right = right;
        }
        
        root.left = null;
        
        return root;
    }


}
