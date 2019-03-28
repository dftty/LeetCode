﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ConstructBinarySearchTreefromPreorderTraversal : MonoBehaviour {

    void Start(){
        BstFromPreorder(new int[]{8, 5, 1, 7, 10, 12});
    }


    /**
    
     */
    public TreeNode BstFromPreorder(int[] preorder) {
        return Generate(preorder, 0, preorder.Length - 1);
    }

    public TreeNode Generate(int[] preorder, int start, int end){
        if(start > end) return null;

        int mid = end + 1;
        for(int i = start + 1; i < end + 1; i++){
            if(preorder[i] > preorder[start]){
                mid = i;
                break;
            }
        }

        TreeNode root = new TreeNode(preorder[start]);

        root.left = Generate(preorder, start + 1, mid - 1);
        root.right = Generate(preorder, mid, end);

        return root;
    }

    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

}
