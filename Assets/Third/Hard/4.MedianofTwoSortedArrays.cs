using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Third
{

    public class MedianofTwoSortedArrays : MonoBehaviour
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
        https://leetcode.com/problems/median-of-two-sorted-arrays/
        Hard
        Tag: 数组  二分查找  分治法

        思路：可以遍历两个数组，将其中的值按照顺序添加到一个list中
        然后返回list的中位数

        O(m + n) 时间复杂度 O(m + n)空间复杂度

        */
        public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
            List<int> list = new List<int>();
            
            int i = 0, j = 0;
            while(i < nums1.Length || j < nums2.Length){
                if (i < nums1.Length && j < nums2.Length){
                    if (nums1[i] < nums2[j]){
                        list.Add(nums1[i++]);
                    }else {
                        list.Add(nums2[j++]);
                    }
                }else if (i < nums1.Length){
                    list.Add(nums1[i++]);
                }else {
                    list.Add(nums2[j++]);
                }
            }
            
            if (list.Count % 2 == 0){
                int middle = list.Count / 2 - 1;
                return (double)(list[middle] + list[middle + 1]) / 2;
            }else{
                return list[list.Count / 2];
            }
        }


        public double FindMedianSortedArrays_Discuss(int[] nums1, int[] nums2) {
            int m = nums1.Length; 
            int n = nums2.Length; 
            
            if (n < m){
                int[] tempArr = nums2;
                nums2 = nums1;
                nums1 = tempArr;
                
                int temp = n;
                n = m;
                m = temp;
            }
            
            int imin = 0;
            int imax = m;
            int half = (m + n + 1) / 2;
            
            while(imin <= imax){
                int i = (imin + imax) / 2;
                int j = half - i;
                
                if (i < m && nums2[j - 1] > nums1[i]){
                    imin = i + 1;
                }else if (i > 0 && nums2[j] < nums1[i - 1]){
                    imax = i - 1;
                }else{
                    int max_left = int.MinValue;
                    
                    if (i == 0){
                        max_left = nums2[j - 1];
                    }else if (j == 0){
                        max_left = nums1[i - 1];
                    }else {
                        max_left = Math.Max(nums1[i - 1], nums2[j - 1]);
                    }
                    
                    if ((m + n) % 2 != 0){
                        return max_left;
                    }
                    
                    int max_right = int.MinValue;
                    if (i == m){
                        max_right = nums2[j];
                    }else if (j == n){
                        max_right = nums1[i];
                    }else {
                        max_right = Math.Min(nums1[i], nums2[j]);
                    }
                    return (double)(max_left + max_right) / (double)2;
                }
            }
            
            return 0;
        }
    }

}