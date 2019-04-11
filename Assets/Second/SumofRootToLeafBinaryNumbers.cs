using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumofRootToLeafBinaryNumbers : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	Sum of Root To Leaf Binary Numbers
	Given a binary tree, each node has value 0 or 1.  Each root-to-leaf 
	path represents a binary number starting with the most significant bit.  
	For example, if the path is 0 -> 1 -> 1 -> 0 -> 1, then this could represent 01101 in binary, which is 13.
	For all leaves in the tree, consider the numbers represented by the path from the root to that leaf.
	Return the sum of these numbers.

	深度优先搜索加模运算
	 */
	public int SumRootToLeaf(TreeNode root) {
        int mod = 1000000007;
        return dfs(root, 0, mod);
    }
    
    public int dfs(TreeNode root, int val, int mod){
        if(root == null) return 0;
        val = (val * 2 + root.val) % mod;
        if(root.left == null && root.right == null){
            return val;
        }else{
            return (dfs(root.left, val, mod) + dfs(root.right, val, mod)) % mod;
        }
    }
}
