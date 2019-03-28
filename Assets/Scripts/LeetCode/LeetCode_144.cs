using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_144 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    // Medium https://leetcode.com/problems/binary-tree-preorder-traversal/description/
    // 2018/8/1
    // 递归解法
    public IList<int> PreorderTraversal(TreeNode root) {
        List<int> result = new List<int>();
        preOrder(root, result);
        
        return result;
    }
    
    void preOrder(TreeNode root, List<int> result){
        if(root == null) return;
        
        result.Add(root.val);
        
        preOrder(root.left, result);
        preOrder(root.right, result);
    }

    // Stack solution
    public IList<int> PreorderTraversal_(TreeNode root) {
        List<int> result = new List<int>();
        
        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(root);
        while(stack.Count > 0){
            TreeNode node = stack.Pop();
            if(node == null) continue;
            result.Add(node.val);
            
            if(node.right != null) stack.Push(node.right);
            if(node.left != null) stack.Push(node.left);
        }
        
        return result;
    }
}


