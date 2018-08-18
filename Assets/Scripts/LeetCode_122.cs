using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_122 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Easy https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/description/
	// 2018/2/13
	public int MaxProfit(int[] prices) {
        int result = 0;
        if(prices.Length == 0){
            return result;
        }
        int buy = prices[0];
        for(int i = 1 ; i < prices.Length; i++){
            if(prices[i] > buy){
                result += prices[i] - buy;
            }
            buy = prices[i];
        }
        return result;
    }
}
