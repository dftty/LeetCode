using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CombinationSumII : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	Combination Sum II
	Given a collection of candidate numbers (candidates) and a target 
	number (target), find all unique combinations in candidates where 
	the candidate numbers sums to target.
	Each number in candidates may only be used once in the combination.

	类似于CombinationSum，本题数组会出现重复元素，并且每个数只能在一个组合中使用一次，
	因此需要加一条判断，判断当前元素是否和上次使用元素相同
	 */
	public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
        Array.Sort(candidates);
        IList<IList<int>> result = new List<IList<int>>();
        Search(new List<int>(), result, target, 0, candidates);
        return result;
    }
    
    public void Search(List<int> temp, IList<IList<int>> result, int remain, int start, int[] nums){
        if(remain < 0){
            return ;
        }else if(remain == 0){
            result.Add(new List<int>(temp));
        }else{
            for(int i = start; i < nums.Length; i++){
                if(i > start && nums[i] == nums[i - 1]) continue;
                temp.Add(nums[i]);
                Search(temp, result, remain - nums[i], i + 1, nums);
                temp.RemoveAt(temp.Count - 1);
            }
        }
    }
}
