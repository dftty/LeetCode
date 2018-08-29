using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class LeetCode_145 : MonoBehaviour {

    void Start(){
        
    }

    // Hard https://leetcode.com/problems/binary-tree-postorder-traversal/description/
    // 2018/8/22
    // iteration use stack
    public IList<int> PostorderTraversal(TreeNode root) {
        List<int> result = new List<int>();
        if(root == null) return result;
        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(root);
        while(stack.Count > 0){
            TreeNode node = stack.Peek();
            if(node.left != null) {
                stack.Push(node.left);
                node.left = null;
                continue;
            }
            if(node.right != null){
                stack.Push(node.right);
                node.right = null;
                continue;
            }
            result.Add(node.val);
            stack.Pop();
        }
        return result;
    }

    // Discuss
    public IList<int> PostorderTraversal_(TreeNode root) {
        List<int> result = new List<int>();
        if(root == null) return result;
        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(root);
        while(stack.Count > 0){
            TreeNode node = stack.Pop();
            result.Insert(0, node.val);
            if(node.left != null) {
                stack.Push(node.left);
            }
            if(node.right != null){
                stack.Push(node.right);
            }
        }
        return result;
    }
}


