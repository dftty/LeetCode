using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_26 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int[] nums = new int[]{1,1,2};

		Debug.Log(RemoveDuplicates(nums));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Easy  https://leetcode.com/problems/remove-duplicates-from-sorted-array/description/
	// 2018/2/11
	// 思考的时候没有考虑空数组情况,所以导致异常
	public int RemoveDuplicates(int[] nums) {
		int index = 0;

		if(nums.Length == 0){
			return index;
		}

		for(int i = 1; i < nums.Length; i++){
			// 此处直接判断是否相等即可
			if((nums[i] ^ nums[i - 1]) != 0){
				nums[index + 1] = nums[i];
				index++;
			}
		}
		return index + 1;
    }
}
