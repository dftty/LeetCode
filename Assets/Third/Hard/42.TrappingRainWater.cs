using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Third
{

    public class TrappingRainWater : MonoBehaviour
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
        https://leetcode.com/problems/trapping-rain-water/
        Hard
        Tag : 数组 双指针 栈

        思路：根据11题的解题方法，可以考虑本题使用双指针方法。
        中间可以放入的雨水块和左右障碍物有关，因此我们用lmax来保存当前左边障碍物的最小高度，rmax来
        保存当前右边障碍物的最小高度。
        
        然后用双指针lo和hi进行遍历，每次计算当前高度中较小的那个,其中i为lo或者hi
        res += Math.Max(Math.Min(lmax, rmax) - h[i], 0);

        */
        public int Trap(int[] h) {
            if (h == null || h.Length <= 2) return 0;
            int m = h.Length;
            int lmax = h[0], rmax = h[m - 1];
            int lo = 0, hi = m - 1;
            int res = 0;
            while (lo < hi){
                if (h[lo] < h[hi]){
                    res += Math.Max(Math.Min(lmax, rmax) - h[lo], 0);
                    lo++;
                    lmax = Math.Max(lmax, h[lo]);
                }else{
                    res += Math.Max(Math.Min(lmax, rmax) - h[hi], 0);
                    hi--;
                    rmax = Math.Max(rmax, h[hi]);
                }
            }
            
            return res;
        }


        /**
        Discuss 栈解法

        思路：

        */
        public int Trap_Diss(int[] h) {
            if (h == null || h.Length <= 2) return 0;
            int m = h.Length;
            int res = 0;
            Stack<int> s = new Stack<int>();
            int i = 0;
            while (i < m){
                if (s.Count == 0 || h[s.Peek()] >= h[i]){
                    s.Push(i++);
                }else{
                    int pre = s.Pop();
                    if (s.Count > 0){
                        int minHeight = Math.Min(h[i], h[s.Peek()]);
                        res += (minHeight - h[pre]) * (i - s.Peek() - 1);
                    }
                }
            }
            
            return res;
        }
    }

}