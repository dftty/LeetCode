using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_199 : MonoBehaviour {

    // Medium https://leetcode.com/problems/binary-tree-right-side-view/description/
    // 2018/8/2
    // DFS
    public IList<int> RightSideView(TreeNode root) {
        List<int> result = new List<int>();
        Deep(root, result, 0);
        
        return result;
    }
    
    public void Deep(TreeNode root, List<int> result, int deep){
        if(root == null) return;
        
        if(deep >= result.Count) result.Add(root.val);
        else result[deep] = root.val;
        
        Deep(root.left, result, deep + 1);
        Deep(root.right, result, deep + 1);
    }

    // Discuss solution 
    // Search From right to left
    public List<int> rightSideView(TreeNode root) {
        List<int> result = new List<int>();
        rightView(root, result, 0);
        return result;
    }
    
    public void rightView(TreeNode curr, List<int> result, int currDepth){
        if(curr == null){
            return;
        }
        if(currDepth == result.Count){
            result.Add(curr.val);
        }
        
        rightView(curr.right, result, currDepth + 1);
        rightView(curr.left, result, currDepth + 1);
        
    }

}


