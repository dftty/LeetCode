using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MinimumScoreTriangulationofPolygon : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	Dolution 解法
	DP
	递推公式为从i到j的最小值可以分解为i到k和k + 1到j的最小值的和
	 */
	public int MinScoreTriangulation(int[] A) {
        int n = A.Length;
        int[,] dp = new int[n,n];
        
        for(int d = 2; d < n; d++){
            for(int i = 0; i + d < n; i++){
                int j = i + d;
                dp[i, j] = int.MaxValue;
                for(int k = i + 1; k < j; k++){
                    dp[i, j] = Math.Min(dp[i, j], dp[i, k] + dp[k, j] + A[i] * A[k] * A[j]);
                }
            }
        }
        
        return dp[0,n - 1];
    }
}
