using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FillingBookcaseShelves : MonoBehaviour
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
    https://leetcode.com/problems/filling-bookcase-shelves/

    动态规划问题
    dp[i] 代表前本书整体的最小高度
     */
    public int MinHeightShelves(int[][] books, int shelf_width) {
        int[] dp = new int[books.Length + 1];
        
        dp[0] = 0;
        for(int i = 1; i <= books.Length; i++){
            int height = books[i - 1][1];
            int weight = books[i - 1][0];
            dp[i] = dp[i - 1] + height;
            for(int j = i - 1; j > 0 && weight + books[j - 1][0] <= shelf_width; j--){
                height = Math.Max(height, books[j - 1][1]);
                weight += books[j - 1][0];
                dp[i] = Math.Min(dp[i], dp[j - 1] + height);
            }
        }
        
        return dp[books.Length];
    }
}
