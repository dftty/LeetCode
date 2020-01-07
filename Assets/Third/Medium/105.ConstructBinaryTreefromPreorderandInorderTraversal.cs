using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Third
{

    public class ConstructBinaryTreefromPreorderandInorderTraversal : MonoBehaviour
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
        https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/
        Medium
        Tag: 数组 数 深度优先搜索

        思路：前序遍历一定是从根节点开始的，因此遍历前序数组，然后寻找前序数组的那个数字在对应的中序数组中
        的位置，找到之后，以该节点为根，左边的都是属于该根节点的所有左子树，右边的都属于该根节点的右子树。

        */
        int preIndex = 0;
        public TreeNode BuildTree(int[] preorder, int[] inorder) {
            if (preorder == null || preorder.Length == 0) return null;
            
            TreeNode node = Construct(preorder, inorder, 0, preorder.Length - 1);
            
            return node;
        }
        
        TreeNode Construct(int[] preorder, int[] inorder, int left, int right){
            if (left > right || preIndex >= preorder.Length){
                return null;
            }
            
            int index = 0;
            
            for (int i = left; i <= right; i++){
                if (inorder[i] == preorder[preIndex]){
                    index = i;
                    break;
                }
            }
            
            TreeNode node = new TreeNode(preorder[preIndex++]);
            node.left = Construct(preorder, inorder, left, index - 1);
            node.right = Construct(preorder, inorder, index + 1, right);
            
            return node;
        }

        /**

        c++ 实现
        TreeNode* buildTree(vector<int>& preorder, vector<int>& inorder) {
            TreeNode* res = construct(0, 0, preorder.size() - 1, preorder, inorder);
            return res;
        }
        
        TreeNode* construct(int start, int left, int right, vector<int>& preorder, vector<int>& inorder){
            if (start >= preorder.size() || left > right){
                return NULL;
            }
            
            int middle = 0;
            for (int i = left; i <= right; i++){
                if (inorder[i] == preorder[start]){
                    middle = i;
                    break;
                }
            }
            
            TreeNode* node = new TreeNode(preorder[start]);
            
            node->left = construct(start + 1, left, middle - 1, preorder, inorder);
            node->right = construct(start + middle - left + 1, middle + 1, right, preorder, inorder);
            
            return node;
        }

        */
    }

}