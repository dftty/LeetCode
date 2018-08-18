using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_124 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int?[] array = new int?[]{-622,-37,90,567,-516,832,-487,-59,953,null,436,-174,130,null,-330,null,253,-211,-648,null,null,-524,null,-428,-245,717,-742};
	
		Queue<TreeNode> node = new Queue<TreeNode>();
		TreeNode root = new TreeNode(-622);
		node.Enqueue(root);
		int index = 1;
		while(node.Count > 0 && index < array.Length){
			int n = node.Count;
			for(int i = 0; i < n; i++){
				TreeNode temp = node.Dequeue();
				if(index >= array.Length) break;
				if(array[index].HasValue){
					TreeNode left = new TreeNode(array[index].Value);
					node.Enqueue(left);
					temp.left = left;
				}else {
					temp.left = null;
				}
				index++;
				if(index >= array.Length) break;
				if(array[index].HasValue){
					TreeNode right = new TreeNode(array[index].Value);
					node.Enqueue(right);
					temp.right = right;
				}else{
					temp.right = null;
				}
				index++;
			}
		}

		MaxPathSum(root);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    int result = int.MinValue;

	// Hard https://leetcode.com/problems/binary-tree-maximum-path-sum/description/
	// 2018/8/4
	// 递归计算每个子节点最大和
    public int MaxPathSum(TreeNode root) {
        Find(root);
        return result;
    }
    
    public int Find(TreeNode root){
        if(root == null) return 0;
        
        int left = Find(root.left);
        int right = Find(root.right);
        
        int sum = 0;    
		
		// 这里判断该节点的路径和是否是当前最大和
        if(left > 0 && right > 0){
            sum = root.val + left + right;
            result = Math.Max(sum , result);
            sum = 0;
        }
        
		// 这里选择最大数
        sum = Math.Max(left, right);
        
		// 如果sum小于0，则该节点的左右节点都无需计算
        if(sum > 0){
            sum += root.val;
            result = Math.Max(result, sum);
            result = Math.Max(result, left);
            result = Math.Max(result, right);
            result = Math.Max(result, root.val);
            return sum;
        }
        
        result = Math.Max(result, root.val);
        return root.val;
    }

	// Discuss solution, same idea , but clean code
	int maxValue = int.MinValue;
	private int maxPathDown(TreeNode node) {
        if (node == null) return 0;
        int left = Math.Max(0, maxPathDown(node.left));
        int right = Math.Max(0, maxPathDown(node.right));
        maxValue = Math.Max(maxValue, left + right + node.val);
        return Math.Max(left, right) + node.val;
    }
}
