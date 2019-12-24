using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Third
{

    public class LargestRectangleinHistogram : MonoBehaviour
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
        https://leetcode.com/problems/largest-rectangle-in-histogram/
        Hard
        Tag: 数组  栈

        Discuss解法
        思路：对于每一个bar x，我们需要计算以x为最小高度组成的长方形的面积，那么我们计算出所有x组成的区域的面积
        找到最大值，任务就完成了。
        那么如何计算以x为最小高度的矩形面积？需要知道左边第一个比x低的bar和右边第一个比x低的bar
        从左到右遍历数组，使用栈来保存每个bar 的下标，当遍历到一个比当前栈顶高度小的bar时，就是出栈的时刻。
        然后计算出栈的bar所组成区域的面积，那么当前遍历的下标就是它的右边界，栈顶的下标就是它的左边界，如果栈为空
        那么左边界为-1

        */
        public int LargestRectangleArea(int[] heights) {
            if (heights == null) return 0;
            Stack<int> stack = new Stack<int>();
            int i = 0, res = 0;
            while (i < heights.Length){
                if (stack.Count == 0 || heights[stack.Peek()] <= heights[i]){
                    stack.Push(i++);
                    continue;
                }
                
                while (stack.Count > 0 && heights[stack.Peek()] > heights[i]){
                    int index = stack.Pop();
                    int leftIndex = stack.Count > 0 ? stack.Peek() : -1;
                    res = Math.Max(res, (i - leftIndex - 1) * heights[index]);
                }
            }
            
            while (stack.Count > 0){
                int index = stack.Pop();
                int leftIndex = stack.Count > 0 ? stack.Peek() : -1;
                res = Math.Max(res, (i - leftIndex - 1) * heights[index]);
            }
            
            return res;
        }

        /**

        思路：上述方法的for循环版
        */
        public int LargestRectangleArea_(int[] heights) {
            if (heights == null) return 0;
            Stack<int> stack = new Stack<int>();
            int res = 0;
            
            for (int i = 0; i <= heights.Length; i++){
                int h = i == heights.Length ? 0 : heights[i];
                
                if (stack.Count == 0 || heights[stack.Peek()] <= h){
                    stack.Push(i);
                }else{
                    int index = stack.Pop();
                    res = Math.Max(res, heights[index] * (stack.Count == 0 ? i : i - stack.Peek() - 1));
                    i--;
                }
            }
            
            return res;
        }


        /**
        c++ 实现
        int largestRectangleArea(vector<int>& heights) {
            if (heights.size() == 0) return 0;
            stack<int> s;
            
            int res = 0;
            for (int i = 0; i <= heights.size(); i++){
                int h = i == heights.size() ? 0 : heights[i];
                if (s.size() == 0 || heights[s.top()] <= h){
                    s.push(i);
                }else{
                    while (s.size() > 0 && heights[s.top()] > h){
                        int index = s.top();
                        s.pop();
                        res = max(res, heights[index] * (s.size() == 0 ? i : i - s.top() - 1));
                    }
                    
                    s.push(i);
                }
            }
            
            return res;
        }

        */


        /**
        O(nlogn)时间
        思路：本题可以使用分治法来实现，每次Divid中，找到最小的那个高度的下标min，
        那么最大的矩形面积就是min左边最大的矩形面积，或者min右边最大的矩形面积，
        或者是由heights[min]组成的矩形的最大高度面积

        */
        public int LargestRectangleArea_Div(int[] heights) {
            if (heights == null) return 0;
            int res = Divid(heights, 0, heights.Length - 1);
            return res;
        }
        
        int Divid(int[] heights, int left, int right){
            if (left > right){
                return 0;
            }
            
            if (left == right){
                return heights[left];
            }
            
            int min = left;
            for (int i = left + 1; i <= right; i++){
                if (heights[min] > heights[i]){
                    min = i;
                }
            }
            int leftMax = Divid(heights, left, min - 1);
            int rightMax = Divid(heights, min + 1, right);
            
            int middleMax = (right - left + 1) * heights[min];
            
            return Math.Max(leftMax, Math.Max(rightMax, middleMax));
        }

        /**

        思路：动态规划解法

        */
        public int LargestRectangleArea_Dp(int[] heights) {
            if (heights == null || heights.Length == 0) return 0;
            int res = 0;
            
            int[] left = new int[heights.Length], right = new int[heights.Length];
            left[0] = -1;
            right[heights.Length - 1] = heights.Length;
            
            for (int i = 1; i < heights.Length; i++){
                int p = i - 1;
                while (p >= 0 && heights[p] >= heights[i]){
                    p = left[p];
                }
                
                left[i] = p;
            }
            
            for (int i = heights.Length - 2; i >= 0; i--){
                int p = i + 1;
                while (p < heights.Length && heights[p] >= heights[i]){
                    p = right[p];
                }
                
                right[i] = p;
            }
            
            for (int i = 0; i < heights.Length; i++){
                res = Math.Max(res, (right[i] - left[i] - 1) * heights[i]);
            }
            
            return res;
        }
    }

}