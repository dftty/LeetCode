using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ThreeSum : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	3Sum
	Given an array nums of n integers, are there elements a, b, c in nums 
	such that a + b + c = 0? Find all unique triplets in the array which gives the sum of zero.

	Note:
	The solution set must not contain duplicate triplets.

	不可以包含重复的结果，那么可以首先对数组进行排序，然后进行循环，如果遇到相同元素，则跳过。
	循环方式对于外层整体循环一遍数组，在内层中，采用TwoPointer方法，来降低时间复杂度。
	 */
	public IList<IList<int>> ThreeSum_(int[] nums) {
        Array.Sort(nums);
        IList<IList<int>> result = new List<IList<int>>();
        for(int i = 0; i < nums.Length; i++){
            if(i > 0 && nums[i] == nums[i - 1]) continue;
            int j = i + 1;
            int k = nums.Length - 1;
            while(j < k){
				// 这里两个while循环可以放在下面的if语句中，但需要稍作调整。
                while(j > i + 1 && j < k && nums[j] == nums[j - 1]) j++;
                while(k < nums.Length - 1 && k > j && nums[k] == nums[k + 1]) k--;
                
                if(j < k && nums[i] + nums[j] + nums[k] == 0){
                    IList<int> temp = new List<int>(){nums[i], nums[j], nums[k]};
                    result.Add(temp);
                }
                
                if(nums[i] + nums[j] + nums[k] > 0){
                    k--;
                }else{
                    j++;
                }
            }
        }
        
        return result;
    }

    /**
    更加精简的写法
     */
    public IList<IList<int>> ThreeSum_1(int[] nums) {
        Array.Sort(nums);
        IList<IList<int>> result = new List<IList<int>>();
        for(int i = 0; i < nums.Length; i++){
            if(i > 0 && nums[i] == nums[i - 1]) continue;
            int lo = i + 1;
            int hi = nums.Length - 1;
            while(lo < hi){
                int sum = nums[lo] + nums[hi];
                if(nums[i] + sum == 0){
                    result.Add(new List<int>(){nums[i], nums[lo], nums[hi]});
                    while(lo < hi && nums[lo] == nums[lo + 1]) lo++;
                    while(lo < hi && nums[hi] == nums[hi - 1]) hi--;
                    lo++;
                    hi--;
                }else if(nums[i] + sum > 0) hi--;
                else lo++;
            }
        }
        
        return result;
    }
}
