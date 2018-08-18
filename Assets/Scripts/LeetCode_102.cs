using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_102 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/binary-tree-level-order-traversal/description/
	// 2018/7/17
	// BFS
	public IList<IList<int>> LevelOrder(TreeNode root) {
        IList<IList<int>> result = new List<IList<int>>();
        if(root == null) return result;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while(queue.Count > 0){
            int n = queue.Count;
            List<int> list = new List<int>();
            for(int i = 0; i < n; i++){
                TreeNode temp = queue.Dequeue();
                list.Add(temp.val);
                if(temp.left != null) queue.Enqueue(temp.left);
                if(temp.right != null) queue.Enqueue(temp.right);
            }
            result.Add(list);
        }
        
        return result;
    }
}
