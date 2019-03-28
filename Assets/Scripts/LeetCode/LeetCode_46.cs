using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_46 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log(Permute(new int[]{1, 2, 3}));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/permutations/description/
	// 2018/8/12
	// Discuss solution
	public IList<IList<int>> Permute(int[] nums) {
        List<IList<int>> result = new List<IList<int>>();
        backTrack(result, new List<int>(), nums);
        return result;
    }
    
    public void backTrack(List<IList<int>> result, List<int> temp, int[] nums){
        if(temp.Count == nums.Length){
            result.Add(new List<int>(temp));
        }else{
            for(int i = 0; i < nums.Length; i++){
                if(temp.Contains(nums[i])) continue;
                temp.Add(nums[i]);
                backTrack(result, temp, nums);
                temp.RemoveAt(temp.Count);
            }
        }
    }
}
