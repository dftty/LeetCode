using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Third
{

    public class MergeIntervals : MonoBehaviour
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
        https://leetcode.com/problems/merge-intervals/
        Medium
        Tag: 数组 排序

        思路：首先按照intervals中子数组的第一个元素顺序排序
        然后可以在一个while循环中遍历数组。

        提交错误次数：2次
            没有考虑到不同的情况
        */
        public int[][] Merge(int[][] intervals) {
            List<int[]> list = new List<int[]>();
            if (intervals == null || intervals.Length == 0) return list.ToArray();
            Array.Sort(intervals, (a, b) => {
                return a[0] - b[0];
            });
            int i = 0;
            while (i < intervals.Length){
                int[] temp = intervals[i];
                
                int j = i + 1;
                while (j < intervals.Length && temp[1] >= intervals[j][0]){
                    temp[1] = Math.Max(temp[1], intervals[j][1]);
                    j++;
                }
                
                list.Add(temp);
                i = j;
            }
        
            return list.ToArray();
        }
    }

}