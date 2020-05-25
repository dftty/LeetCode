using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Third
{

    public class PseudoPalindromicPathsinaBinaryTree : MonoBehaviour
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
        https://leetcode.com/problems/pseudo-palindromic-paths-in-a-binary-tree/
        Tag: 树 深度优先搜索

        思路：因为节点中的值为1-9,因此可以使用一个数组来进行计数，当遇到叶子节点时，判断计数中数量为奇数的出现次数
        如果次数大于1，那么就不能组成回文。

        */
        int[] count = new int[10];
        int res = 0;
        public int PseudoPalindromicPaths (TreeNode root) {
            Dfs(root);
            return res;
        }
        
        TreeNode Dfs(TreeNode root){
            if (root == null) return root;
            
            count[root.val]++;
            
            TreeNode left = Dfs(root.left);
            TreeNode right = Dfs(root.right);
            
            if (left == null && right == null){
                int oddCount = 0;
                for (int i = 0; i < count.Length; i++){
                    if (count[i] % 2 != 0){
                        oddCount++;
                    }
                }
                
                if (oddCount <= 1){
                    res++;
                }
            }
            
            count[root.val]--;
            
            return root;
        }

        /**
        思路：使用一个int值的二进制码来进行计数，如果可以组成回文，那么最后count的二进制中最多会出现一位1,其余都为0

        知识点：遇到奇偶判断时，是否可以使用二进制位来保存。
        */
        public int PseudoPalindromicPaths_ (TreeNode root) {
            return dfs(root, 0);
        }
        
        int dfs(TreeNode root, int count){
            if (root == null) return 0;
            
            count ^= 1 << (root.val - 1);
            int res = dfs(root.left, count) + dfs(root.right, count);
            if (root.left == root.right && (count & (count - 1)) == 0) res++;
            return res;
        }

    }

}