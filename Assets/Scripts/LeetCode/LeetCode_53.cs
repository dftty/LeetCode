using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_53 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int[] nums = new int[]{-2,1,-3,4,-1,2,1,-5,4};
		Debug.Log(MaxSubArray(nums));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Easy DP problem  https://leetcode.com/problems/maximum-subarray/description/
	// 2018/2/12
	// reference Discuss find out this solution, not solve by myself
	public int MaxSubArray(int[] nums) {
		int max = nums[0];
		int[] maxs = new int[nums.Length];
		maxs[0] = nums[0];
		for(int i = 1; i < nums.Length; i++){
			maxs[i] = Math.Max(nums[i] + maxs[i - 1], nums[i]);
			max = Math.Max(max, maxs[i]);
		}

		return max;
    }




}
