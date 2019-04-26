using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JumpGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	Jump Game
	贪心算法
	记录第一个数组的值，然后遍历后面的数组,
	遍历的时候首先需要判断是否可以跳到这里，如果不行，则直接返回false
	然后接下来可以跳的距离就等于jumpLength - 1 和nums[i] 中较大的一个数
	 */
	public bool CanJump(int[] nums) {
        int jumpLength = nums[0];
        for(int i = 1; i < nums.Length; i++){
            if(jumpLength == 0){
                return false;
            }
            
            jumpLength = Math.Max(jumpLength - 1, nums[i]);
        }
        
        return true;
    }

	/**
	另一种贪心解法
	 */
	public bool canJump(int[] nums){
		int max = 0;
		for(int i = 0; i < nums.Length; i++){
			if(i > max) return false;
			max = Math.Max(nums[i] + i, max);
		}

		return true;
	}

}
