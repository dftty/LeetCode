using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SmallestSubtreewithalltheDeepestNodes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public Dictionary<TreeNode,int> depth = new Dictionary<TreeNode, int>();
    public Dictionary<TreeNode, TreeNode> parent = new Dictionary<TreeNode, TreeNode>();
    public int deepest = 0;
    

    /**
    https://leetcode.com/problems/smallest-subtree-with-all-the-deepest-nodes/

    使用depth字典来保存每个节点的深度，parent字典来保存每个节点对应的父节点.
     */
    public TreeNode SubtreeWithAllDeepest(TreeNode root) {
        Depth(root, null);
        
        List<TreeNode> list = new List<TreeNode>();
        foreach (TreeNode t in depth.Keys){
            if (depth[t] == deepest){
                list.Add(t);
            }
        }
        
        TreeNode res = list[0];
        for (int i = 1; i < list.Count; i++){
            res = lca(res, list[i]);
        }
        
        return res;
    }
    
    public void Depth(TreeNode root, TreeNode p){
        if (root == null) return;
        
        parent.Add(root, p);
        depth.Add(root, p == null ? 0 : depth[p] + 1);
        
        deepest = Math.Max(deepest, depth[root]);
        Depth(root.left, root);
        Depth(root.right, root);
    }
    
    public TreeNode lca(TreeNode a, TreeNode b){
        while(a != b){
            if (depth[a] < depth[b]){
                TreeNode temp = b;
                b = a;
                a = temp;
            }
            a = parent[a];
        }
        return a;
    }


    /**
    Discuss 另一个解法
     */
    public TreeNode SubtreeWithAllDeepest_(TreeNode root) {
        return Depth(root).Key;
    }
    
    public KeyValuePair<TreeNode, int> Depth(TreeNode root){
        if (root == null) 
            return new KeyValuePair<TreeNode, int>(null, 0);
        var l = Depth(root.left);
        var r = Depth(root.right);

        TreeNode node = null;
        if (l.Value == r.Value)
        {
            // 表示左右深度相同
            node = root;
        }else 
        {
            // 检测左右哪边深度更大
            node = l.Value > r.Value ? l.Key : r.Key;
        }
        
        return new KeyValuePair<TreeNode, int>(node, Math.Max(l.Value, r.Value) + 1);
    }
}
