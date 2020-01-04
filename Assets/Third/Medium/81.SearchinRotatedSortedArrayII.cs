using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Third
{

    public class SearchinRotatedSortedArrayII : MonoBehaviour
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
        https://leetcode.com/problems/search-in-rotated-sorted-array-ii/
        Medium
        Tag: 数组 二分查找

        思路：由于数组中有重复数字，因此需要过滤掉lo和hi指针中和middle指针相同的值
        例如数组[2, 1, 2, 2, 2, 2] 中寻找 1

        */
        public bool Search(int[] nums, int target) {
            if (nums == null || nums.Length == 0) return false;
            int lo = 0, hi = nums.Length - 1;   
            
            while (lo <= hi){
                int middle = (lo + hi) / 2;
                
                if (nums[middle] == target){
                    return true;
                }
                
                while (middle < hi && nums[hi] == nums[middle]) hi--;
                while (lo < middle && nums[lo] == nums[middle]) lo++;
                
                if (nums[middle] >= nums[lo]){
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
            
            return false;
        }

        /**
        c++ 实现
        bool search(vector<int>& nums, int target) {
            int lo = 0, hi = nums.size() - 1;
            
            while (lo <= hi){
                int middle = (lo + hi) / 2;
                
                if (nums[middle] == target){
                    return true;
                }    
                
                if (nums[middle] < nums[hi]){
                    if (target > nums[middle] && target <= nums[hi]){
                        lo = middle + 1;
                    }else{
                        hi = middle - 1;
                    }
                    
                }else if (nums[middle] > nums[hi]){
                    if (target >= nums[lo] && target < nums[middle]){
                        hi = middle - 1;
                    }else{
                        lo = middle + 1;
                    }
                }else{
                    hi--;
                }
            }
            
            return false;
        }

        */
    }

}