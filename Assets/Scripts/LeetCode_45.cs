using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_45 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log(Jump(new int[]{2, 2,3,1}));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Hard https://leetcode.com/problems/jump-game-ii/description/
	// 2018/4/10
	// use BFS
	public int Jump(int[] nums) {
        int result = 0;

		for(int i = 0; i < nums.Length; i++){
			int step = nums[i];
			if(i == nums.Length - 1) break;
			int min = int.MinValue;
			int index = 0;
			if(step + i == nums.Length - 1) {
				result++;
				break;
			}
			for(int j = i + 1; j < step + i + 1; j++){
				if(j >= nums.Length){
					index = j;
					break;
				}
				if(j + nums[j] > min){
					min = j + nums[j];
					index = j;
				}
			}
			i = index - 1;
			result++;
		}

		return result;
    }
}

