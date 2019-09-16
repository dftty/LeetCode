using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MinimumSizeSubarraySum : MonoBehaviour
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
    https://leetcode.com/problems/minimum-size-subarray-sum/

    Two pointer 解法 O(n)时间，O(1)空间
    两个指针，一个start，一个i，sum表示从start到i的数组值得和
    遍历数组，sum = sum + nums[i];
    然后判断sum是否大于等于s，如果相等，则给len赋值，

    然后while循环中如果sum大于等于s并且start指针小于等于i指针，则sum减去start指针的值，
    start指针加一
    
     */
    public int MinSubArrayLen(int s, int[] nums) {
        if(nums == null) return 0;
        int len = int.MaxValue;
        int start = 0;
        int sum = 0;
        for(int i = 0; i < nums.Length; i++){
            sum = sum + nums[i];
            
            while(sum >= s && start <= i){
                len = Math.Min(len, i - start + 1);
                sum = sum - nums[start++];
            }
        }
        
        return len == int.MaxValue ? 0 : len;
    }


    /**
    第二种解法，首先计算出这个数组的前缀和，前缀和数组前面额外添加一位值为0,因为数组中的数字都是正数，
    那么前缀和数组就是一个有序数组，可以使用二分查找
    然后遍历前缀数组，寻找小于等于presSum[i] - s 的下标
     */
    public int MinSubArrayLen_(int s, int[] nums) {
        if(nums == null) return 0;
        int len = int.MaxValue;
        
        int[] preSum = new int[nums.Length + 1];
        for(int i = 1; i <= nums.Length; i++){
            preSum[i] = nums[i - 1] + preSum[i - 1];
        }
        
        for(int i = nums.Length; i >= 0 && preSum[i] - s >= 0; i--){
            int j = Search(preSum, preSum[i] - s);
            Console.WriteLine(j);
            if(j == preSum.Length) break;
            len = Math.Min(len, i - j);
        }
        
        return len == int.MaxValue ? 0 : len;
    }
    
    public int Search(int[] preSum, int s){
        int lo = 0;
        int hi = preSum.Length - 1;
        
        while(lo <= hi){
            int mid = (lo + hi) / 2;
            
            if(preSum[mid] == s){
                return mid;
            }else if(preSum[mid] > s){
                hi = mid - 1;
            }else{
                lo = mid + 1;
            }
        }
        
        return lo - 1;
    }
}
