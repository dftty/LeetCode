using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_25 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int depth = 0;

    // Easy https://leetcode.com/problems/maximum-depth-of-binary-tree/description/
    // 2018/7/10
    public int MaxDepth(TreeNode root) {
        if(root == null) return depth;
        Check(1, root);
        return depth;
    }
    
    void Check(int deep, TreeNode root){
        if(root == null) return ;
        if(deep > depth){
            depth = deep;
        }
        Check(++deep, root.left);
        deep--;
        Check(++deep, root.right);
        return ;
    }

    // Discuss solution
    public int MaxDepth_(TreeNode root){
        if(root == null) return 0;
        if(root.left == null && root.right == null) return 1;

        return Math.Max(MaxDepth_(root.left), MaxDepth_(root.right)) + 1;
    }
}
