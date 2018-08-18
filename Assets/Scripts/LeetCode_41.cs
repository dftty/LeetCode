using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_41 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Hard https://leetcode.com/problems/first-missing-positive/description/
	// 2018/3/30
	public int FirstMissingPositive(int[] nums) {
        if(nums == null || nums.Length == 0){
            return 1;
        }
        
        int[] temp = new int[nums.Length];
        
        for(int i = 0;  i< nums.Length; i++){
            if(nums[i] > 0 && nums[i] <= nums.Length){
                temp[nums[i] - 1] = 1;
            }
        }
        
        int result = 0;
        
        for(; result < temp.Length; result++){
            if(temp[result] == 0){
                return result + 1;
            }
        }
        
        return result + 1;
    }
}
