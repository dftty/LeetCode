using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Third
{

    public class UniquePathsII : MonoBehaviour
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
        https://leetcode.com/problems/unique-paths-ii/
        Medium
        Tag: 数组 动态规划

        思路：和62类似，题目中加入了障碍，如果遇到障碍，那么路径无需计算


        提交错误次数：2次
            提交中没有判断起点和终点是障碍的情况
        */
        public int UniquePathsWithObstacles(int[][] o) {
            int m = o.Length, n = o[0].Length;
            if (o[0][0] == 1 || o[m - 1][n - 1] == 1) return 0;
            int[,] dp = new int[m, n];
            dp[0, 0] = 1;
            for (int i = 0; i < m; i++){
                for (int j = 0; j < n; j++){
                    if (j > 0 && o[i][j - 1] == 0){
                        dp[i, j] += dp[i, j - 1];
                    }
                    
                    if (i > 0 && o[i - 1][j] == 0){
                        dp[i, j] += dp[i - 1, j];
                    }
                }
            }
            
            return dp[m - 1, n - 1];
        }


        /**
        O(n) 空间解法

        */
        public int UniquePathsWithObstacles_(int[][] o) {
            if (o == null || o.Length == 0) return 0;
            int m = o.Length, n = o[0].Length;
            int[] dp = new int[n];
            dp[0] = 1;
            for (int i = 0; i < m; i++){
                for (int j = 0; j < n; j++){
                    if (j > 0){
                        dp[j] += dp[j - 1];
                    }
                    
                    if (o[i][j] == 1){
                        dp[j] = 0;
                    }
                }
            }
            
            return dp[n - 1];
        }

        /**
        c++ 实现
        int uniquePathsWithObstacles(vector<vector<int>>& obstacleGrid) {
            if (obstacleGrid.size() == 0) return 0;
            int n = obstacleGrid[0].size();
            int m = obstacleGrid.size();
            vector<long> dp(n, 0);
            
            dp[0] = 1;

            for (int i = 0; i < m; i++){
                for (int j = 0; j < n; j++){
                    if (j > 0){
                        dp[j] += dp[j - 1];
                    }
                    
                    if (obstacleGrid[i][j] == 1){
                        dp[j] = 0;
                    }
                }
            }
            
            return dp[n - 1];
        }

        */
    }

}