using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindFirstandLastPositionofElementinSortedArray : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	Find First and Last Position of Element in Sorted Array
	Given an array of integers nums sorted in ascending order, 
	find the starting and ending position of a given target value.
	Your algorithm's runtime complexity must be in the order of O(log n).
	If the target is not found in the array, return [-1, -1].

	二分查找问题，数组中可能有多个目标元素，找到最低和最高下标
	可以分为两次查找，第一次找到最低下标，第二次查找最高下标
	 */
	public int[] SearchRange(int[] nums, int target) {
        int[] result = new int[2]{-1, -1};
        
        int lo = 0;
        int hi = nums.Length - 1;
        while(lo <= hi){
            int mid = (lo + hi) / 2;
            if(nums[mid] >= target){
                hi = mid - 1;
				result[0] = mid;
            }else if(nums[mid] < target){
                lo = mid + 1;
            }
        }
        
        lo = 0;
        hi = nums.Length - 1;
        while(lo <= hi){
            int mid = (lo + hi) / 2;
            if(nums[mid] > target){
                hi = mid - 1;
            }else if(nums[mid] <= target){
                lo = mid + 1;
				result[1] = mid;
            }
        }
        
        return result;
    }
}
