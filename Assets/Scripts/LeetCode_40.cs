using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_40 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//int[] nums = new int[]{10, 1, 2, 7, 6, 1, 5};
		//int[] nums = new int[]{2, 5, 2, 1, 2};   5
		int[] nums = new int[]{1, 1, 1, 3, 3, 5};
		CombinationSum2(nums, 8);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IList<IList<int>> CombinationSum2(int[] candidates, int target){
		IList<IList<int>> result = new List<IList<int>>();
		Array.Sort(candidates);
		backtrack(result, new List<int>(), candidates, target, 0);
		return result;
	}

	private void backtrack(IList<IList<int>> result, List<int> temp, int[] nums, int remain, int start){
		if(remain < 0) return;
		else if(remain == 0) {
			result.Add(new List<int>(temp));
		}else{
			for(int i = start; i < nums.Length; i++){
				if(i > start && nums[i] == nums[i - 1]) continue;
				temp.Add(nums[i]);
				backtrack(result, temp, nums, remain - nums[i], i + 1);
				temp.RemoveAt(temp.Count - 1);
			}
		}
	}
}
