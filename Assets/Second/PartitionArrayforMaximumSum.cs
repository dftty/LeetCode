using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PartitionArrayforMaximumSum : MonoBehaviour {

	// Use this for initialization
	void Start () {
		MaxSumAfterPartitioning(new int[]{1,15,7,9,2,5,10}, 3);
		char[,] temp = new char[1, 1];
		Debug.Log(temp[0, 0] == '\0');
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	/**
	DP 问题
	dp[i] 中保存的是从A[0] 到A[i] 的最大值
	 */
	public int MaxSumAfterPartitioning(int[] A, int K) {
        int len = A.Length; 
        int[] dp = new int[len];
        
        for(int i = 0; i < len; i++){
            int curMax = 0;
            for(int k = 1; k <= K && (i - k + 1) >= 0; k++){
                curMax = Math.Max(curMax, A[i - k + 1]);
                dp[i] = Math.Max(dp[i], (i - k >= 0 ? dp[i - k] : 0) + curMax * k);
            }
        }
        
        return dp[len - 1];
    }
}
