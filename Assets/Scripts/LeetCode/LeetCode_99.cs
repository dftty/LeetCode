using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_99 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public TreeNode lastNode = null;
    public TreeNode first,finial;


	// Hard https://leetcode.com/problems/recover-binary-search-tree/description/
	// 2018/8/3
	// DFS搜索找到两个需要替换值的----node
    public void RecoverTree(TreeNode root) {
        if(root == null) return ;
        if(root.left == null && root.right == null) return ;
        Find(root);
        int temp = finial.val;
        finial.val = first.val;
        first.val = temp;
    }
    
    public TreeNode Find(TreeNode root){
        if(root == null) return null;
        
        TreeNode left = Find(root.left);
        
        if(lastNode != null && lastNode.val > root.val) {
            if(first == null) first = lastNode;
            finial = root;
        }
        lastNode = root;
        TreeNode right = Find(root.right);

        return root;
    }
}
