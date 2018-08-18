using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int[] nums = new int[]{2, 7, 11, 5};

		nums = TwoSum_Discuss(nums, 9);
		for(int i = 0; i < nums.Length; i++){
			Debug.Log(nums[i]);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Easy   https://leetcode.com/problems/two-sum/description/
	// 2018/2/11
	// Two Sum  时间复杂度 O(n^2) 
	public int[] TwoSum(int[] nums, int target) {
		int i, j, result;
		i = j = result = 0;
		bool isEnd = false;
		while(i < nums.Length && !isEnd){
			j = i + 1;
			for(; j < nums.Length; j++){
				result = nums[i] + nums[j];
				if(result == target){
					isEnd = true;
					break;
				}
			}
			if(!isEnd){
				i++;
			}
		}

		int[] sum = new int[2];
		sum[0] = i;
		sum[1] = j;
		return sum;
    }

	//Discuss 解决方案  use map can store key and value 
	public int[] TwoSum_Discuss(int[] nums, int target){
		int[] result = new int[2];
		Dictionary<int, int> map = new Dictionary<int, int>();
		for(int i = 0; i < nums.Length; i++){
			if(map.ContainsKey(target - nums[i])){
				result[1] = i;
				result[0] = map[target - nums[i]];
				return result;
			}
			map.Add(nums[i], i);
		}

		return result;
	}
}
