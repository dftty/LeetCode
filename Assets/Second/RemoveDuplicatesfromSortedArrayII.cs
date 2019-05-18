using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveDuplicatesfromSortedArrayII : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	用一个计数器记录当前重复的数字即可
	 */
	public int RemoveDuplicates(int[] nums) {
        if(nums == null || nums.Length == 0) return 0;
        int rIndex = 1;
        int count = 1;
        
        for(int i = 1; i < nums.Length; i++){
            if(nums[i] == nums[i - 1] && count < 2){
                count++;
                nums[rIndex++] = nums[i];
            }else if(nums[i] != nums[i - 1]){
                count = 1;
                nums[rIndex++] = nums[i];
            }
        }
        
        return rIndex;
    }

	/**
	Discuss solution
	 */
	public int RemoveDuplicates_Discuss(int[] nums){
		int index = 0;
		foreach(int n in nums){
			if(index < 2 || n > nums[index - 1]){
				nums[index++] = n;
			}
		}

		return index;
	}
}
