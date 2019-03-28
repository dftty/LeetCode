using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_1014 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="weights"></param>
	/// <param name="D"></param>
	/// <returns></returns>
	public int ShipWithinDays(int[] weights, int D) {
        int left = 0;
        int right = 0;
        for(int i = 0; i < weights.Length; i++){
            left = Math.Max(left, weights[i]);
            right += weights[i];
        }
        
        while(left < right){
            int need = 1;
            int count = 0;
            int mid = (left + right) / 2;
            for(int i = 0; i < weights.Length; i++){
                if(count + weights[i] > mid){
                    count = 0;
                    need++;
                }
                count += weights[i];
            }
            
			// 这里左边选择了每次递增1
            if(need > D) left += 1;
            else right = mid;
        }
        
        return left;
    }
}
