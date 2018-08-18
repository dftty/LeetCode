using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_101 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Easy https://leetcode.com/problems/symmetric-tree/description/
	// 2018/7/9
	// 
	public bool IsSymmetric(TreeNode root) {
        return Check(root, root);
    }
    
    public bool Check(TreeNode left, TreeNode right){
        if(left == null && right == null) return true;
        if(left == null || right == null) return false;
        
        if(left.val == right.val){
            return Check(left.left, right.right) && Check(left.right, right.left);
        }
        
        return false;
    }
}
