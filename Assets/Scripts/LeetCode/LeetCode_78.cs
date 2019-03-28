using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_78 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Subsets(new int[]{1, 2, 3});
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/subsets/description/
	// 2018/3/11 
	// 回溯法
	public IList<IList<int>> Subsets(int[] nums) {
        if(nums == null){
            return new List<IList<int>>();
        }
        
        List<IList<int>> result = new List<IList<int>>();
        
        result.Add(new List<int>());
        
        BackTrack(nums, 0, new List<int>(), result);
        
        return result;
    }
    
    public void BackTrack(int[] nums, int t, IList<int> temp, IList<IList<int>> result){
        if(temp.Count != 0) result.Add(new List<int>(temp));
        if(t == nums.Length) return ;
        for(int i = t; i < nums.Length; i++){
            temp.Add(nums[i]);
            BackTrack(nums, i + 1, temp, result);
            temp.Remove(nums[i]);
        }
    } 
}
