using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MaximumDifferenceBetweenNodeandAncestor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	Maximum Difference Between Node and Ancestor

	标准的深度优先搜索，每次搜索将当前父节点中的最大和最小数传递进去就可以
	 */
	public int MaxAncestorDiff(TreeNode root) {
        if(root == null) return 0;
        int result = 0;
        result = BFS(root, root.val, root.val);
        return result;
    }
    
    public int BFS(TreeNode root, int rootMax, int rootMin){
        if(root == null) return 0;
        
        int max = 0;
        int curMax = Math.Abs(rootMax - root.val);
        curMax = Math.Max(curMax, Math.Abs(rootMin - root.val));
        int left = BFS(root.left, Math.Max(rootMax, root.val), Math.Min(rootMin, root.val));
        int right = BFS(root.right, Math.Max(rootMax, root.val), Math.Min(rootMin, root.val));
        
        max = Math.Max(curMax, left);
        max = Math.Max(max, right);
        
        return max;
    }
}
