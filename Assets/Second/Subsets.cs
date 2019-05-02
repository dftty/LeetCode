using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Subsets : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	回溯法
	 */
	public IList<IList<int>> Subsets_(int[] nums) {
        Array.Sort(nums);
        IList<IList<int>> result = new List<IList<int>>();
        BackTrack(result, new List<int>(), nums, 0);
        return result;
    }
    
    public void BackTrack(IList<IList<int>> result, List<int> temp, int[] nums, int index){
        result.Add(new List<int>(temp));
        for(int i = index; i < nums.Length; i++){
            if(i > index && nums[i] == nums[i - 1]) continue;
            temp.Add(nums[i]);
            BackTrack(result, temp, nums, i + 1);
            temp.RemoveAt(temp.Count - 1);
        }
    }
}
