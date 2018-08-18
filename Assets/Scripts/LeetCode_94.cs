using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_94 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Easy https://leetcode.com/problems/binary-tree-inorder-traversal/description/
    // 2018/7/12
    // 中序遍历
    public IList<int> InorderTraversal(TreeNode root) {
        IList<int> result = new List<int>();
        return InOrder(result, root);
    }
    
    public IList<int> InOrder(IList<int> temp, TreeNode root){
        if(root == null) return temp;
        
        if(root.left != null) InOrder(temp, root.left);
        temp.Add(root.val);
        if(root.right != null) InOrder(temp, root.right);
        return temp;
    }



    // 不使用递归，使用stack来实现
    public IList<int> InorderTraversal_(TreeNode root) {
        IList<int> result = new List<int>();
        
        Stack<TreeNode> stack = new Stack<TreeNode>();
        while(root != null){
            if(root.left == null){
                if(root.right == null){
                    result.Add(root.val);
                    if(stack.Count > 0){
                        root = stack.Pop();
                        root.left = null;
                    }else{
                        root = null;
                    }
                }else{
                    result.Add(root.val);
                    root = root.right;
                }
                continue;
            }
            stack.Push(root);
            root = root.left;
        }
        return result;
    }



    // Discuss Iteratively 
    // More Clearly
    public IList<int> InorderTraversal__(TreeNode root) {
        IList<int> result = new List<int>();
        
        Stack<TreeNode> stack = new Stack<TreeNode>();
        while(root != null || stack.Count > 0){
            while(root != null){
                stack.Push(root);
                root = root.left;
            }

            root = stack.Pop();
            result.Add(root.val);
            root = root.right;
        }
        return result;
    }
    
}
