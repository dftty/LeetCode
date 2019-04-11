using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstMissingPositive : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	
	First Missing Positive
	Given an unsorted integer array, find the smallest missing positive integer.
	要求O(n)时间 O(1)空间
	看了第一个提示想到O(n)空间的解法，思路就是创建一个长度和nums一样的数组，默认每个值为0
	然后遍历nums数组，如果遍历的值在0和nums的长度之间的，那么将space数组的nums[i] - 1的值赋值为1，表示nums中已经有这个下标加一表示的正整数了
	遍历完成后，遍历space数组，其中space[i]为0 就表示nums中不存在i + 1 这个数，如果space的值都为1，则表示第一个正整数为nums的长度加一

	 */
	public int FirstMissingPositive_(int[] nums) {
        int[] space = new int[nums.Length];
        
        for(int i = 0; i < nums.Length; i++){
            if(nums[i] > 0 && nums[i] <= nums.Length){
                space[nums[i] - 1] = 1;
            }
        }
        
        for(int i = 0; i < space.Length; i++){
            if(space[i] == 0){
                return i + 1;
            }
        }
        
        return space.Length + 1;
    }

	/**
	O(1)空间解法，利用已经遍历的数组空间
	 */
	public int FirstMissingPositive__(int[] nums) {
        int[] space = new int[nums.Length];
        
        for(int i = 0; i < nums.Length; i++){
            int temp = nums[i];
			if(temp <= 0) continue;
			while(temp > 0 && temp < nums.Length){
				
			}
		}
        
        
        
        return space.Length + 1;
    }
}
