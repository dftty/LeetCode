using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_80 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii/description/
	// 2018/3/13
	public int RemoveDuplicates(int[] nums) {
        if(nums == null || nums.Length == 0){
            return 0;
        }
        
        int length = 1;
        int count = 1;
        
        int compare = nums[0];
        
        for(int i = 1; i < nums.Length; i++){
            if(nums[i] == compare && count < 2){
                count++;
                nums[length++] = nums[i];
            }else if(nums[i] == compare){
                continue;
            }else{
                count = 1;
                compare = nums[i];
                nums[length++] = nums[i];
            }
        }
        
        return length;
    }
}
