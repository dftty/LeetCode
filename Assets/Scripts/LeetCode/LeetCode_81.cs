using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_81 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log(Search(new int[]{3, 1}, 1));
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	// Medium https://leetcode.com/problems/search-in-rotated-sorted-array-ii/description/
	// 2018/3/14
	public bool Search(int[] nums, int target) {
        if(nums == null || nums.Length == 0){
            return false;
        }
        
        int lo = 0;
        int hi = nums.Length - 1;
        while(lo <= hi){
            while(lo + 1 < hi && nums[lo] == nums[lo + 1]) lo++;
            while(hi - 1 > lo && nums[hi] == nums[hi - 1]) hi--;
            
            if(lo > hi) break;
            
            int middle = (lo + hi) >> 1;
            
            if(nums[middle] == target) return true;
            
			if(nums[middle] >= nums[lo]){
				if(target >= nums[lo] && target < nums[middle]){
					hi = middle - 1;
				}else {
					lo = middle + 1;
				}
			}else if(nums[middle] <= nums[hi]){
				if(target > nums[middle] && target <= nums[hi]){
					lo = middle + 1;
				}else {
					hi = middle - 1;
				}
			}
        }
        
        return false;
    }
}
