using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Third
{

    public class FindMinimuminRotatedSortedArray : MonoBehaviour
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
        https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/
        Medium
        Tag: 数组 二分查找

        思路：数组中没有重复元素，因此二分查找没有特殊情况(每次移动一个单位的下标)的移动

        */
        public int FindMin(int[] nums) {
            if (nums == null || nums.Length == 0) return 0;
            int lo = 0, hi = nums.Length - 1;
            
            while (lo < hi){
                int middle = (lo + hi) / 2;
                
                if (nums[middle] < nums[hi]){
                    hi = middle;
                }else{
                    lo = middle + 1;
                }
            }
            
            return nums[lo];
        }
    }

}