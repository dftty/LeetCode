using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaryTreeInorderTraversal : MonoBehaviour
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
    https://leetcode.com/problems/binary-tree-inorder-traversal/
    递归方式中序遍历
     */
    public IList<int> InorderTraversal(TreeNode root) {
        IList<int> list = new List<int>();
        Inorder(root, list);
        return list;
    }
    
    public void Inorder(TreeNode node, IList<int> list){
        if (node == null) {
            return;
        }
        
        Inorder(node.left, list);
        list.Add(node.val);
        Inorder(node.right, list);
    }

    /**
    非递归 O(1)空间解法， Mirror Solution
     */
    public IList<int> InorderTraversal__(TreeNode root) {
        IList<int> list = new List<int>();
        
        while (root != null){
            if (root.left != null){
                TreeNode pre = root.left;
                while (pre.right != null && pre.right != root){
                    pre = pre.right;
                }
                
                if (pre.right == null){
                    pre.right = root;
                    root = root.left;
                }
                else
                {
                    pre.left = null;
                    list.Add(root.val);
                    root = root.right;
                }
            }
            else
            {
                list.Add(root.val);
                root = root.right;
            }
        }
        return list;
    }


    /**
    非递归方法
     */
    public IList<int> InorderTraversal_(TreeNode root) {
        Stack<TreeNode> stack = new Stack<TreeNode>();
        IList<int> list = new List<int>();
        TreeNode temp = null;
        while (root != null){
            if (root.left != null){
                stack.Push(root);
                temp = root.left;
                root.left = null;
                root = temp;
                continue;
            }
            
            list.Add(root.val);
            temp = root.right;
            root.right = null;
            root = temp;
            
            if (root == null && stack.Count > 0){
                root = stack.Pop();
            }
        }
        
        return list;
    }
}
