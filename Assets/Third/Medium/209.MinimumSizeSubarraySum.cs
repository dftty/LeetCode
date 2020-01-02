using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Third
{

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
        Medium 
        Tag: 数组 双指针

        思路：使用双指针，sum为当前指针范围内的子数组和。

        */
        public int MinSubArrayLen(int s, int[] nums) {
            int sum = 0;
            int res = int.MaxValue;
            int i = 0;
            for (int j = 0; j < nums.Length; j++){
                sum += nums[j];
                
                while (sum >= s){
                    res = Math.Min(res, j - i + 1);
                    sum -= nums[i++];
                }
            }
            
            return res == int.MaxValue ? 0 : res;
        }

        /**
        O(nlogn) 解法
        思路：使用sum数组来保存nums的前缀和，然后遍历sum数组，找到s和 sum[i - 1] 的上界

        */
        public int MinSubArrayLen_(int s, int[] nums) {
            int[] sum = new int[nums.Length + 1];
            
            for (int i = 1; i <= nums.Length; i++){
                sum[i] = sum[i - 1] + nums[i - 1];
            }
            
            int res = int.MaxValue;
            for (int i = 1; i < sum.Length; i++){
                int j =  Search(sum, s + sum[i - 1], i, sum.Length - 1);
                if (j == sum.Length) break;
                res = Math.Min(res, j - i + 1);
            }
            
            return res == int.MaxValue ? 0 : res;
        }
        
        public int Search(int[] sum, int target, int lo, int hi){  
            while (lo <= hi){
                int middle = (lo + hi) / 2;
                
                if (sum[middle] < target){
                    lo = middle + 1;
                }else{
                    hi = middle - 1;
                }
            }
            
            return lo;
        }

    }

}