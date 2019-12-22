using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Third
{

    public class MaximumProductSubarray : MonoBehaviour
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
        https://leetcode.com/problems/maximum-product-subarray/
        Medium
        Tag: 数组 动态规划

        思路：使用dp数组保存了两个状态，一个是当前计算出的最大值，一个是当前计算出的最小值
        这样给我们一个提示，dp中可以保存上一步的多种状态，用于下一步的计算。

        */
        public int MaxProduct(int[] nums) {
            Tuple[] dp = new Tuple[nums.Length];
            
            dp[0] = new Tuple(nums[0], nums[0]);
            int res = nums[0];
            
            for (int i = 1; i < nums.Length; i++){
                Tuple t = dp[i - 1];
                int imax = Math.Max(Math.Max(nums[i], t.imax * nums[i]), t.imin * nums[i]);
                int imin = Math.Min(Math.Min(nums[i], t.imin * nums[i]), t.imax * nums[i]);
                
                dp[i] = new Tuple(imax, imin);
                res = Math.Max(res, Math.Max(dp[i].imin, dp[i].imax));
            }
            return res;
        }
        
        public class Tuple{
            public int imax = 0;
            public int imin = 0;
            
            public Tuple(int imax, int imin){
                this.imax = imax;
                this.imin = imin;
            }
        }

        /**
        c++实现

        计算前缀积和后缀积即可
        思路：如果数组中没有0， 那么一定是前缀或后缀中的子数组积，如果出现了0，
        那么久可以将积重置为当前遍历的数字。

        int maxProduct(vector<int>& nums) {
            int res = nums[0], left = 0, right = 0;
            
            for (int i = 0; i < nums.size(); i++){
                left = (left ? left : 1) * nums[i];
                right = (right ? right : 1) * nums[nums.size() - i - 1];
                
                res = max(res, max(left, right));
            }
            
            return res;
        }

        */
    }

}