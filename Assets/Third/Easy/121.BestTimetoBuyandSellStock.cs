using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Third
{

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
        Easy
        Tag: 数组 动态规划

        思路：使用一个min变量记录当前遍历到的数字的前面一个最小值，
        然后用当前值减去最小值即可

        */
        public int MaxProfit(int[] prices) {
            if (prices == null || prices.Length == 0) return 0;
            int res = 0, min = prices[0];
            
            for (int i = 1; i < prices.Length; i++){
                res = Math.Max(res, prices[i] - min);
                min = Math.Min(min, prices[i]);
            }
            
            return res;
        }
    }

}