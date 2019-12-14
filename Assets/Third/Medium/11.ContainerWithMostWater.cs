using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Third
{
    public class ContainerWithMostWater : MonoBehaviour
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
        https://leetcode.com/problems/container-with-most-water/
        Medium
        Tag: 数组 双指针

        思路：求区域组成的最大面积，我们可以想到组成这个区域的长最大就是数组的长度，
        因此可以使用双指针，计算两个指针组成的区域大小，然后判断左右指针哪边的值小，
        哪边就进行偏移。

        关键点：双指针

        提交错误次数：0次
        */
        public int MaxArea(int[] height) {
            if (height == null || height.Length == 0){
                return 0;
            }
            
            int lo = 0, hi = height.Length - 1;
            int res = 0;
            while(lo < hi){
                res = Math.Max(Math.Min(height[lo], height[hi]) * (hi - lo), res);
                
                if (height[lo] < height[hi]){
                    lo++;
                }else{
                    hi--;
                }
            }
            
            return res;
        }

        /**

        c++ 代码实现

        int maxArea(vector<int>& h) {
            if (h.size() == 0) return 0;
            int res = 0, lo = 0, hi = h.size() - 1;
            
            while(lo < hi){
                res = max(res, min(h[lo], h[hi]) * (hi - lo));
                
                if (h[lo] < h[hi]){
                    lo++;
                }else{
                    hi--;
                }
            }
            return res;
        }

        */
    }

}