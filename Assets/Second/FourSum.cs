using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FourSum : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	Four Sum
	和three sum 类似的一道题
	 */
	public IList<IList<int>> FourSum_(int[] nums, int target) {
        Array.Sort(nums);
        IList<IList<int>> result = new List<IList<int>>();
        for(int i = 0; i < nums.Length; i++){
            if(i > 0 && nums[i] == nums[i - 1]) continue;
            for(int j = i + 1; j < nums.Length; j++){
                if(j > i + 1 && nums[j] == nums[j - 1]) continue;
                int lo = j + 1;
                int hi = nums.Length - 1;
                while(lo < hi){
                    int sum = nums[i] + nums[j] + nums[lo] + nums[hi];
                    if(sum == target){
                        result.Add(new List<int>(){nums[i], nums[j], nums[lo], nums[hi]});
                        while(lo < hi && nums[lo] == nums[lo + 1]) lo++;
                        while(lo < hi && nums[hi] == nums[hi - 1]) hi--;
                        lo++;
                        hi--;
                    }else if(sum > target) hi--;
                    else lo++;
                }
            }
        }
        return result;
    }
}
