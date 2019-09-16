using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MaximumSubarraySumwithOneDeletion : MonoBehaviour
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
    https://leetcode.com/problems/maximum-subarray-sum-with-one-deletion/

    动态规划
    
     */
    public int MaximumSum(int[] arr) {
        int max = arr[0];
        int[] maxEndHere = new int[arr.Length];
        int[] maxStartHere = new int[arr.Length];
        
        maxEndHere[0] = arr[0];
        for (int i = 1; i < arr.Length; i++){
            maxEndHere[i] = Math.Max(arr[i], maxEndHere[i - 1] + arr[i]);
            max = Math.Max(max, maxEndHere[i]);
        }
        
        maxStartHere[arr.Length - 1] = arr[arr.Length - 1];
        
        for (int i = arr.Length - 2; i >= 0; i--){
            maxStartHere[i] = Math.Max(arr[i], maxStartHere[i + 1] + arr[i]);
        }
        
        for (int i = 0; i < arr.Length - 2; i++){
            max = Math.Max(max, maxEndHere[i] + maxStartHere[i + 2]);
        }
        return max;
    }

    /**
    O(1) 空间解法
    首先遍历数组，如果其中都是负数，则返回最大的那个负数。
    然后，利用两个数字记录子数组的和，如果当前记录的数字小于0，则可以将这两个数字置为0
    从下一个位置开始重新计数，因为数组中有大于0的数，所以小于0的子数组和就可以忽略

    技巧：数组每个元素进行累加
     */
    public int MaximumSum_(int[] arr) {
        int a = 0, b = 0;
        int ans = int.MinValue;
        bool hasPos = false;
        foreach(int i in arr){
            if (i >= 0){
                hasPos = true;
            }else{
                ans = Math.Max(ans, i);
            }
        }
        
        if (!hasPos){
            return ans;
        }
        
        foreach(int i in arr)
        {
            if (i > 0){
                b += i;
                a += i;
            }else{
                b = Math.Max(b + i, a);
                a += i;
            }
            
            ans = Math.Max(ans, Math.Max(a, b));
            a = Math.Max(a, 0);
            b = Math.Max(b, 0);
        }
        
        return ans;
    }
}
