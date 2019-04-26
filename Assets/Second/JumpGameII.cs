using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JumpGameII : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	Jump Game II
	贪心算法 Discuss
	 */
	public int Jump(int[] nums) {
        int result = 0;
		int curEnd = 0;
		int curFarthest = 0;

		for(int i = 0; i < nums.Length; i++){
			curFarthest = Math.Max(curFarthest, i + nums[i]);
			if(i == curEnd){
				result++;
				curEnd = curFarthest;
			}
		}
        
        return result;
    }

	/**
	My ac solution
	 */
	public int Jump_(int[] nums) {
        if(nums.Length == 1) return 0;
        int result = 0;
        int jump = nums[0];
        for(int i = 0; i < nums.Length; ){
            int nextjump = 0;
            int length = jump + i + 1;
            for(int j = i + 1; j < length; j++){
                if(j < nums.Length - 1){
                    if(j + nums[j] > nextjump + i){
                        nextjump = nums[j];
                        i = j;
                    }
                }else {
                    return result + 1;
                }
            }
            jump = nextjump;
            result++;
        }
        
        return result;
    }
}
