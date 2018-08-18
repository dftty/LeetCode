using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_106 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		TreeNode node = BuildTree(new int[]{9,3,15,20,7}, new int[]{9,15,7,20,3});
		PreOrder(node);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/construct-binary-tree-from-inorder-and-postorder-traversal/description/
	// 2018/3/19
	public TreeNode BuildTree(int[] inorder, int[] postorder) {
		if(inorder == null || inorder.Length == 0) return null;
		int index = inorder.Length - 1;
        TreeNode result = GenerateLeft(inorder, postorder, 0, inorder.Length - 1, ref index);
		return result;
	}

	TreeNode GenerateLeft(int[] inorder, int[] postorder, int start, int end, ref int index){
		if(start > end) return null;
		int middle = int.MinValue;
		for(int i = start; i <= end; i++){
			if(postorder[index] == inorder[i]){
				middle = i;
				break;
			}
		}

		if(middle == int.MinValue) return null;
		//Debug.Log(index);
		TreeNode node = new TreeNode(postorder[index--]);
		node.right = GenerateLeft(inorder, postorder, middle + 1, end, ref index);
		node.left = GenerateLeft(inorder, postorder, start, middle - 1, ref index);
		

		return node;
	}

	void PreOrder(TreeNode roots){
		Debug.Log(roots.val);

		if(roots.left != null) PreOrder(roots.left);
		if(roots.right != null) PreOrder(roots.right);
	}
}
