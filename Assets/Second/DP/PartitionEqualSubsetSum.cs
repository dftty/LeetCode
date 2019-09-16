using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartitionEqualSubsetSum : MonoBehaviour
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
    https://leetcode.com/problems/partition-equal-subset-sum/

    思考重点:子数组

    问题： 将一个数组分成两个子数组，能否使两个子数组的和相等
    动态规划解法,dp[i] 为true代表一个子数组的和等于i
     */
    public bool CanPartition(int[] nums) {
        bool[] dp = new bool[20001];
        dp[0] = true;
        int sum = 0;
        
        for (int i = 0; i < nums.Length; i++){
            sum += nums[i];
            for (int j = sum; j >= nums[i]; j--){
                dp[j] |= dp[j - nums[i]];
            }
        }
        
        // 如果和不是偶数，则不可能
        if (sum % 2 != 0){
            return false;
        }
        
        return dp[sum / 2];
    }
}
