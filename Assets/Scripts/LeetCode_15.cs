using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_15 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int[] nums = new int[]{3,0,-2,-1,1,2};
		ThreeSum(nums);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium  https://leetcode.com/problems/3sum/description/
	// 2018/2/17
	// O(n^2) time 
	// first cyclic boundary didn't clearly once, so made many mistake in this
	//
	public IList<IList<int>> ThreeSum(int[] nums) {
		DateTime start = DateTime.Now;
		IList<IList<int>> result = new List<IList<int>>();
        if(nums.Length <= 2){
			return result;
		}
		Array.Sort(nums);
		List<int> temp = new List<int>();
		int prei, prej, prek;
		prei = prej = int.MinValue;
		prek = int.MaxValue;
		for(int i = 0; i < nums.Length; i++){
			if(nums[i] > 0){
				break;
			}
			if(nums[i] == prei){
				continue;
			}
			prej = int.MinValue;
			prek = int.MaxValue;
			int j = i + 1;
			int k = nums.Length - 1;
			while(j < k){
				int sum = nums[i] + nums[j];
				if(nums[j] == prej){
					j++;
					continue;
				}
				if(nums[k] == prek){
					k--;
					continue;
				}
				if(sum + nums[k] == 0){
					temp = new List<int>();
					temp.Add(nums[i]);
					temp.Add(nums[j]);
					temp.Add(nums[k]);
					result.Add(temp);
					prej = nums[j];
					prek = nums[k];
					j++;
					k--;
				}else if(Math.Abs(nums[k]) > Math.Abs(sum)){
					prek = nums[k];
					k--;
				}else{
					prej = nums[j];
					j++;
				}
			}
			prei = nums[i];
		} 
		
		DateTime end = DateTime.Now;
		Debug.Log((end.Ticks - start.Ticks) / 10000);

		return result;
    }

	// Discuss solution
	// same idea,but clean code
	public IList<IList<int>> ThreeSum_Discuss(int[] nums) {
		IList<IList<int>> result = new List<IList<int>>();
		Array.Sort(nums);

		for(int i = 0; i < nums.Length; i++){
			if(i == 0 || (i > 0 && nums[i] != nums[i - 1])){
				int lo = i + 1;
				int hi = nums.Length - 1;
				int sum = 0 - nums[i];
				while(lo < hi){
					if(nums[lo] + nums[hi] == sum){
						result.Add(new List<int>(){nums[i], nums[lo], nums[hi]});
						while(lo < hi && nums[lo] == nums[lo + 1]) lo++;
						while(lo < hi && nums[hi - 1] == nums[hi]) hi--;
						lo++;
						hi--;
					}else if(nums[lo] + nums[hi] < sum) lo++;
					else hi++;
				}
			}
		}
		return result;
    }




}
