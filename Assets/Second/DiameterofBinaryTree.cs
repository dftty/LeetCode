using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DiameterofBinaryTree : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int res = 0;
    public int DiameterOfBinaryTree(TreeNode root) {
        Get(root);
        return res;
    }
    
    public int Get(TreeNode root){
        if (root == null) return 0;
        
        int l = Get(root.left);
        int r = Get(root.right);
        
        res = Math.Max(l + r, res);
        
        return Math.Max(l, r) + 1;
    }
}
