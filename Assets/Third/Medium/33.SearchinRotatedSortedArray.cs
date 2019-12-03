using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Third
{
    public class SearchinRotatedSortedArray : MonoBehaviour
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
        https://leetcode.com/problems/search-in-rotated-sorted-array/
        Medium
        Tag: 数组 二分查找

        思路：可以利用二分查找，每次找到二分数组中的递增的那个区间，
        判断target是否在这个区间内，然后根据判断条件调整指针

        关键点： 二分查找 递增区间

        

        */
        public int Search(int[] nums, int target) {
            if (nums == null || nums.Length == 0) return -1;
            int lo = 0, hi = nums.Length - 1;
            
            while(lo <= hi){
                int middle = (lo + hi) / 2;
                if (nums[middle] == target){
                    return middle;
                }
                
                if (nums[lo] <= nums[middle]){
                    // 表示递增的区间在左边， 需要判断目标数是否在这个区间内
                    if (target >= nums[lo] && target <= nums[middle]){
                        hi = middle - 1;
                    }else{
                        lo = middle + 1;
                    }
                }else{
                    if (target >= nums[middle] && target <= nums[hi]){
                        lo = middle + 1;
                    }else{
                        hi = middle - 1;
                    }
                }
            }
            return -1;
        }
    }

}