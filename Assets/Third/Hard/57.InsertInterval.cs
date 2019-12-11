using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Third
{

    public class InsertInterval : MonoBehaviour
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
        https://leetcode.com/problems/insert-interval/
        Medium
        Tag: 数组 排序

        思路：考虑好各种边界情况并进行处理即可

        */
        public int[][] Insert(int[][] intervals, int[] newInterval) {
            List<int[]> list = new List<int[]>();
            if (intervals == null || intervals.Length == 0){
                list.Add(newInterval);
                return list.ToArray();
            }
            
            if (intervals[0][0] > newInterval[1]){
                list.Add(newInterval);
            }
            
            for (int i = 0; i < intervals.Length; i++){
                int[] temp = intervals[i];
                
                if (i + 1 < intervals.Length && newInterval[0] > temp[1] && newInterval[1] < intervals[i + 1][0]){
                    list.Add(temp);
                    list.Add(newInterval);
                }else if (newInterval[0] > temp[1] || newInterval[1] < temp[0]){
                    list.Add(temp);
                }else{
                    temp[0] = Math.Min(temp[0], newInterval[0]);
                    int j = i + 1;
                    while (j < intervals.Length && intervals[j][0] <= newInterval[1]){
                        temp[1] = Math.Max(temp[1], intervals[j][1]);
                        j++;
                    }

                    i = j - 1;
                    temp[1] = Math.Max(temp[1], newInterval[1]);
                    list.Add(temp);
                }
                
            }
            
            if (newInterval[0] > intervals[intervals.Length - 1][1]){
                list.Add(newInterval);
            }
            
            return list.ToArray();
        }

        /**

        思路：使用三个while循环来处理，第一个while循环处理在newInterval左边的
        第二个while处理newInterval覆盖的区域，第三个处理newInterval右边的
        */
        public int[][] Insert_Dis(int[][] intervals, int[] newInterval) {
            List<int[]> list = new List<int[]>();
            if (intervals == null || intervals.Length == 0){
                list.Add(newInterval);
                return list.ToArray();
            }
            
            int i = 0;
            while (i < intervals.Length && intervals[i][1] < newInterval[0]){
                list.Add(intervals[i++]);
            }
            
            while (i < intervals.Length && intervals[i][0] <= newInterval[1]){
                newInterval[0] = Math.Min(intervals[i][0], newInterval[0]);
                newInterval[1] = Math.Max(intervals[i][1], newInterval[1]);
                i++;
            }
            
            list.Add(newInterval);
            
            while (i < intervals.Length){
                list.Add(intervals[i++]);
            }
            
            return list.ToArray();
        }

    }

}