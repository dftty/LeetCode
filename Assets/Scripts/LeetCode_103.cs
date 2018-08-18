using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_103 : MonoBehaviour
{

    

    // Medium https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/description/
    // 2018/7/18
    // BFS
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        List<IList<int>> result = new List<IList<int>>();
        if(root == null) return result;
        int count = 0;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        
        while(queue.Count > 0){
            List<int> temp = new List<int>();
            int n = queue.Count;
            for(int i = 0; i < n; i++){
                TreeNode node = queue.Dequeue();
                if(count % 2 == 0){
                    temp.Add(node.val);
                }else{
                    temp.Insert(0, node.val);
                }
                
                if(node.left != null) queue.Enqueue(node.left);
                if(node.right != null) queue.Enqueue(node.right);
            }
            result.Add(temp);
            count++;
        }
        
        return result;
    }

}
