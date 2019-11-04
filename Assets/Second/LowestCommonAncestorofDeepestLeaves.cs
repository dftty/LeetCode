using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LowestCommonAncestorofDeepestLeaves : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
    https://leetcode.com/problems/lowest-common-ancestor-of-deepest-leaves/

    计算出最深节点的深度，然后深度优先遍历，遇到最深节点返回该节点。
     */
    public TreeNode LcaDeepestLeaves(TreeNode root) {
        int d = Depth(root);
        return helper(root, d);
    }
    
    public int Depth(TreeNode root){
        if(root == null) return 0;
        return 1 + Math.Max(Depth(root.left), Depth(root.right));
    }
    
    public TreeNode helper(TreeNode root, int d)
    {
        if(root == null) return null;
        if(d == 1) return root;
        
        TreeNode left = helper(root.left, d - 1);
        TreeNode right = helper(root.right, d - 1);
        
        if(left != null && right != null){
            return root;
        }
        
        if(left != null)
            return left;
        return right;
    }


    /**
    另一种解法， 使用两个map，一个map保存每个节点的深度，另一个map保存这个节点和他的父节点
     */
    Dictionary<TreeNode, int> depth = new Dictionary<TreeNode, int>();
    Dictionary<TreeNode, TreeNode> parent = new Dictionary<TreeNode, TreeNode>();
    int deepest;
    
    public TreeNode LcaDeepestLeaves_(TreeNode root) {
        Depth(root, null);
        List<TreeNode> list = new List<TreeNode>();
        
        foreach(KeyValuePair<TreeNode, int> pair in depth){
            if(pair.Value == deepest){
                list.Add(pair.Key);
            }
        }
        
        TreeNode res = list[0];
        for(int i = 1; i < list.Count; i++){
            res = lca(res, list[i]);
        }
        
        return res;
    }
    
    public void Depth(TreeNode root, TreeNode p){
        if(root == null) return ;
        
        parent.Add(root, p);
        depth.Add(root, p == null ? 0 : depth[p] + 1);
        deepest = Math.Max(deepest, depth[root]);
        
        Depth(root.left, root);
        Depth(root.right, root);
    }
    
    /// <summary>
    /// 交替计算父节点
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public TreeNode lca(TreeNode a, TreeNode b){
        while(a != b){
            if(depth[a] < depth[b]){
                TreeNode temp = a;
                a = b;
                b = temp;
            }
            
            a = parent[a];
        }
        
        return a;
    }
}
