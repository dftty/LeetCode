using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Third
{

    public class LongestIncreasingSubsequence : MonoBehaviour
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
        https://leetcode.com/problems/longest-increasing-subsequence/
        Tag: 动态规划

        思路： dp[i] 代表i - 1位数组中最长递增的数组长度。

        */
        public int LengthOfLIS(int[] nums) {
            if (nums == null || nums.Length == 0) return 0;
            int n = nums.Length;
            int[] dp = new int[n + 1];
            int res = 1;
            for (int i = 1; i <= n; i++){
                dp[i] = 1;
                for (int j = 1; j < i; j++){
                    if (nums[i - 1] > nums[j - 1]){
                        dp[i] = Math.Max(dp[i], 1 + dp[j]);
                    }
                }
                res = Math.Max(res, dp[i]);
            }
            return res;
        }
    }

}