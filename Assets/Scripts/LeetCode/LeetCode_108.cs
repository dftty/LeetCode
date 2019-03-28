using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_108 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Easy https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/description/
	// 2018/7/10
	// Discuss solution
	public TreeNode SortedArrayToBST(int[] nums) {
        if(nums == null || nums.Length == 0) return null;
        
        TreeNode result = Generate(nums, 0, nums.Length - 1);
        return result;
    }
    
    public TreeNode Generate(int[] nums, int low, int hi){
        if(low > hi) return null;
        
        int mid = (low + hi) / 2;
        TreeNode node = new TreeNode(nums[mid]);
        node.left = Generate(nums, low, mid - 1);
        node.right = Generate(nums, mid + 1, hi);
        return node;
    }
}
