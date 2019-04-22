using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MaximumSumofTwoNonOverlappingSubarrays : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	Maximum Sum of Two Non-Overlapping Subarrays
	
	看了提示想到的解法，时间复杂度是O(n^2)
	首先计算出这个数组的prefix sum， prefix sum 知识请看 ： https://en.wikipedia.org/wiki/Prefix_sum
	然后遍历数组，根据当前L长度子数组，计算前面和后面最大的M长度子数组
	 */
	public int MaxSumTwoNoOverlap(int[] A, int L, int M) {
        int[] prefixSum = new int[A.Length + 1];
        for(int i = 1; i <= A.Length; i++){
            prefixSum[i] = prefixSum[i - 1] + A[i - 1];
        }
        int result = 0;
        for(int i = L; i <= A.Length; i++){
            int maxL = prefixSum[i] - prefixSum[i - L];
            for(int j = M; j <= i - L; j++){
                result = Math.Max(result, maxL + prefixSum[j] - prefixSum[j - M]);
            }
            
            for(int j = i + M; j <= A.Length; j++){
                result = Math.Max(result, maxL + prefixSum[j] - prefixSum[j - M]);
            }
        }
        
        return result;
    }

	/**
	Discuss O(n) solution DP
	 */
	public int MaxSumTwoNoOverlap_Discuss(int[] A, int L, int M){
		for(int i = 1; i < A.Length; i++){
			A[i] += A[i - 1];
		}

		int result = A[L + M - 1];
		int Lmax = A[L - 1];
		int Mmax = A[M - 1];

		for(int i = L + M; i < A.Length; i++){
			Lmax = Math.Max(Lmax, A[i - M] - A[i - M - L]);
			Mmax = Math.Max(Mmax, A[i - L] - A[i - M - L]);

			result = Math.Max(result, Math.Max(Lmax + A[i] - A[i - M], Mmax + A[i] - A[i - L]));
		}

		return result;
	}


}
