using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BestTimetoBuyandSellStockIII : MonoBehaviour
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
    https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iii/

    动态规划题目
     */
    public int MaxProfit(int[] prices) {
        if (prices == null || prices.Length < 2) return 0;
        
        int maxProfit2 = 0, lowPrice1 = int.MaxValue, maxProfit1 = 0, lowPrice2 = int.MaxValue;
        
        foreach(int p in prices){
            // 这里计算第二次购买出售的最大收益
            maxProfit2 = Math.Max(maxProfit2, p - lowPrice2);
            lowPrice2 = Math.Min(lowPrice2, p - maxProfit1);

            //  这里类似easy的那道股票题，可以计算出单次购买的最大收益
            maxProfit1 = Math.Max(maxProfit1, p - lowPrice1);
            lowPrice1 = Math.Min(lowPrice1, p);
        }
        
        return maxProfit2;
    }

    /**
    适用于k次交易的动态规划解法
     */
    public int MaxProfit_(int[] prices) {
        if (prices == null || prices.Length < 2) return 0;
        
        int res = 0;
        int k = 2;
        int[,] dp = new int[k + 1, prices.Length + 1];
        for (int i = 1; i < k + 1; i++){
            int tempMax =  -prices[0];
            
            for (int j = 1; j < prices.Length; j++){
                dp[i, j] = Math.Max(dp[i, j - 1], tempMax + prices[j]);
                tempMax = Math.Max(tempMax, dp[i - 1, j] - prices[j]);
                res = Math.Max(res, dp[i, j]);
            }
        }
        
        return res;
    }
}
