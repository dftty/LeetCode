using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_39 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int[] nums = new int[]{1, 2};
		combinationSum(nums, 4);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/combination-sum/description/
	// 2018/2/21 
	// discuss solution  backtrack
	public IList<IList<int>> combinationSum(int[] candidates, int target){
		IList<IList<int>> result = new List<IList<int>>();
		Array.Sort(candidates);
		backtrack(result, new List<int>(), candidates, target, 0);
		return result;
	}

	private void backtrack(IList<IList<int>> result, List<int> temp, int[] nums, int remain, int start){
		if(remain < 0) return;
		else if(remain == 0) result.Add(new List<int>(temp));
		else{
			for(int i = start; i < nums.Length; i++){
				temp.Add(nums[i]);
				backtrack(result, temp, nums, remain - nums[i], i);
				temp.RemoveAt(temp.Count - 1);
			}
		}
	}
}
