using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Third
{

    public class Triangle : MonoBehaviour
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
        https://leetcode.com/problems/triangle/
        Medium
        Tag: 数组  动态规划

        思路：可以考虑从后向前赋值，这样就可以使用一维数组来保存结果。

        */
        public int MinimumTotal(IList<IList<int>> triangle) {
            if (triangle == null || triangle.Count == 0) return 0;
            
            int[] dp = new int[triangle[triangle.Count - 1].Count];
            
            for (int i = 0; i < triangle.Count; i++){
                for (int j = triangle[i].Count - 1; j >= 0; j--){
                    if (j == 0){
                        dp[j] = dp[j] + triangle[i][j];
                    }else if(j == triangle[i].Count - 1){
                        dp[j] = dp[j - 1] + triangle[i][j];
                    }else if (j > 0){
                        dp[j] = Math.Min(dp[j] + triangle[i][j], dp[j - 1] + triangle[i][j]);
                    }
                }
            }
            
            int res = int.MaxValue;
            for (int i = 0; i < dp.Length; i++){
                res = Math.Min(res, dp[i]);
            }
            
            return res;
        }
    }

}