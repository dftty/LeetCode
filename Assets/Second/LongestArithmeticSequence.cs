using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LongestArithmeticSequence : MonoBehaviour {

	// Use this for initialization
	void Start () {
		LongestArithSeqLength(new int[]{3, 6, 9, 12});
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	Longest Arithmetic Sequence

	动态规划 Disscuss solution
	 */
	public int LongestArithSeqLength(int[] A) {
        Dictionary<int, Dictionary<int, int>> dp = new Dictionary<int, Dictionary<int, int>>();
		int max = 2;

		for(int i = 0; i < A.Length; i++){
			for(int j = i + 1; j < A.Length; j++){
				int a = A[i], b = A[j];
				Dictionary<int, int> diff = null;
				if(dp.ContainsKey(b - a)){
					diff = dp[b - a];
				}else{
					diff = new Dictionary<int, int>();
					dp.Add(b - a, diff);
				}
				int first = 0, second = 0;
				diff.TryGetValue(j, out first);
				diff.TryGetValue(i, out second);
				int currMax = Math.Max(first, second + 1);
				if(!diff.ContainsKey(j)){
					diff.Add(j, currMax);
				}else{
					diff[j] = currMax;
				}
				max = Math.Max(max, currMax + 1);
			}
		}

		return max;
    }
}
