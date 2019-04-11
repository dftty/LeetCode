using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveDuplicatesfromSortedArray : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	Remove Duplicates from Sorted Array
	Given a sorted array nums, remove the duplicates in-place such
	 that each element appear only once and return the new length.

	Do not allocate extra space for another array, you must do 
	this by modifying the input array in-place with O(1) extra memory.

	Easy题，之间使用一个int值表示非重复值的下标来进行循环即可
	 */
	public int RemoveDuplicates(int[] nums) {
        if(nums == null || nums.Length == 0) return 0;
        int currentIndex = 1;
        for(int i = 1; i < nums.Length; i++){
            if(nums[i] == nums[i - 1]){
                continue;
            }else{
                nums[currentIndex++] = nums[i];
            }
        }
        return currentIndex;
    }
}
