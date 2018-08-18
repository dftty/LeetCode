using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_18 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int[] nums = new int[]{-1,0,1,2,-1,-4};
		FourSum(nums, -1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/4sum/description/
	// 2018/2/17
	// like threesum and three sum closest,but in j round, we need extra variation to keep j is not repeat
	public IList<IList<int>> FourSum(int[] nums, int target) {
		IList<IList<int>> result = new List<IList<int>>();
		Array.Sort(nums);
		int prej = int.MinValue;
		for(int i = 0; i < nums.Length; i++){
			if(i == 0 || (i > 0 && nums[i] != nums[i - 1])){				
				prej = int.MinValue;
				for(int j = i + 1; j < nums.Length; j++){
					if(nums[j] == prej){
						continue;
					}
					int lo = j + 1;
					int hi = nums.Length - 1;
					int sum = nums[i] + nums[j];

					while(lo < hi){
						if(target - sum == nums[lo] + nums[hi]){
							result.Add(new List<int>(){nums[i], nums[j], nums[lo], nums[hi]});
							while(lo < hi && nums[lo] == nums[lo + 1]) lo++;
							while(lo < hi && nums[hi - 1] == nums[hi]) hi--;
							lo++;
							hi--;
						}else if(target - sum > nums[lo] + nums[hi]){
							lo++;
						}else hi--;
					}
					prej = nums[j];
				}
			}
		}

		return result;
    }
}
