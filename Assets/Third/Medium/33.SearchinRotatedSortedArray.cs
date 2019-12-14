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

        
        提交错误次数：2次
            没有仔细读题，导致返回了错误的结果
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

        /**

        思路：首先使用一次二分查找找到最小值的下标，这个二分查找中使用的技巧是令hi = middle，这样可以保证
            最后lo一定指向最小值的下标。
            然后开始第二次的二分查找，计算出middle之后，需要计算出移动后middle的位置然后判断。

        */
        public int Search_Diss(int[] n, int target) {
            if (n == null || n.Length == 0) return -1;
            int lo = 0, hi = n.Length - 1;
            while (lo < hi){
                int middle = (lo + hi) / 2;
                
                if (n[middle] > n[hi]){
                    lo = middle + 1;
                }else{
                    hi = middle;
                }
            }
            
            int move = lo;
            lo = 0;
            hi = n.Length - 1;
            while (lo <= hi){
                int middle = (lo + hi) / 2;
                int rmiddle = (middle + move) % n.Length;
                if (n[rmiddle] == target){
                    return rmiddle;
                }
                
                if (n[rmiddle] > target){
                    hi = middle - 1;
                }else{
                    lo = middle + 1;
                }
            }
            
            return -1;
        }

        /**
        c++ 实现

        int search(vector<int>& nums, int target) {
            int lo = 0, hi = nums.size() - 1;
            int move = 0;
            while (lo < hi){
                int middle = (lo + hi) / 2;
                
                if (nums[middle] <= nums[hi]){
                    hi = middle;
                }else{
                    lo = middle + 1;
                }
            }
            
            move = lo;
            lo = 0;
            hi = nums.size() - 1;
            while (lo <= hi){
                int middle = (lo + hi) / 2;
                int mid = (middle + move) % nums.size();
                
                if (target == nums[mid]){
                    return mid;
                }
                
                if (target < nums[mid]){
                    hi = middle - 1;
                }else{
                    lo = middle + 1;
                }
            }
            
            return -1;
        }

        */

    }

}