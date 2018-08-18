using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_129 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/sum-root-to-leaf-numbers/description/
	// 2018/7/28
	// DFS
	int result = 0;
    public int SumNumbers(TreeNode root) {
        Compute(root, new List<int>());
        return result;
    }
    
    public void Compute(TreeNode root, List<int> nums){
        if(root == null) return ;
        
        if(root.left == null && root.right == null){
            nums.Add(root.val);
            for(int i = 0; i < nums.Count; i++){
                int tmp = 1;
                for(int j = 0; j < nums.Count - i - 1; j++) tmp *= 10;
                result += nums[i] * tmp;
            }
            return ;
        }
        
        nums.Add(root.val);
        
        Compute(root.left, nums);
        if(root.left != null && nums.Count > 0) nums.RemoveAt(nums.Count - 1);
        Compute(root.right, nums);
        if(root.right != null && nums.Count > 0) nums.RemoveAt(nums.Count - 1);
        
        return ;
    }


	// Discuss solution
	// 递归算法，在每层进去时，将当前层乘10。
	public int sumNumbers(TreeNode root) {
		return sum(root, 0);
	}

	public int sum(TreeNode n, int s){
		if (n == null) return 0;
		if (n.right == null && n.left == null) return s*10 + n.val;
		return sum(n.left, s*10 + n.val) + sum(n.right, s*10 + n.val);
	}

}
