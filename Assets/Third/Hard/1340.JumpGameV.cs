using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Thrid
{

public class JumpGameV : MonoBehaviour
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
    https://leetcode.com/problems/jump-game-v/
    Hard
    Tag: 动态规划

    Discuss Top-down DP

    */
    public int MaxJumps(int[] arr, int d) {
        int n = arr.Length;
        int[] dp = new int[n];
        
        int res = 0;
        for (int i = 0; i < arr.Length; i++){
            res = Math.Max(res, dfs(arr, dp, i, d, n));
        }
        
        return res;
    }
    
    int dfs(int[] arr, int[] dp, int i, int d, int n){
        if (dp[i] != 0) return dp[i];
        int res = 1;
        for (int j = i + 1; j <= Math.Min(i + d, n - 1) && arr[j] < arr[i]; j++){
            res = Math.Max(res, 1 + dfs(arr, dp, j, d, n));
        }
        
        for (int j = i - 1; j >= Math.Max(i - d, 0) && arr[j] < arr[i]; j--){
            res = Math.Max(res, 1 + dfs(arr, dp, j, d, n));
        }
        
        dp[i] = res;
        return dp[i];
    }
}

}