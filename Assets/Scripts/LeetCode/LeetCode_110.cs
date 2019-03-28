using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_110 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    bool check = true;
    // Easy https://leetcode.com/problems/balanced-binary-tree/description/
    // 2018/7/11
    public bool IsBalanced(TreeNode root) {
        Balance(root);
        return check;
    }
    
    public int Balance(TreeNode root){
        if(root == null) return 0;
        
        int left = Balance(root.left);
        int right = Balance(root.right);
        
        if(Math.Abs(left - right) > 1){
            check = false;
        }
        
        return Math.Max(left, right) + 1;
    }


    // Best time solution
    public bool IsBalanced_(TreeNode root)
    {
        if(root == null)
        {
            return true;
        }
        var left = Depth(root.left);
        var right = Depth(root.right);

        if(Math.Abs(left - right) > 1)
        {
            return false;
        }
        return IsBalanced_(root.left) && IsBalanced_(root.right);
    }

    private int Depth(TreeNode root)
    {
        if(root == null)
        {
            return 0;
        }
        return Math.Max(Depth(root.left), Depth(root.right)) + 1;
    }


}
