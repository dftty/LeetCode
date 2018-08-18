using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_112 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool isEqual = false;
    // Easy https://leetcode.com/problems/path-sum/description/
    // 2018/7/11
    public bool HasPathSum(TreeNode root, int sum) {
        return Has(root, 0, sum);
    }
    
    public bool Has(TreeNode root, int result, int sum){
        if(root == null) return false;
        if(root.left == null && root.right == null && (result + root.val) == sum)return true;
        return Has(root.left, result + root.val, sum) || Has(root.right, result + root.val, sum);
    }


    // Discuss Solution
    public bool HasPathSum_(TreeNode root, int sum){
        if(root == null) return false;
        if(root.left == null && root.right == null && sum - root.val == 0) return true;
        return HasPathSum_(root.left, sum - root.val) || HasPathSum_(root.right, sum - root.val);
    }


}
