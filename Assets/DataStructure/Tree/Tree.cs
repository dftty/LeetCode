using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/**
二叉树的通用函数
 */
public class Tree : MonoBehaviour
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
    计算二叉树的深度
     */
    public int depth(TreeNode root){
        if(root == null) return 0;
        return 1 + Math.Max(depth(root.left), depth(root.right));
    }
}
