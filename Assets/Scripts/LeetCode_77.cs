using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_77 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/combinations/description/
	// 2018/8/16
	// 从n中选取k个数，然后给出所有可能的组合
	public IList<IList<int>> Combine(int n, int k) {
        List<IList<int>> result = new List<IList<int>>();
        
		// 这个数组并非必要
        int[] nums = new int[n];
        for(int i = 0; i < n; i++){
            nums[i] = i + 1;
        }
        
        BackTrack(result, new List<int>(), nums, k, 0);
        return result;
    }
    
    public void BackTrack(List<IList<int>> result, List<int> temp, int[] nums, int k, int l){
        if(temp.Count == k){
            result.Add(new List<int>(temp));
        }else{
            for(int i = l; i < nums.Length; i++){
				// 这里可以直接添加i + 1
                temp.Add(nums[i]);
                BackTrack(result, temp, nums, k, i + 1);
                temp.RemoveAt(temp.Count - 1);
            }
        }
    }

	// Discuss solution
	// not backtrack
	public IList<IList<int>> Combine_(int n, int k) {
        List<IList<int>> result = new List<IList<int>>();
        
		List<int> temp = new List<int>(2);
		int i = 0;
		while(i > 0){
			temp[i]++;
			if(temp[i] > n){
				i--;
			}else if(i == k - 1) {
				result.Add(new List<int>(temp));
			}else{
				i++;
				temp[i] = temp[i - 1];
			}
		}

        return result;
    }
}
