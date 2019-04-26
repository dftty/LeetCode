using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MaximumSubarray : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	Maximum Subarray
	Discuss solution DP
	 */
	public int MaxSubArray(int[] nums) {
        int[] dp = new int[nums.Length];
        
        dp[0] = nums[0];
        int max = dp[0];
        for(int i = 1; i < nums.Length; i++){
            dp[i] = nums[i] + (dp[i - 1] > 0 ? dp[i - 1] : 0);
            max = Math.Max(max, dp[i]);
        }
        
        return max;
    }
}
