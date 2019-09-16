using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BestTimetoBuyandSellStock : MonoBehaviour
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
    https://leetcode.com/problems/best-time-to-buy-and-sell-stock/

    
     */
    public int MaxProfit(int[] prices) {
        if (prices == null || prices.Length < 2) return 0;
        int res = 0;
        int min = prices[0];
        
        for (int i = 1; i < prices.Length; i++){
            res = Math.Max(res, prices[i] - min);
            min = Math.Min(min, prices[i]);
        }
        
        return res;
    }
}
