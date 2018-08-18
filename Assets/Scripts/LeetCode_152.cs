using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_152 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log(MaxProduct(new int[]{-1, -2, -9, -6}));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/maximum-product-subarray/description/
	// 2018/3/21
	// discuss solution, not by myself
	public int MaxProduct(int[] nums) {
        int r = nums[0];
        
        int imax = r, imin = r;
        
        for(int i = 1; i < nums.Length; i++){
            if(nums[i] < 0){
                int temp = imax;
                imax = imin;
                imin = temp;
            }
            
            imax = Math.Max(nums[i], imax * nums[i]);
            imin = Math.Min(nums[i], imin * nums[i]);
            
            r = Math.Max(r, imax);
        }
        
        return r;
    }
}
