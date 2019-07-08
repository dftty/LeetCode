using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MaximumProductSubarray : MonoBehaviour
{

    public int count;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
    https://leetcode.com/problems/maximum-product-subarray/
    Discuss 解法
    本题应该想到既然是乘积，那么除非遇到0，不然应该是一直向后乘就有可能出现最大值。

    要求子数组的乘积的最大值，要求积的话，除非遇到0，不然应该是一直向后乘才会遇到最大值。
    只是本题中有负数的情况，因此每次循环记录当前乘积的最大值和最小值，每次循环遇到负数的时候，
    将最大最小值替换就ok
    
     */
    public int MaxProduct(int[] nums) {
        
        if(nums == null || nums.Length == 0) return 0;
        
        int r = nums[0];
        int res = int.MinValue;
        for(int i = 1, min = r, max = r; i < nums.Length; i++){
            if(nums[i] < 0){
                int temp = max;
                max = min;
                min = temp;
            }
            
            max = Math.Max(max * nums[i], nums[i]);
            min = Math.Min(min * nums[i], nums[i]);
            
            res = Math.Max(res, max);
        }
        
        return res;
    }

    /**
    自己的O(n^2)暴力解法
     */
    public int MaxProduct_(int[] nums){
        int res = int.MaxValue;

        for(int i = 0; i < nums.Length; i++){
            int temp = nums[i];
            for(int j = i + 1; j < nums.Length; j++){
                temp *= nums[j];

                res = Math.Max(res, temp);
            }
            res = Math.Max(res, temp);
        }

        return res;
    }
}
