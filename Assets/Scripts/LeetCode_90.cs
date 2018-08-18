using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_90 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public IList<IList<int>> SubsetsWithDup(int[] nums) {
        Array.Sort(nums);
        List<IList<int>> result = new List<IList<int>>();
        result.Add(new List<int>());
        
        if(nums == null || nums.Length == 0){
            return result;
        }
        
        BackTrack(result, new List<int>(), nums, 0);
        
        return result;
    }
    
    public void BackTrack(List<IList<int>> result, List<int> temp, int[] nums, int n){
        if(temp.Count != 0) result.Add(new List<int>(temp));
        else if(n == nums.Length) return;
        
        for(int i = n; i < nums.Length; i++){
            if(i != n && nums[i] == nums[i - 1]) continue;
            temp.Add(nums[i]);
            BackTrack(result, temp, nums, i + 1);
            temp.Remove(nums[i]);
        }
    }
}
