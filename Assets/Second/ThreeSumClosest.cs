using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ThreeSumClosest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	3Sum Closest
	Given an array nums of n integers and an integer target, 
	find three integers in nums such that the sum is closest 
	to target. Return the sum of the three integers. You may 
	assume that each input would have exactly one solution.

	和ThreeSum类似，而且不需要检查重复元素。
	 */
	public int ThreeSumClosest_(int[] nums, int target) {
        Array.Sort(nums);
        int result = nums[0] + nums[1] + nums[2];
        for(int i = 0; i < nums.Length; i++){
            int lo = i + 1;
            int hi = nums.Length - 1;
            while(lo < hi){
                if(Math.Abs(nums[i] + nums[lo] + nums[hi] - target) < Math.Abs(result - target)){
                    result = nums[i] + nums[lo] + nums[hi];
                }
                
                if(nums[i] + nums[lo] + nums[hi] > target){
                    hi--;
                }else{
                    lo++;
                }
            }
        }
        
        return result;
    }
}
