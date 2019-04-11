using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CombinationSum : MonoBehaviour {

	// Use this for initialization
	void Start () {
		CombinationSum_(new int[]{8,7,4,3}, 11);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /**
    Combination Sum
    Given a set of candidate numbers (candidates) (without duplicates) 
    and a target number (target), find all unique combinations in candidates 
    where the candidate numbers sums to target.

    回溯算法题，需要判断好返回条件和递归的条件
     */
	public IList<IList<int>> CombinationSum_(int[] candidates, int target) {
        Array.Sort(candidates);
        IList<IList<int>> result = new List<IList<int>>();
        Search(new List<int>(), 0, result, target, candidates);
        
        return result;
    }
    
    public void Search(List<int> temp, int start, IList<IList<int>> result, int target, int[] nums){
        int sum = 0;
        if(temp.Count > 0){
            for(int i = 0; i < temp.Count; i++){
                sum += temp[i];
            }
            
            if(sum == target){
                result.Add(new List<int>(temp));
                return;
            }
        }
        
        for(int i = start; i < nums.Length; i++){
            if(sum + nums[i] > target) break;
            temp.Add(nums[i]);
            Search(temp, i, result, target, nums);
            temp.RemoveAt(temp.Count - 1);
        }
        
        return;
    }

    /**
    Discuss解法
    remain代表本次目标值还剩多少
     */
    public List<List<int>> combinationSum(int[] nums, int target) {
        List<List<int>> list = new List<List<int>>();
        Array.Sort(nums);
        backtrack(list, new List<int>(), nums, target, 0);
        return list;
    }

    private void backtrack(List<List<int>> list, List<int> tempList, int [] nums, int remain, int start){
        if(remain < 0) return;
        else if(remain == 0) list.Add(new List<int>(tempList));
        else{ 
            for(int i = start; i < nums.Length; i++){
                tempList.Add(nums[i]);
                backtrack(list, tempList, nums, remain - nums[i], i); // not i + 1 because we can reuse same elements
                tempList.RemoveAt(tempList.Count - 1);
            }
        }
    }
}
