using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Third
{

    public class ThreeSumClosest : MonoBehaviour
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
        https://leetcode.com/problems/3sum/
        Medium
        Tag: 数组 双指针

        思路：和ThreeSum类似，不过需要考虑target为负数的情况，
        因此比较时需要使用绝对值。
        
        提交错误次数：0次
        */
        public int ThreeSumClosest_(int[] nums, int target) {
            Array.Sort(nums);
            int res = nums[0] + nums[1] + nums[2];
            for (int i = 0; i < nums.Length; i++){
                int lo = i + 1, hi = nums.Length - 1;
                while(lo < hi){
                    int sum = nums[i] + nums[lo] + nums[hi];
                    if (Math.Abs(res - target) > Math.Abs(sum - target)){
                        res = sum;
                    }
                    
                    if (sum > target){
                        hi--;
                    }else{
                        lo++;
                    }
                }
            }
            
            return res;
        }

        /**
        c++ 实现

        int threeSumClosest(vector<int>& nums, int target) {
            int res = nums[0] + nums[1] + nums[2];
            sort(nums.begin(), nums.end());
            for (int i = 0; i < nums.size(); i++){
                int lo = i + 1, hi = nums.size() - 1;
                while (lo < hi){
                    int sum = nums[i] + nums[lo] + nums[hi];
                    if (abs(target - res) > abs(target - sum)){
                        res = sum;
                    }else if (sum > target){
                        hi--;
                    }else{
                        lo++;
                    }
                }
            }
            return res;
        }

        */
    }

}