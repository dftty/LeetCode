using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_162 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/find-peak-element/description/
	// 2018/3/27
    //
	public int FindPeakElement(int[] nums) {
        if(nums == null || nums.Length == 0) return 0;
        int lo = 0;
        int hi = nums.Length - 1;
        
        while(lo <= hi){
            int middle = (lo + hi) >> 1;
            if(middle == nums.Length - 1) return middle;
            else if(middle > 0 && nums[middle] > nums[middle - 1] && nums[middle] > nums[middle + 1]) return middle;
            
            if(nums[middle] < nums[middle + 1]){
                lo = middle + 1;
            }else{
                hi = middle - 1;
            }
        }
        
        return 0;
    }
}
