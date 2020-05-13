using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Third
{

    public class LongestContinuousSubarrayWithAbsoluteDiffLessThanorEqualtoLimit : MonoBehaviour
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
        https://leetcode.com/problems/longest-continuous-subarray-with-absolute-diff-less-than-or-equal-to-limit/
        Tag: 滑动窗口

        思路：首先我们想要在最少的时间内找到子数组的最大值和最小值，因此可以考虑使用SortedSet来保存。
        SortedSet可以保证获取最大和最小值的时间复杂度为O(logn);
        有一个小问题SortedSet不允许保存相同的值，因此我们自定义比较方法，作为参数传到构造器中。

        使用滑动窗口双指针来记录当前子数组区间，遍历数组，然后如果set中的最大值和最小值大于limit，
        就一直移除左指针的数字，知道差小于limit；
        */
        public int LongestSubarray(int[] nums, int limit) {
            SortedSet<int> sortSet = new SortedSet<int>(Comparer<int>.Create((a, b) => {
                return nums[a] == nums[b] ? a - b : nums[a] - nums[b];
            }));
            sortSet.Add(0);
            int left = 0;
            int res = 1;
            for (int right = 1; right < nums.Length; right++){
                sortSet.Add(right);
                while (nums[sortSet.Max] - nums[sortSet.Min] > limit){
                    sortSet.Remove(left++);
                }

                res = Math.Max(res, right - left + 1);
            }
            return res;
        }


        /**
        双端队列解法：
        使用两个双端队列，一个保存最大值，一个保存最小值。
        */
        public int LongestSubarray_(int[] nums, int limit) {
            int res = 0;
            LinkedList<int> max = new LinkedList<int>();
            LinkedList<int> min = new LinkedList<int>();
            int i = 0;
            for (int j = 0; j < nums.Length; j++){
                while (max.Count > 0 && max.Last.Value < nums[j]) max.RemoveLast();
                while (min.Count > 0 && min.Last.Value > nums[j]) min.RemoveLast();
                
                max.AddLast(nums[j]);
                min.AddLast(nums[j]);
                while (max.First.Value - min.First.Value > limit){
                    if (max.First.Value == nums[i]) max.RemoveFirst();
                    if (min.First.Value == nums[i]) min.RemoveFirst();
                    
                    i++;
                }
                res = Math.Max(res, j - i + 1);
            }
            return  res;
        }
    }

}