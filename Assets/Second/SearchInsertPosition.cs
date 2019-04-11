using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchInsertPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	Search Insert Position
	Given a sorted array and a target value, return the index if 
	the target is found. If not, return the index where it would be if it were inserted in order.
	You may assume no duplicates in the array.

	二分查找
	 */
	public int SearchInsert(int[] nums, int target) {
        if(nums == null ) return 0;
        
        int lo = 0;
        int hi = nums.Length - 1;
        while(lo <= hi){
            int mid = (lo + hi) / 2;
            if(nums[mid] == target){
                return mid;
            }else if(nums[mid] < target){
                lo = mid + 1;
            }else{
                hi = mid - 1;
            }
        }
        
        return lo;
    }
}
