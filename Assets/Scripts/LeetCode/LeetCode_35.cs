using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_35 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Easy  https://leetcode.com/problems/search-insert-position/description/
	// 2018/2/11
	// 时间复杂度O(n)
	public int SearchInsert(int[] nums, int target) {
        int i = 0;
        if(nums.Length == 0){
            return i;
        }
        
        for(; i < nums.Length; i++){
            if(target <= nums[i]){
                return i;
            }
        }
        return i;
    }

	// Discuss solution binary search Time O(logn)
	public int SearchInsert_Disscuss(int[] nums, int target){
		int low = 0, high = nums.Length - 1;
		while(low < high){
			int mid = (low + high) >> 1;
			if(nums[mid] == target){
				return mid;
			}else if(nums[mid] > target){
				high = mid - 1;
			}else{
				low = mid + 1;
			}
		}

		return low;
	}
}
