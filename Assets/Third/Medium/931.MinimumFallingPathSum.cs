using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Third
{

    public class MinimumFallingPathSum : MonoBehaviour
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
        https://leetcode.com/problems/minimum-falling-path-sum/
        Medium
        动态规划

        思路：当前格子可以选择上面格子中的左中右三个格子，因此选择三个中较小的那个即可。

        

        */
        public int MinFallingPathSum(int[][] A) {
            int m = A.Length, n = A[0].Length;
            int[] dp = Copy(A[0]);
            
            for (int i = 1; i < m; i++){
                int[] temp = Copy(dp);
                for (int j = 0; j < n; j++){
                    int left = int.MaxValue, right = int.MaxValue;
                    if (j > 0){
                        left = temp[j - 1] + A[i][j];
                    }
                    if (j < n - 1){
                        right = temp[j + 1] + A[i][j];
                    }
                    
                    int middle = temp[j] + A[i][j];
                    dp[j] = Math.Min(left, Math.Min(middle, right));
                }
            }
            
            int res = int.MaxValue;
            for (int i = 0; i < dp.Length; i++){
                res = Math.Min(dp[i], res);
            }
            return res;
        }
        
        public int[] Copy(int[] array){
            int[] res = new int[array.Length];
            for (int i = 0; i < array.Length; i++){
                res[i] = array[i];
            }
            
            return res;
        }
    }

}