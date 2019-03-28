using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_33 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int[] nums = new int[]{5, 1,2, 3,4};
		Debug.Log(Search(nums, 4));
		Debug.Log(Search(nums, 5));
		Debug.Log(Search(nums, 1));
		Debug.Log(Search(nums, 2));
		Debug.Log(Search(nums, 3));
		Debug.Log(Search(nums, 0));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/search-in-rotated-sorted-array/description/
	// 2018/2/20
	// idea   whatever you split array to left array and right array, 
	// left array and right array must have a ascending array,
	// check if target in that ascending array, then adjust pointer
	public int Search(int[] nums, int target) {
        int lo = 0;
		int hi = nums.Length - 1;
		do{
			int middle = (lo + hi) / 2;
			if(nums[middle] == target){
				return middle;
			}

			if(nums[middle] >= nums[lo]){
				if(target >= nums[lo] && target <= nums[middle]){
					hi = middle - 1;
				}else{
					lo = middle + 1;
				}
			}else if(nums[middle] <= nums[lo]){
				if(target <= nums[hi] && target >= nums[middle]){
					lo = middle + 1;
				}else{
					hi = middle - 1;
				}
			}

		}while(lo <= hi);
		
		return -1;
	
    }


	//Discuss solution
	public int Search_Diss(int[] nums, int target) {
		int lo = 0;
		int hi = nums.Length;

		while(lo < hi){
			int mid = (lo + hi) / 2;
			if(nums[mid] > nums[hi]) lo = mid + 1;
			else hi = mid;
		}

		int rot = lo;
		lo = 0;
		hi = nums.Length;
		while(lo <= hi){
			int mid = (lo + hi) / 2;
			int readmid = (mid + rot) % nums.Length;
			if(nums[readmid] == target) return readmid;
			if(nums[readmid] < target) lo = readmid + 1;
			else hi = readmid - 1;
		}

		return -1;
    }

	
}
