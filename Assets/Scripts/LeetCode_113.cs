using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_113 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/path-sum-ii/description/
	// 2018/7/20
	// 中序遍历
	public IList<IList<int>> PathSum(TreeNode root, int sum) {
        IList<IList<int>> result = new List<IList<int>>();
        
        if(root == null) return result;
        List<int> list = new List<int>();
        
        Check(root, result, sum, list, root.val);
        return result;
    }
    
    void Check(TreeNode root, IList<IList<int>> result, int sum, List<int> stack, int count){
        stack.Add(root.val);
        if(root.left == null && root.right == null && count == sum){
            result.Add(new List<int>(stack));
        }
        
        if(root.left != null){
            Check(root.left, result, sum, stack, count + root.left.val);
            if(stack.Count > 0) stack.RemoveAt(stack.Count - 1);
        } 
        
        if(root.right != null){
            Check(root.right, result, sum, stack, count + root.right.val);
            if(stack.Count > 0) stack.RemoveAt(stack.Count - 1);
        }
    }
}
