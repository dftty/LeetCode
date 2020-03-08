using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace  Third
{
    
    public class MinimumDifficultyofaJobSchedule : MonoBehaviour
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
        https://leetcode.com/problems/minimum-difficulty-of-a-job-schedule/
        Hard
        Tag: 动态规划

        Contest 解法

        max数组保存从i到j之间的最大值

        */
        int N = 310;
        int M = 20;
        
        public int MinDifficulty(int[] job, int d) {
            int n = job.Length;
            if (n < d) return -1;
            int[][] dp = new int[N][];
            int[][] max = new int[N][];
            
            for (int i = 0; i < N; i++){
                dp[i] = new int[M];
                for (int j = 0; j < M; j++){
                    dp[i][j] = -1;
                }
                
                max[i] = new int[N];
            }
            
            // 这里和下面的for循环使用max保存i到j之间的最大值
            for (int i = 0; i < n; i++){
                max[i][i + 1] = job[i];
            }
            
            for (int k = 2; k <= n; k++){
                for (int i = 0; i + k <= n; i++){
                    max[i][i + k] = Math.Max(max[i][i + k - 1], job[i + k - 1]);
                }
            }
            
            dp[0][0] = 0;
            for (int i = 1; i <= n; i++){
                for (int j = 1; j <= d; j++){
                    dp[i][j] = 1 << 30;
                    for (int k = 1; i - k >= j - 1; k++){
                        if (dp[i - k][j - 1] < 0) continue;
                        dp[i][j] = Math.Min(dp[i][j], dp[i - k][j - 1] + max[i - k][i]);
                    }
                }
            }
            return dp[n][d];
        }
    }

}