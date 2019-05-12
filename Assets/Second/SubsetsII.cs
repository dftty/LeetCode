using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SubsetsII : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IList<IList<int>> SubsetsWithDup(int[] nums) {
        IList<IList<int>> result = new List<IList<int>>();
        if(nums == null || nums.Length == 0) return result;
        Array.Sort(nums);
        BackTrack(result, new List<int>(), 0, nums);
        return result;
    }
    
    public void BackTrack(IList<IList<int>> result, IList<int> temp, int n, int[] nums){
        if(n > nums.Length) return ;
        result.Add(new List<int>(temp));
        for(int i = n; i < nums.Length; i++){
            if(i > n && nums[i] == nums[i - 1]) continue;
            temp.Add(nums[i]);
            BackTrack(result, temp, i + 1, nums);
            temp.RemoveAt(temp.Count - 1);
        }
    }
}
