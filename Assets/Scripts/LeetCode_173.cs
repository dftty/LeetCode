using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_173 : MonoBehaviour {

    Stack<TreeNode> stack = new Stack<TreeNode>();

    TreeNode root;
    
    public LeetCode_173(TreeNode root) {
        this.root = root;
        if(this.root != null) stack.Push(root);
    }

    /** @return whether we have a next smallest number */
    public bool HasNext() {
        if(stack.Count > 0) return true;
        return false;
    }

    // Medium https://leetcode.com/problems/binary-search-tree-iterator/description/
    // 2018/8/2
    // Use stack store node
    /** @return the next smallest number */
    public int Next() {
        TreeNode node = stack.Peek();
        
        if(node.left == null && node.right == null) return stack.Pop().val;
        if(node.left == null && node.right != null) {
            TreeNode temp = stack.Pop();
            stack.Push(node.right);
            return temp.val;
        }
        
        while(node.left != null){
            TreeNode temp = node;
            node = node.left;
            stack.Push(node);
            temp.left = null;
        }
        
        return Next();
    }
}


