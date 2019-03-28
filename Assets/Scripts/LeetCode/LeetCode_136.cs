using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_136 : MonoBehaviour {

    void Start(){
        
    }

    // Easy https://leetcode.com/problems/single-number/description/
    // 2018/8/9
    // use xor
    public int SingleNumber(int[] nums) {
        int result = 0;
        for(int i = 0; i < nums.Length; i++){
            result = result ^ nums[i];
        }
        
        return result;
    }

    // HashTable
    public int SingleNumber_(int[] nums) {
        int result = 0;
        HashSet<int> set = new HashSet<int>();
        for(int i = 0; i < nums.Length; i++){
            if(!set.Contains(nums[i])){
                set.Add(nums[i]);
            }else{
                set.Remove(nums[i]);
            }
        }

        foreach(int i in set){
            return i;
        }
        
        return result;
    }




   

}


