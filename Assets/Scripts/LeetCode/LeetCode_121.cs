using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_121 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Easy  https://leetcode.com/problems/best-time-to-buy-and-sell-stock/description/
	// 2018/2/13  Time O(n) Space O(1)
	// every step ,if this num is the min, then use this num to min, then compute 
	// this num minus min, then compare to result. 
	public int MaxProfit(int[] prices) {
        int result = 0;
        
        if(prices.Length == 0){
            return result;
        }
        
        int min = prices[0];
        
        for(int i = 1; i < prices.Length; i++){
            if(min > prices[i]){
				min = prices[i];
			}
            
            if(prices[i] - min > result){
                result = prices[i] - min;
            }
        }
        
        return result;
    }
}
