using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_27 : MonoBehaviour {

    void Start(){
        
    }

    // Easy https://leetcode.com/problems/remove-element/description/
    // 2018/8/7
    // two pointer
    public int RemoveElement(int[] nums, int val) {
        int lo = 0;

        // 注意hi为length减一
        int hi = nums.Length - 1;
        int result = nums.Length;
        
        while(lo <= hi){
            while(lo < hi && nums[lo] != val) lo++;
            while(hi >= lo && nums[hi] == val) {
                hi--;
                result--;
            }
            if(lo >= 0 && hi < nums.Length && lo < hi){
                nums[lo] = nums[hi];
                result -= 1;
            }
            lo++;
            hi--;
            
            
        }
        
        return result;
    }

    public int removeElement(int[] A, int elem) {
        int m = 0;    
        for(int i = 0; i < A.Length; i++){
            if(A[i] != elem){
                A[m] = A[i];
                m++;
            }
        }
        return m;
    }

}


