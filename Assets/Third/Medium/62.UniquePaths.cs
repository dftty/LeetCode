using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Third
{

    public class UniquePaths : MonoBehaviour
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
        https://leetcode.com/problems/unique-paths/
        Medium 
        Tag: 数组 动态规划

        思路：dp[i, j] = dp[i - 1, j] + dp[i, j - 1]

        O(mn)空间 O(mn)时间

        */
        public int UniquePaths_(int m, int n) {
            int[,] dp = new int[m, n];
            dp[0, 0] = 1;
            for (int i = 0; i < m; i++){
                for (int j = 0; j < n; j++){
                    if (j > 0){
                        dp[i, j] += dp[i, j - 1];
                    }
                    
                    if (i > 0){
                        dp[i, j] += dp[i - 1, j];
                    }
                }
            }
            
            return dp[m - 1, n - 1];
        }

        /**

        上面方法的简化，将dp数组简化到一维
        */
        public int UniquePaths__(int m, int n) {
            int[] dp = new int[n];
            dp[0] = 1;
            for (int i = 0; i < m; i++){
                for (int j = 1; j < n; j++){
                    dp[j] += dp[j - 1];
                }
            }
            
            return dp[n - 1];
        }
    }

}