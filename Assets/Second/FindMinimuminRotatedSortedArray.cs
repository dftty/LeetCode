using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindMinimuminRotatedSortedArray : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	/**
	Discuss解法
	https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/

	二分查找，其实每次只需要比较hi和mid的值即可
	 */
	public int FindMin(int[] nums) {
        if(nums == null || nums.Length == 0) return 0;
        
        int low = 0;
        int hi = nums.Length - 1;
        
        while(low < hi){
            int mid = (low + hi) / 2;
            if(nums[mid] < nums[hi]){
                hi = mid;
            }else if(nums[mid] > nums[hi]){
                low = mid + 1;
            }
        }
        
        return nums[low];
    }

	/**
	自己的解法
	 */
	public int FindMin_(int[] nums) {
        if(nums == null || nums.Length == 0) return 0;
        
        int low = 0;
        int hi = nums.Length - 1;
        
        while(low < hi){
            int mid = (low + hi) / 2;
            if(nums[mid] >= nums[low]){
                if(nums[mid] > nums[hi]){
                    low = mid + 1;
                }else{
                    hi = mid;
                }
            }else{
                if(nums[mid] > nums[hi]){
                    low = mid;
                }else{
                    hi = mid;
                }
                
            }
        }
        
        return nums[low];
    }
}
