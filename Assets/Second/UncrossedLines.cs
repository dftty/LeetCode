using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UncrossedLines : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	典型的动态规划问题，和Longest Common Subsequence类似
	对于DP来说，可以将当前问题拆分成子问题去求解，高等级的子问题可以由低等级的子问题来解出。

	// 这是LCS的wiki描述
	https://en.wikipedia.org/wiki/Longest_common_subsequence_problem
	 */
	public int MaxUncrossedLines(int[] A, int[] B) {
        int[,]dp = new int[A.Length + 1, B.Length + 1];
        
        for(int i = 1; i <= A.Length; i++){
            for(int j = 1; j <= B.Length; j++){
                if(A[i - 1] == B[j - 1]){
                    dp[i, j] = 1 + dp[i - 1,j - 1];
                }else{
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
        }
        
        return dp[A.Length,B.Length];
    }
}
