using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_897 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		TreeNode node1 = new TreeNode(311);
		TreeNode node2 = new TreeNode(408);
		TreeNode node3 = new TreeNode(811);
		node1.left = node2;
		node1.right = node3;
		TreeNode node4 = new TreeNode(861);
		node3.left = node4;
		// TreeNode node5 = new TreeNode(4);
		// node2.left = node4;
		// node2.right = node5;
		// TreeNode node6 = new TreeNode(1);
		// node4.left = node6;
		// TreeNode node7 = new TreeNode(8);
		// node3.right = node7;
		// TreeNode node8 = new TreeNode(7);
		// TreeNode node9 = new TreeNode(9);
		// node7.left = node8;
		// node7.right = node9;
		IncreasingBST(node1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public TreeNode IncreasingBST(TreeNode root) {
        if(root == null) return null;
        TreeNode result = BFS(root);
        return result;
    }
    
    public TreeNode BFS(TreeNode root){
        if(root == null) return root;
        
        TreeNode left = BFS(root.left);
        TreeNode right = BFS(root.right);
        
		root.left = null;
		root.right = right;
        if(left == null) {
			
			return root;
		}
        TreeNode res = left;
        while(left.right != null) left = left.right;
        left.right = root;
        return res;
    }
}
