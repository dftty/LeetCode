using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BestTimetoBuyandSellStockwithCooldown : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(MaxProfit(new int[]{1,2,3,0,2}));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
    https://leetcode.com/problems/best-time-to-buy-and-sell-stock-with-cooldown/

    O(n^2)时间解法，利用二维数组保存数据
    dp[i, j] 表示在i天购买，j天卖出的最大收益

     */
    public int MaxProfit(int[] prices) {
        int len = prices.Length + 1;
        int[,] dp = new int[len, len];
        
        for (int i = 1; i < len; i++){
            for (int j = i; j < len; j++){
                if (i - 2 >= 0){
                    dp[i, j] = Math.Max(dp[i, j - 1], Math.Max(prices[j - 1] - prices[i - 1], 0) + dp[i - 2, i - 2]);
                }else {
                    dp[i, j] = Math.Max(dp[i, j - 1], Math.Max(prices[j - 1] - prices[i - 1], 0));
                }
                dp[i, j] = Math.Max(dp[i, j], dp[i - 1, j]);
            }
        }
        return dp[prices.Length, prices.Length];
    }

    /**
    Discuss 解法
    O(n) 时间 O(n) 空间
     */
    public int MaxProfit_Discuss(int[] prices) {
        if (prices == null || prices.Length < 2) return 0;
        
        int len = prices.Length + 1;
        int[] buy = new int[len];
        int[] sell = new int[len];
        
        buy[1] = -prices[0];
        
        for (int i = 2; i < len; i++){
            int price = prices[i - 1];
            sell[i] = Math.Max(sell[i - 1], buy[i - 1] + price);
            buy[i] = Math.Max(buy[i - 1], sell[i - 2] - price);
        }
        
        return sell[len - 1];
    }


    /**
    没有冷却时间买入卖出最大收益
     */
    public int MaxProfit_NoCool(int[] prices) {
        int len = prices.Length + 1;
        int[,] dp = new int[len, len];
        
        for (int i = 1; i < len; i++){
            for (int j = i; j < len; j++){
                dp[i, j] = Math.Max(dp[i, j - 1], Math.Max(prices[j - 1] - prices[i - 1], 0) + dp[i - 1, j - 1]);
                dp[i, j] = Math.Max(dp[i, j], dp[i - 1, j]);
            }
        }
        return dp[prices.Length, prices.Length];
    }
}
