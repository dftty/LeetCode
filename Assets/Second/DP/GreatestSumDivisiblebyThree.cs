using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GreatestSumDivisiblebyThree : MonoBehaviour
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
    https://leetcode.com/problems/greatest-sum-divisible-by-three/

    Discuss 动态规划解法

    本题自己没有想到解法，在尝试过程中想到了可以考虑取模运算，这样dp数组的长度可以是3，
    但是并没有想到dp数组的初始值和递推公式。
    */
    public int MaxSumDivThree(int[] nums) {
        int[] dp = new int[]{0, int.MinValue, int.MinValue};
        
        foreach (int n in nums){
            int[] dp2 = new int[]{0, 0, 0};
            
            for (int i = 0; i < 3; i++){
                dp2[(n + i) % 3] = Math.Max(dp[(n + i) % 3], dp[i] + n);
            }
            
            dp = dp2;
        }
        
        return dp[0];
    }
}
