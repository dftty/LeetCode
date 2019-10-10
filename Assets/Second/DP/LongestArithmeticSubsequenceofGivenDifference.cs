using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LongestArithmeticSubsequenceofGivenDifference : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
    https://leetcode.com/problems/longest-arithmetic-subsequence-of-given-difference/

    非常典型的HashMap类型动态规划题目
    
     */
    public int LongestSubsequence(int[] arr, int difference) {
        Dictionary<int, int> dp = new Dictionary<int, int>();
        
        for (int i = 0; i < arr.Length; i++){
            int diff = arr[i] - difference;
            if (dp.ContainsKey(diff)){
                int temp = dp[diff];
                if (dp.ContainsKey(arr[i])){
                    dp[arr[i]] = Math.Max(temp + 1, dp[arr[i]]);
                }else{
                    dp.Add(arr[i], temp + 1);
                }
            }else if (!dp.ContainsKey(arr[i])){
                dp.Add(arr[i], 1);
            }
        }
        
        int max = 0;
        foreach(KeyValuePair<int, int> pair in dp){
            max = Math.Max(max, pair.Value);
        }
        
        return max;
    }
}
