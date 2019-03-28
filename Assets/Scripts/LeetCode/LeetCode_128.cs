using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;

public class LeetCode_128 : MonoBehaviour {

    void Start(){
        
    }

    // Hard https://leetcode.com/problems/longest-consecutive-sequence/description/
    // 2018/8/28
    // discuss solution 
    public int LongestConsecutive(int[] nums) {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        
        int result = 0;
        for(int i = 0; i < nums.Length; i++){
            if(dic.ContainsKey(nums[i])) continue;
            int left = dic.ContainsKey(nums[i] - 1) ? dic[nums[i] - 1] : 0;
            int right = dic.ContainsKey(nums[i] + 1) ? dic[nums[i] + 1] : 0;

            int sum = left + right + 1;
            result = Math.Max(result, sum);

            if(dic.ContainsKey(nums[i] - left)){
                dic[nums[i] - left] = sum;
            }
            if(dic.ContainsKey(nums[i] + right)){
                dic[nums[i] + right] = sum;
            }
                    
            dic.Add(nums[i], sum);
            
        }
        return result;
    }

    // another solution
    public int LongestConsecutive_(int[] nums){
        HashSet<int> hashSet = new HashSet<int>();
        for(int i = 0; i < nums.Length; i++){
            hashSet.Add(nums[i]);
        }

        int result = 0;
        for(int i = 0; i < nums.Length; i++){
            int next = nums[i] + 1;
            int longSeq = 1;
            if(!hashSet.Contains(nums[i] - 1)){
                while(hashSet.Contains(next++)){
                    longSeq++;
                }
                result = Math.Max(result, longSeq);
            }
        }

        return result;
    }

}


