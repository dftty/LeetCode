using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_55 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/jump-game/description/
	// 2018/2/25
	// idea   from back to front check if has 0
	public bool CanJump(int[] nums) {
        if(nums.Length <= 1){
            return true;
        }
        
        bool needCheck = false;
        int zeroIndex = nums.Length - 1;
        for(int i = nums.Length - 2; i >= 0; i--){
            if(needCheck && zeroIndex != nums.Length - 1){
                if(nums[i] > zeroIndex - i){
                    needCheck = false;
                }
                continue;
            }
            
            if(nums[i] > 0) continue;
            
            if(nums[i] == 0){
                zeroIndex = i;
                needCheck = true;
            }
        }
        
        return !needCheck;
    }

    public bool CanJump_Discuss(int[] nums) {
        int max = 0;

        for(int i = 0; i < nums.Length; i++){
            if(i > max) return false;
            max = Math.Max(nums[i] + i, max);
        }
        
        return true;
    }
}
