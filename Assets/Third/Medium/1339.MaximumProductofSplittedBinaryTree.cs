using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Thrid
{
    
    public class MaximumProductofSplittedBinaryTree : MonoBehaviour
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
        https://leetcode.com/problems/maximum-product-of-splitted-binary-tree/
        Medium
        Tag: 动态规划 树

        思路：首先遍历一边树将所有节点的和计算出来，用total记录，
        然后再第二个深度优先搜索中，遍历每个节点，对于每个root节点，可以去掉他的左边或者右边的边，
        如果去掉左边的边，那么积就是root节点左子树的所有节点和left，和total减去左子树的和的乘积，即
            left * （total - left）
        如果去掉右边的边，就是
            right * （total - right）
        找到所有结果中最大的即可。

        */
        long res = 0;
        long total = 0;
        long div = 1000000007;
        
        public int MaxProduct(TreeNode root) {
            dfs(root);
            dfs1(root);
            return (int)(res % div);
        }
        
        void dfs(TreeNode root){
            if (root == null){
                return ;
            }
            
            dfs(root.left);
            dfs(root.right);
            total += root.val;
        }
        
        long dfs1(TreeNode root){
            if (root == null){
                return 0;
            }
            
            long left = dfs1(root.left);
            long right = dfs1(root.right);
            
            
            res = Math.Max(res, (left * (total - left)));
            res = Math.Max(res, (right * (total - right)));
            return left + right + root.val;
        }
    }

}