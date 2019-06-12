using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinarySearchTreetoGreaterSumTree : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	int count = 0;
	/**
	遍历顺序改成右中左，然后计算val即可
	 */
    public TreeNode BstToGst(TreeNode root) {
        DFS(root);
        return root;
    }
    
    public void DFS(TreeNode root){
        if(root == null) return ;
        
        DFS(root.right);
        root.val += count;
        count = root.val;
        DFS(root.left);
    }
}
