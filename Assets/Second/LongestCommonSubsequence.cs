using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LongestCommonSubsequence : MonoBehaviour
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
    https://leetcode.com/problems/longest-common-subsequence/

    LCS 问题，DP方法解决
     */
    public int LongestCommonSubsequence_(string text1, string text2) {
        string str = text1;
        if(text1.Length > text2.Length){
            text1 = text2;
            text2 = str;
        }
        
        int m = text1.Length, n = text2.Length;
        int[,] dp = new int[m + 1, n + 1];
        
        for(int i = 1; i <= m; i++){
            for(int j = 1; j <= n; j++){
                if(text1[i - 1] == text2[j - 1]){
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                }else{
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
        }
        
        return dp[m, n];
    }

    /**
    Discuss解法， 只需要一维的dp数组
     */
    public int LongestCommonSubsequence_Dis(string text1, string text2) {
        int m = text1.Length, n = text2.Length;
        int[] dp = new int[n + 1];
        
        for(int i = 1; i <= m; i++){
            int pre = 0;
            for(int j = 1; j <= n; j++){
                if(text1[i - 1] == text2[j - 1]){
                    dp[j] = pre + 1;
                }else{
                    dp[j] = Math.Max(dp[j - 1],dp[j]);
                }

                pre = dp[j];
            }
        }
        
        return dp[n];
    }
}
