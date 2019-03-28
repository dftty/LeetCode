using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;

public class LeetCode_123 : MonoBehaviour {

    void Start(){
        Debug.Log(MaxProfit(new int[]{2,1,2,0,1}));
    }

    // Hard https://leetcode.com/problems/longest-consecutive-sequence/description/
    // 2018/8/28
    // discuss solution 
    public int MaxProfit_(int[] prices) {
        if(prices.Length <= 1) return 0;

        int k = 2;
        int maxProf = 0;
        int[,] f = new int[k + 1, prices.Length];
        for(int kk = 1; kk <= k; kk++){
            int tempMax = f[kk - 1, 0] - prices[0];
            for(int i = 1; i < prices.Length; i++){
                f[kk, i] = Math.Max(f[kk, i - 1], prices[i] + tempMax);
                tempMax = Math.Max(tempMax, f[kk - 1, i] - prices[i]);
                maxProf = Math.Max(f[kk, i], maxProf);
            }
        }

        return maxProf;
    }


    // O(n^2) solution 会在测试中时间超过限制
    public int MaxProfit(int[] prices) {
        if(prices == null) return 0;
        int result = GetMin(prices, 0, prices.Length);
        
        for(int i = 0; i < prices.Length - 2; i++){
            int res_l = GetMin(prices, 0, i + 2);
            int res_r = GetMin(prices, i + 2, prices.Length);
            result = Math.Max(result, res_l + res_r);
        }
        return result;
    }
    
    public int GetMin(int[] prices, int start, int end){
        int res = 0;
        if(start >= prices.Length) return res;
        
        int min = prices[start];
        for(int i = start + 1; i < end; i++){
            res = Math.Max(res, prices[i] - min);
            if(min > prices[i]){
                min = prices[i];
            }
        }
        return res;
    }

}


