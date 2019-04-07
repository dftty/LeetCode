using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchinRotatedSortedArray : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	Search in Rotated Sorted Array
	Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.

	(i.e., [0,1,2,4,5,6,7] might become [4,5,6,7,0,1,2]).

	You are given a target value to search. If found in the array return its index, otherwise return -1.

	You may assume no duplicate exists in the array.

	Your algorithm's runtime complexity must be in the order of O(log n).

	二分查找，虽然这个数组进行了移动，但是每次进行二分的时候，左右必定会出现一个递增的数组，
	然后就可以判断目标数是否在这个递增数组中，判断后就可以将上下指针增加或减少
	
	 */
	public int Search(int[] nums, int target) {
        if(nums == null) return -1;
        int lo = 0;
        int hi = nums.Length - 1;
        while(lo <= hi){
            int mid = (lo + hi) / 2;
            if(nums[mid] == target) return mid;
			// 这里的判断需要考虑边界情况，所以需要增加等号情况,做题的时候没有考虑边界情况，例如 [3, 1] 这个数组
            if(nums[lo] <= nums[mid]){
                if(target >= nums[lo] && target <= nums[mid]){
                    hi = mid - 1;
                }else{
                    lo = mid + 1;
                }
            }else{
                if(target >= nums[mid] && target <= nums[hi]){
                    lo = mid + 1;
                }else{
                    hi = mid - 1;
                }
            }
        }
        
        return -1;
    }
}
