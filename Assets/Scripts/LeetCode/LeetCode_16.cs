using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_16 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int[] nums = new int[]{-1, 2, 1, -4};
		Debug.Log(ThreeSumClosest(nums, 1));

		// this operation is wrong
		//Debug.Log(int.MaxValue + 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium  https://leetcode.com/problems/3sum-closest/description/
    // 2018/2/17
	// before you use int.MaxValue and int.MinValue to operation,
	// you should think it could cause overflow error
	public int ThreeSumClosest(int[] nums, int target) {
        int result = int.MaxValue;
        if(nums.Length <= 2){
            return result;
        }
        
        result = nums[0] + nums[1] + nums[2];
        Array.Sort(nums);
        for(int i = 0; i < nums.Length; i++){
            int lo = i + 1;
            int hi = nums.Length - 1;
            while(lo < hi){
                int sum = nums[i] + nums[lo] + nums[hi];
                
                if(Math.Abs(sum - target) < Math.Abs(result - target)){
                    result = sum;
                }
                if(sum < target) lo++;
                else hi--;
            }
        }
        
        return result;
    }
}
