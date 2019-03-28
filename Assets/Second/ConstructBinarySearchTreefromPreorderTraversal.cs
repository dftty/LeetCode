using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ConstructBinarySearchTreefromPreorderTraversal : MonoBehaviour {

    void Start(){
        BstFromPreorder_(new int[]{8, 5, 1, 7, 10, 12});
    }


    /**
    Construct Binary Search Tree from Preorder Traversal

    (Recall that a binary search tree is a binary tree where for every node, 
    any descendant of node.left has a value < node.val, and any descendant of node.
    right has a value > node.val.  Also recall that a preorder traversal displays the 
    value of the node first, then traverses node.left, then traverses node.right.)

    解法来自Discuss

    本题目给了一个二叉查找树的前序遍历数组，要求用这个数组构建这个二叉查找树
    这个类型的题目是经典的递归题，
    因为给定的条件是前序遍历，因此第一个数一定是根节点，然后后面的数组中小于这个数的子数组一定是它的左子树，大于这个数的子数组一定是它的右子树。
    这样分割后再创建结点并分割，最终就可以求得这个二叉查找树
    第一种解法
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


    /**
    第二种解法

    这个解法类似，找到了递归返回的边界。
     */
    int i = 0;
    public TreeNode BstFromPreorder_(int[] preorder){
        return Generate_(preorder, int.MaxValue);
    }

    public TreeNode Generate_(int[] preorder, int border){
        if(i == preorder.Length || preorder[i] > border) return null;

        TreeNode root = new TreeNode(preorder[i++]);

        root.left = Generate_(preorder, root.val);
        root.right = Generate_(preorder, border);

        return root;
    }


    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

}
