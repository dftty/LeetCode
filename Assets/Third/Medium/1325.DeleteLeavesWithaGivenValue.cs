using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Third
{

    public class DeleteLeavesWithaGivenValue : MonoBehaviour
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
        https://leetcode.com/problems/delete-leaves-with-a-given-value/
        Medium
        Tag: 树 

        思路：每次检测root节点的左右子树，然后进行遍历

        */
        public TreeNode RemoveLeafNodes(TreeNode root, int target) {
            TreeNode node = new TreeNode(0);
            node.left = root;
            Remove(node, target);
            return node.left;
        }
        
        public TreeNode Remove(TreeNode root, int target){
            if (root.left != null && (root.left.left != null || root.left.right != null)){
                Remove(root.left, target);
            }
            
            if (root.right != null && (root.right.left != null || root.right.right != null)){
                Remove(root.right, target);
            }
            
            if (root.left != null && root.left.left == null && root.left.right == null && root.left.val == target){
                root.left = null;
            }
            
            if (root.right != null && root.right.left == null && root.right.right == null && root.right.val == target){
                root.right = null;
            }
            
            return root;
        }


        /**

        更加简洁的解法，使用深度优先搜索，如果该节点的左右都为空并且值和target相等
        就返回null，否则返回该节点
        */
        public TreeNode RemoveLeafNodes_(TreeNode root, int target) {
            if (root == null) return null;
            
            root.left = RemoveLeafNodes_(root.left, target);
            root.right = RemoveLeafNodes_(root.right, target);
            
            if (root.left == null && root.right == null && root.val == target){
                return null;
            }

            return root;
        }
    }

}