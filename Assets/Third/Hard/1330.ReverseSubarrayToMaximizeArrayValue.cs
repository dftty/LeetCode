using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Third
{

    public class ReverseSubarrayToMaximizeArrayValue : MonoBehaviour
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
        https://leetcode.com/problems/reverse-subarray-to-maximize-array-value/
        Hard
        Tag: 数组

        Discuss解法思路：https://leetcode.com/problems/reverse-subarray-to-maximize-array-value/discuss/489882/O(n)-Solution-with-explanation

        */
        public int MaxValueAfterReverse(int[] nums) {
            int res = 0;
            
            int iMax = int.MinValue, iMin = int.MaxValue;
            for (int i = 1; i < nums.Length; i++){
                res += Math.Abs(nums[i] - nums[i - 1]);
                
                iMax = Math.Max(Math.Min(nums[i], nums[i - 1]), iMax);
                iMin = Math.Min(Math.Max(nums[i], nums[i - 1]), iMin);
            }
            
            int change = Math.Max(0, (iMax - iMin) * 2);
            
            for (int i = 1; i < nums.Length; i++){
                int temp1 = -Math.Abs(nums[i] - nums[i - 1]) + Math.Abs(nums[0] - nums[i]);
                int temp2 = -Math.Abs(nums[i] - nums[i - 1]) + Math.Abs(nums[nums.Length - 1] - nums[i - 1]);
                
                change = Math.Max(change, Math.Max(temp1, temp2));
            }
            
            return res + change;
        }
    }

}