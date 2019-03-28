using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_1021 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="A"></param>
    /// <returns></returns>
	public int MaxScoreSightseeingPair(int[] A) {
        int result = 0;
        int leftMax = A[0];
        
        for(int i = 1; i < A.Length; i++){
            result = Math.Max(result, leftMax + A[i] - i);
            leftMax = Math.Max(leftMax, A[i] + i);
        }
        
        return result;
    }
}
