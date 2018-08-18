using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_153 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log(FindMin(new int[]{4, 5, 6, 7, 8, 9, 10, 11, 0, 1, 2, 3}));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Medium https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/description/
    // 2018/3/27
	public int FindMin(int[] nums) {
        if(nums == null || nums.Length == 0){
            return 0;
        }
        
        if(nums.Length == 1){
            return nums[0];
        }
        
        return find(nums);
    }
    
    public int find(int[] nums){
        int lo = 0;
        int hi = nums.Length - 1;
        
        if(nums[0] < nums[nums.Length - 1]) return nums[0];
        
        while(lo <= hi){
            int middle = (lo + hi) >> 1;
            
            if(middle > 0 && nums[middle] < nums[middle - 1]){
                return nums[middle];
            }
            
            if(nums[lo] > nums[hi]){
				if(nums[middle] > nums[hi]){
					lo = middle + 1;
				}else {
					hi = middle - 1;
				}
            }else{
                hi = middle - 1;
            }
        }
        
        return -1;
    }
}
