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

        /**
        Discuss 解法

        解题思路：
            首先，让我们来看下中位数的定义，在统计学中，中位数是按顺序排列的一组数据中
        居于中间位置的数，即在这组数据中，有一半的数据比他大，一半的数据比他小。

        对于一个有序数组A[m]
                    left_A       |      right_A
        A[1], A[2], ... A[i - 1] | A[i], A[i + 1], ... A[m]
        左边数组的长度为i，右边数组的长度为m - i，该数组共有m种分割方法

        对于有序数组B[n]
                    left_B       |       right_B
        B[1], B[2], ... B[j - 1] | B[j], B[j +1], ... B[n]
        左边的数组长度为j，右边的数组长度为n - j， 该数组共有n种分割方法。

        我们将两个分割好的数组放在一起
                    left_array   |     right_array
        A[1], A[2], ... A[i - 1] | A[i], A[i + 1], ... A[m]
        B[1], B[2], ... B[j - 1] | B[j], B[j +1], ... B[n]

        只要保证
        len(left_array) = len(right_array)
        max(left_array) <= min(right_array)
        就找到了这两个有序数组的中位数

        其中：
        i + j = m - i + n - j(或者m - i + n - j +1)
            如果n >= m 那么如果 i = 0 ~ m， j = (m + n + 1) / 2 - i;
        A[i - 1] <= B[j] and B[j - 1] <= A[i]

        首先，我们先忽略边界情况，保证A[i - 1], A[i], B[j], B[j - 1]都存在。
        那么我们有如下情况：
        imin = 0, imax = m
        i = (imin + imax) / 2
        j = (m + n + 1) / 2 - i

        if A[i - 1] <= B[j] and B[j - 1] <= A[i]:
            当前的i和j就是我们要找的答案
        else if A[i - 1] > B[j]:
            这种情况下我们需要将i向左移动
            因此 imax = i - 1
        else if B[j - 1] > A[i]:
            这种情况我们需要将i向右移动
            因此 imin = i + 1

        找到i时，中位数就是
            max(A[i - 1], B[j - 1]) 如果数量是奇数
            (max(A[i - 1], B[j - 1]) + min(A[i], B[j])) / 2 如果数量是偶数
        
        接下来我们来考虑边界情况，
        a:
            (i == 0 or j == n or A[i - 1] <= B[j]) and
            (i == m or j == 0 or B[j - 1] <= A[i])
            这时i和j就是我们要的答案
        b:
            i > 0 and j < n and A[i - 1] > B[j]
            这时我们需要设 imax = i - 1
        c:
            i < m and j > 0 and B[j - 1] > A[i]
            imin = i + 1
        
        关键点： 二分查找
        
        
        */
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