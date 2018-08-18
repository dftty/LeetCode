using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_189 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int[] nums = new int[]{1,2,3,4,5,6};
        Rotate_Cycle(nums, 4);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Easy  https://leetcode.com/problems/rotate-array/description/
	// 2018/2/14
	// O(n) time O(n) space
	public void Rotate(int[] nums, int k) {
        if(nums.Length == 0){
            return ;
        }
        
        if(k >= nums.Length){
            k = k % nums.Length;
        }
        
        int[] copy = new int[nums.Length];
        Array.Copy(nums, copy, nums.Length);
        k = nums.Length - k;
        for(int i = 0; i < nums.Length; i++){
            if(k >= nums.Length){
                k = 0;
            }
            nums[i] = copy[k++];
        }
    }

    // Discuss solution 
    public void Rotate_Cycle(int[] nums, int k) {
        if(nums.Length == 0){
            return ;
        }
        
        k = k % nums.Length;
        
        int count = 0;
        for(int start = 0; count < nums.Length; start++){
            int current = start;
            int prev = nums[start];
            do{
                int next = (current + k) % nums.Length;
                int temp = nums[next];
                nums[next] = prev;
                prev = temp;
                current = next;
                count++;
            }while(start != current);
        }

        for(int i = 0; i < nums.Length; i++){
            Debug.Log(nums[i]);
        }
        
    }


    // Discuss solution O(n) time O(1) space
    // juse reverse array three times
	public void Rotate_DiscussReverse(int[] nums, int k) {
        k = k % nums.Length;

        reverse(nums, 0, nums.Length - k - 1);
        reverse(nums, nums.Length - k, nums.Length - 1);
        reverse(nums, 0, nums.Length - 1);

        for(int i = 0; i < nums.Length; i++){
            Debug.Log(nums[i]);
        }
    }

    private void reverse(int[] nums, int i, int j){
        int temp = 0;
        while(i < j){
            temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
            i++;
            j--;
        }
    }

}
