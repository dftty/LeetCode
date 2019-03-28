using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_169 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//in this array, 3 isn't more than n / 2, so this won't work
		//int[] nums = new int[]{ 1,1,3,3,3,9,1,9,9,3};

		int[] nums = new int[]{3, 2, 3, 1, 1, 1, 1};
		Debug.Log(MajorityElement_DC(nums));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Easy https://leetcode.com/problems/majority-element/description/
	// 2018/2/14  
	// O(n) solution but use hashtable
	public int MajorityElement(int[] nums) {
        Dictionary<int, int> count = new Dictionary<int, int>();
        
        for(int i = 0; i < nums.Length; i++){
            if(count.ContainsKey(nums[i])){
                count[nums[i]]++;
            }else{
                count.Add(nums[i], 1);
            }
        }
        
        int result = 0;
        int j = 0;
        foreach(KeyValuePair<int, int> temp in count){
            if(temp.Value > j){
                result = temp.Key;
                j = temp.Value;
            }
        }
        return result;
    }

	// Discuss solution 
	// O(n) time, O(1) space
	public int MajorityElement_Disscuss(int[] nums){
		int major = 0;
		for(int count = 1, i = 1; i < nums.Length; i++){
			count = nums[major] == nums[i] ? ++count : --count;
			if(count == 0){
				major = i;
				count = 1;
			}
		}

		return nums[major]; 
	}

	// Divide & Conquer solution
	public int MajorityElement_DC(int[] nums){
		return MajorityElement_DCRec(nums, 0, nums.Length - 1);
	}
	public int MajorityElement_DCRec(int[] nums, int lo, int hi){
		if(lo == hi){
			return nums[lo];
		}

		int mid = (hi - lo) / 2 + lo;
		int left = MajorityElement_DCRec(nums, lo, mid);
		int right = MajorityElement_DCRec(nums, mid + 1, hi);

		if(left == right){
			return left;
		}

		int leftCount = CountInRange(nums, left, lo, hi);
		int rightCount = CountInRange(nums, right, lo, hi);

		return leftCount > rightCount ? left : right;
	}
	private int CountInRange(int[] nums,int num, int lo, int hi){
		int count = 0;
		for(int i = lo; i < hi; i++){
			if(nums[i] == num){
				count++;
			}
		}

		return count;
	}

	

}
