using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_31 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/next-permutation/description/
	// 2018/2/19
	// This is discuss solution, not by my self
	// next permutation
	public void NextPermutation(int[] nums) {
        if(nums.Length <= 1){
            return ;
        }
        
        int i = nums.Length - 1;
        for(; i >= 1; i--){
            if(nums[i] > nums[i - 1]){
                break;
            }
        }
        
        if(i != 0){
            swap(nums, i - 1);
        }
        reverse(nums, i);
    }
    
    private void swap(int[] nums, int i){
        for(int j = nums.Length - 1; j > i; j--){
            if(nums[j] > nums[i]){
                int temp = nums[j];
                nums[j] = nums[i];
                nums[i] = temp;
                break;
            }
        }
    }
    
    private void reverse(int[] nums, int i){
        int j = nums.Length - 1;
        while(i < j){
            int temp = nums[j];
            nums[j] = nums[i];
            nums[i] = temp;
            i++;
            j--;
        }
    }
}
