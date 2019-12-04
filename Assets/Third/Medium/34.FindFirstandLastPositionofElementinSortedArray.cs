using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Third
{
    public class FindFirstandLastPositionofElementinSortedArray : MonoBehaviour
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
        https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/
        Medium
        Tag: 数组 二分查找

        思路：有序数组中查找一个数，可以立即想到二分查找，题目中要求找到目标数字的
        最开始出现的位置和最后出现的位置。
        因此我们可以利用二分查找的特性，分别用两次二分查找，第一次找到最开始出现的位置。

        寻找最开始出现的位置时，如果middle的值和target相等，那么我们就让hi = middle
        这样最终跳出循环时，lo的位置指向的位置肯定是target的位置(如果target在数组中存在)。

        寻找最后出现的位置时，令 middle = (lo + hi + 1) / 2 这样可以保证middle的位置
        始终在向右移动。

        */
        public int[] SearchRange(int[] nums, int target) {
            int[] res = new int[2]{-1, -1};
            if (nums == null || nums.Length == 0){
                return res;
            }
            
            int lo = 0, hi = nums.Length - 1;
            while(lo < hi){
                int middle = (lo + hi) / 2;
                
                if (nums[middle] < target){
                    lo = middle + 1;
                }else {
                    hi = middle;
                }
            }
            
            if (nums[lo] != target){
                return res;
            }
            
            res[0] = lo;
            lo = 0;
            hi = nums.Length - 1;
            
            while(lo < hi){
                int middle = (lo + hi + 1) / 2; // 加一保证每次计算都在lo的右边
                
                if(nums[middle] > target){
                    hi = middle - 1;
                }else{
                    lo = middle;
                }
            }
            res[1] = hi;
            return res;
        }
    }

}