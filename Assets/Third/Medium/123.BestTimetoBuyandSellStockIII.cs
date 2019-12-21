using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Third
{

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
        Hard


        思路：Discuss中讨论提出了可以轻易得出递推公式, k次交易，在i次卖出
        dp[k, i] = Math.Max(dp[k, i - 1], prices[i] - prices[j] + dp[k - 1, j - 1]);  for j from 0 to i - 1
        
        会导致TLE错误
        */
        public int MaxProfit(int[] prices) {
            if (prices == null || prices.Length == 0) return 0;
            int[,] dp = new int[3, prices.Length];
            
            for (int k = 1; k <= 2; k++){
                for (int i = 1; i < prices.Length; i++){
                    int min = prices[0];
                    for (int j = 1; j <= i; j++){
                        min = Math.Min(min, prices[j] - dp[k - 1, j - 1]);
                    }
                    dp[k, i] = Math.Max(dp[k, i - 1], prices[i] - min);
                }
            }
            
            return dp[2, prices.Length - 1];
        }

        /**
        O(kn) 时间解法


        */
        public int MaxProfit_(int[] prices) {
            if (prices == null || prices.Length == 0) return 0;
            int[,] dp = new int[3, prices.Length];
            
            for (int k = 1; k <= 2; k++){
                int min = prices[0];
                for (int i = 1; i < prices.Length; i++){
                    min = Math.Min(min, prices[i] - dp[k - 1, i - 1]);
                    dp[k, i] = Math.Max(dp[k, i - 1], prices[i] - min);
                }
            }
            
            return dp[2, prices.Length - 1];
        }

    }

}