using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

public class LeetCode_105 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		TreeNode node = BuildTree(new int[]{3,9,20,15,7}, new int[]{9,3,15,20,7});
		PreOrder(node);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/description/
	// 2018/3/19
	public TreeNode BuildTree(int[] preorder, int[] inorder) {
        if(preorder == null || preorder.Length == 0) return null;
		int index = 0;
        TreeNode result = GenerateLeft(preorder, inorder, 0, preorder.Length - 1, ref index);
		return result;
	}

	TreeNode GenerateLeft(int[] preorder, int[] inorder, int start, int end, ref int index){
		if(start > end) return null;
		int middle = int.MinValue;
		for(int i = start; i <= end; i++){
			if(preorder[index] == inorder[i]){
				middle = i;
				break;
			}
		}

		if(middle == int.MinValue) return null;
		//Debug.Log(index);
		TreeNode node = new TreeNode(preorder[index++]);
		node.left = GenerateLeft(preorder, inorder, start, middle - 1, ref index);
		node.right = GenerateLeft(preorder, inorder, middle + 1, end, ref index);

		return node;
	}

	void PreOrder(TreeNode roots){
		Debug.Log(roots.val);

		if(roots.left != null) PreOrder(roots.left);
		if(roots.right != null) PreOrder(roots.right);
	}
}

 public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}
