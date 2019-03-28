using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_75 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/sort-colors/description/
	// 2018/3/11
	public void SortColors(int[] nums) {
        QuickSort(nums, 0, nums.GetLength(0) - 1);
    }
    
    void QuickSort(int[] nums, int p, int q){
        if(p > q) return ;
        
        int val = nums[p];
        int i = p;
        int j = q;
        
        while(i < j){
            while(i < j && nums[j] >= val) j--;
            while(i < j && nums[i] <= val) i++;
            
            if(i < j){
                int temp = nums[i];
                nums[i] = nums[j];
                nums[j] = temp;
            }
            
        }
        
        nums[p] = nums[i];
        nums[i] = val;
        
        QuickSort(nums, p, i - 1);
        QuickSort(nums, i + 1, q);
        
        return ;
    }
}
