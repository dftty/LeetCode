using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EditDistance : MonoBehaviour
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
    https://leetcode.com/problems/edit-distance/

    动态规划题目
    题目中的二维数组可以进行优化，因为每次只判断当前列和上一列的数组
     */
    public int MinDistance(string word1, string word2) {
        int m = word1.Length, n = word2.Length;
        int[,] dp = new int[m + 1, n + 1];
        
        // 这里表示单词2的长度为0时需要的操作数量
        for(int i = 0; i <= m; i++){
            dp[i, 0] = i;
        }
        // 这里表示单词1的长度为0时需要的操作数量
        for(int i = 0; i <= n; i++){
            dp[0, i] = i;
        }
        
        for(int i = 1; i <= m; i++){
            for(int j = 1; j <= n; j++){
                if(word1[i - 1] == word2[j - 1]){
                    dp[i, j] = dp[i - 1, j - 1];
                }else{
                    dp[i, j] = Math.Min(dp[i - 1, j] + 1, dp[i - 1, j - 1] + 1);
                    dp[i, j] = Math.Min(dp[i, j], dp[i, j - 1] + 1);
                }
            }
        }
        
        return dp[m, n];
    }
}
