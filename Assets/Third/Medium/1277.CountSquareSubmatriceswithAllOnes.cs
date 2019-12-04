using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Third
{
    public class CountSquareSubmatriceswithAllOnes : MonoBehaviour
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
        https://leetcode.com/problems/count-square-submatrices-with-all-ones/
        Medium
        Tag: 数组  动态规划

        思路： 当前格子可以组成正方形的数量和左边，上边和左上格子三个格子中的最小的正方形数量有关。
        dp[i, j] = min(dp[i - 1, j], dp[i, j - 1], dp[i - 1,j - 1]) + 1

        dp[i, j]的意思是以matrix[i][j] 为右下角组成的最大正方形的长度

        O(mn) time O(mn) space
        */
        public int CountSquares(int[][] matrix) {
            int m = matrix.Length, n = matrix[0].Length;
            
            int[,] dp = new int[m, n];
            int res = 0;
            for (int i = 0; i < m; i++){
                for (int j = 0; j < n; j++){
                    if (matrix[i][j] == 1){
                        if (i > 0 && j > 0){
                            dp[i, j] = Math.Min(Math.Min(dp[i - 1, j], dp[i, j - 1]), dp[i - 1, j - 1]) + 1;
                        }else{
                            dp[i, j] = 1;
                        }
                        
                        res += dp[i, j];
                    }
                }
            }
            
            return res;
        }

        /**
        Discuss 解法

        思路：和我的解法类似，没有额外使用数组来保存计算的值。
        
        O(mn) time O(1) space
        */
        public int CountSquares_Discuss(int[][] matrix) {
            int m = matrix.Length, n = matrix[0].Length;
            int res = 0;
            for (int i = 0; i < m; i++){
                for (int j = 0; j < n; j++){
                    if (matrix[i][j] > 0 && i > 0 && j > 0){
                        matrix[i][j] = Math.Min(Math.Min(matrix[i - 1][j], matrix[i][j- 1]), matrix[i - 1][j - 1]) + 1;
                    }
                    res += matrix[i][j];
                }
            }
            
            return res;
        }

    }
}