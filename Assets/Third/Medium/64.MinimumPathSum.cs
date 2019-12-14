using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Third
{

    public class MinimumPathSum : MonoBehaviour
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
        https://leetcode.com/problems/minimum-path-sum/
        Medium
        Tag: 动态规划

        思路：深度优先搜索，该方法会导致TLE错误

        提交错误次数：1次
            TLE
        */
        int min = int.MaxValue;
        public int MinPathSum(int[][] grid) {
            if (grid == null || grid.Length == 0) return 0;
            dfs(grid, 0, 0, 0, grid.Length, grid[0].Length);
            return min;
        }
        
        void dfs(int[][] grid, int i, int j, int sum, int m, int n){
            sum += grid[i][j];
            if (i == m - 1 && j == n - 1){
                min = Math.Min(min, sum);
                return ;
            }
            
            if (i + 1 < m){
                dfs(grid, i + 1, j, sum, m, n);
            }
            
            if (j + 1 < n){
                dfs(grid, i, j + 1, sum, m, n);
            }
        }

        /**

        思路：动态规划，当前格子的最小sum等于左边或者上边中sum较小的一个加上当前格子的值。

        */
        public int MinPathSum_(int[][] grid) {
            if (grid == null || grid.Length == 0) return 0;
            
            int m = grid.Length, n = grid[0].Length;
            int[,] dp = new int[m, n];
            dp[0, 0] = grid[0][0];
            
            for (int i = 0; i < m; i++){
                for (int j = 0; j < n; j++){
                    if (i > 0 || j > 0){
                        dp[i, j] = int.MaxValue;
                    }
                    if (i > 0){
                        dp[i, j] = Math.Min(dp[i, j], grid[i][j] + dp[i - 1, j]);
                    }
                    if (j > 0){
                        dp[i, j] = Math.Min(dp[i, j], grid[i][j] + dp[i, j - 1]);
                    }
                }
            }
            
            return dp[m - 1, n - 1];
        }

        /**
        和上面解法类似 O(n)空间，本题可以优化到使用grid本身作为dp数组。
        
        */
        public int MinPathSum__(int[][] grid) {
            if (grid == null || grid.Length == 0) return 0;
            
            int m = grid.Length, n = grid[0].Length;
            int[] dp = new int[n];
            dp[0] = grid[0][0];
            
            for (int i = 1; i < n; i++){
                dp[i] = grid[0][i] + dp[i - 1];
            }
            
            for (int i = 1; i < m; i++){
                dp[0] += grid[i][0];
                for (int j = 1; j < n; j++){
                    dp[j] = Math.Min(dp[j], dp[j - 1]) + grid[i][j];
                }
            }
            
            return dp[n - 1];
        }
    }

}