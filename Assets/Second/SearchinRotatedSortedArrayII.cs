using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchinRotatedSortedArrayII : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	Search in Rotated Sorted Array II
	这次的数组中会出现重复元素， 还是利用二分查找
	查找算法的最坏情况是 O(n)
	 */
	public bool Search(int[] nums, int target) {
        int lo = 0;
        int hi = nums.Length - 1;
        
        while(lo <= hi){
            if(nums[lo] == target || nums[hi] == target) return true;
            while(lo < hi && nums[lo] == nums[lo + 1]) lo++;
            while(lo < hi && nums[hi] == nums[hi - 1]) hi--;
            int mid = (lo + hi) / 2;
            if(nums[mid] == target) return true;
            if(nums[lo] <= nums[mid]){
                if(nums[lo] <= target && target < nums[mid]){
                    hi = mid - 1;
                }else{
                    lo = mid + 1;
                }
            }else {
                if(target > nums[mid] && target <= nums[hi]){
                    lo = mid + 1;
                }else{
                    hi = mid - 1;
                }
            }
        }
        
        return false;
    }
}
