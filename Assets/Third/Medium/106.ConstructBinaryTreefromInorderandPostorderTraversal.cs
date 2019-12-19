using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Third
{

    public class ConstructBinaryTreefromInorderandPostorderTraversal : MonoBehaviour
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
        https://leetcode.com/problems/construct-binary-tree-from-inorder-and-postorder-traversal/
        Medium
        Tag:  数组 树 深度优先搜索

        思路：后序遍历，那么最后一个数一定是根节点。因此，类似105题，递归遍历即可.

        */
        public TreeNode BuildTree(int[] inorder, int[] postorder) {
            if (inorder == null || inorder.Length == 0) return null;
            TreeNode node = Construct(inorder, postorder, postorder.Length - 1, 0, postorder.Length - 1);
            return node;
        }
        
        TreeNode Construct(int[] inorder, int[] postorder, int postEnd, int left, int right){
            if (postEnd < 0 || left > right){
                return null;
            }
            
            int index = 0;
            for (int i = left; i <= right; i++){
                if (inorder[i] == postorder[postEnd]){
                    index = i;
                    break;
                }
            }
            
            TreeNode node = new TreeNode(postorder[postEnd]);
            
            node.left = Construct(inorder, postorder, postEnd - right + index - 1, left, index - 1);
            node.right = Construct(inorder, postorder, postEnd - 1, index + 1, right);
            return node;
        }
    }

}