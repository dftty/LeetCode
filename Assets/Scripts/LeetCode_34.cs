using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_34 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int[] nums = new int[]{5, 7, 7, 8, 8, 10};
		int[] result = SearchRange(nums, 6);
		Debug.Log(result[0] + "   " + result[1]);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/search-for-a-range/description/
	// 2018/2/20
	// bineary search
	public int[] SearchRange(int[] nums, int target) {
        int[] range = new int[]{-1, -1};

		if(nums.Length == 0){
			return range;
		}
		if(target < nums[0] || target > nums[nums.Length - 1]){
			return range;
		}

		int lo = 0;
		int hi = nums.Length - 1;
		// find left
		while(lo <= hi){
			int middle = (lo + hi) / 2;
			int premiddle = middle - 1 < 0 ? middle : middle - 1;
			if(nums[middle] == target && nums[premiddle] < target){
				range[0] = middle;
				break;
			}else if(nums[middle] == target && middle == 0){
				range[0] = 0;
				break;
			}else if(hi == lo){
				break;
			}

			if(nums[middle] >= target){
				hi = middle - 1;
			}else{
				lo = middle + 1;
			}
		}

		lo = 0;
		hi = nums.Length - 1;
		while(lo <= hi){
			int middle = (lo + hi) / 2;
			int next = middle + 1 > nums.Length - 1 ? nums.Length - 1 : middle + 1;
			if(nums[middle] == target && nums[next] > target){
				range[1] = middle;
				break;
			}else if(nums[middle] == target && middle == nums.Length - 1){
				range[1] = middle;
				break;
			}else if(lo == hi){
				break;
			}

			if(nums[middle] <= target){
				lo = middle + 1;
			}else {
				hi = middle - 1;
			}
		}

		return range;
    }
}
