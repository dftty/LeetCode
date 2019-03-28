using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_111 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Easy https://leetcode.com/problems/minimum-depth-of-binary-tree/description/
    // 2018/7/11
    // use BFS, if a node has no left child and right child, then this is exact the mindepth
    public int MinDepth(TreeNode root) {
        if(root == null) return 0;
        int minDepth = int.MaxValue;
        int depth = 1;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while(queue.Count > 0){
            int n = queue.Count;
            for(int i = 0; i < n; i++){
                TreeNode node = queue.Dequeue();
                if(node.left == null && node.right == null) {
                    minDepth = Math.Min(minDepth, depth);
                    return minDepth;
                }
                if(node.left != null) queue.Enqueue(node.left);
                if(node.right != null) queue.Enqueue(node.right);
            }
            
            depth++;
        }
        
        return minDepth;
    }

    // Besttime solution
    public int MinDepth_(TreeNode root) {
         //int minHeight = 0;
        if(root == null)
            return 0;
        else if(root.left == null && root.right !=null)
            return 1 + MinDepth_(root.right);
        else if(root.left != null && root.right ==null)
            return 1 + MinDepth_(root.left);
        else
            return 1 + Math.Min(MinDepth_(root.left), MinDepth_(root.right));
    }


}
