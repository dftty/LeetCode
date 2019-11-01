using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NextPermutation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	Next Permutation

	全排列问题，给你一个数组的排列，找出这个数组的下一个排列

	例如对于数组 0, 1, 2, 5, 3, 3, 0
	首先找到第一个非递减的数组下标，如果这个下标不存在，则表示这个排列是全排列的最后一个
	上面的数组该下标为 k=2， 然后从右向左找到第一个大于该下标的值的下标，上面数组下标为j=5
	然后首先交换这两个下标的值，交换后为 
	0, 1, 3, 5, 3, 2, 0
	最后，对下标k=3到数组最后的子序列Reverse,得到
	0, 1, 3, 0, 2, 3, 5
	 */
	public void NextPermutation_(int[] nums) {
        int k = -1;
        int j = 0;
        for(int i = nums.Length - 2; i >= 0; i--){
            if(nums[i] < nums[i + 1]){
                k = i;
                break;
            }
        }
        
        if(k < 0){
            Array.Reverse(nums);
        }else{
            for(int i = nums.Length - 1; i >= 0; i--){
                if(nums[i] > nums[k]){
                    j = i;
                    break;
                }
            }
            Swap(nums, j, k);
            Array.Reverse(nums, k + 1, nums.Length - k - 1);
        }
    }
    
    public void Swap(int[] nums, int i, int j){
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }
}
