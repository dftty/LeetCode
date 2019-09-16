using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KConcatenationMaximumSum : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(KConcatenationMaxSum(new int[]{-7,-1,5,2,3,-7,-6,1}, 6));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
    https://leetcode.com/problems/k-concatenation-maximum-sum/

    注意：在解题中，出现了int值相乘溢出的情况，导致最后模运算出错，这种情况下应该先将int值转为long，计算完成之后
    再强转成int值。

    解法：答案可能有以下几种情况：
    第一数组中元素全部大于等于0，那么答案就是k * sum（arr) 例如 [1, 2] 2
    第二数组中有负数，最大子数组的和在单个的数组中   例如 ： [-7,-1,5,2,3,-7,-6,1]   6 
    第二数组中有负数，答案为数组前缀和中的最大值加上后缀和中的最大值加上 (k - 2) * sum(arr)(如果sum(arr) 大于0)例如[-5,-2,0,0,3,9,-2,-5,4]    5
     */
    public int KConcatenationMaxSum(int[] arr, int k) {
        
        int mod = (int)Math.Pow(10, 9) + 7;
        int max = int.MinValue;
        Console.WriteLine(mod);
        int[] preSum = new int[arr.Length + 1];
        int preSumMax = 0;
        for (int i = 1; i <= arr.Length; i++){
            preSum[i] += (arr[i - 1] + preSum[i - 1]) % mod;
            max = Math.Max(max, arr[i - 1]);
            preSumMax = Math.Max(preSumMax, preSum[i]);
        }
        
        int[] arrRev = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++){
            arrRev[i] = arr[arr.Length - i - 1];
        }
        
        int[] suffixSum = new int[arr.Length + 1];
        int suffixSumMax = 0;
        for (int i = 1; i <= arrRev.Length; i++){
            suffixSum[i] += arrRev[i - 1] + suffixSum[i - 1];
            suffixSumMax = Math.Max(suffixSumMax, suffixSum[i]);
        }
        
        int sum = 0;
        for (int i = 0; i < k; i++){
            sum += (preSum[arr.Length]);
        }
        max = Math.Max(max, sum);
        max = Math.Max(max, preSumMax + suffixSumMax);
        max = Math.Max(max, MaxSubArray(arr));
        
        if (k >= 3){
            max = Math.Max(max, preSumMax + suffixSumMax + (int)(((long)(k - 2) * (long)preSum[arr.Length]) % mod));
        }
        return max >= 0 ? max % mod : 0;
    }

    public int MaxSubArray(int[] nums) {
        int[] dp = new int[nums.Length];
        
        dp[0] = nums[0];
        int max = dp[0];
        for(int i = 1; i < nums.Length; i++){
            dp[i] = nums[i] + (dp[i - 1] > 0 ? dp[i - 1] : 0);
            max = Math.Max(max, dp[i]);
        }
        
        return max;
    }
}
