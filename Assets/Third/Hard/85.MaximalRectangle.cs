using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Third
{

    public class MaximalRectangle : MonoBehaviour
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
        https://leetcode.com/problems/maximal-rectangle/
        Hard
        Tag: 数组 动态规划

        思路：想法根据84.LargestRectangleinHistogram题目得来，可以使用一个height数组保存当前遍历
        到的matrix的高度。如果遍历到的matrix[i][j] == 0 则将height[i] 重置为0

        */
        public int MaximalRectangle_Di(char[][] matrix) {
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0) return 0;
            int m = matrix.Length, n = matrix[0].Length;
            int[] height = new int[n + 1];
            
            int res = 0;
            
            for (int i = 0; i < m; i++){
                Stack<int> s = new Stack<int>();
                for (int j = 0; j <= n; j++){
                    if (j < n){
                        if (matrix[i][j] == '1'){
                            height[j] += 1;
                        }else{
                            height[j] = 0;
                        }
                    }
                    
                    if (s.Count == 0 || height[s.Peek()] <= height[j]){
                        s.Push(j);
                    }else{
                        while (s.Count > 0 && height[s.Peek()] > height[j]){
                            int index = s.Pop();
                            res = Math.Max(res, height[index] * (s.Count == 0 ? j : (j - s.Peek() - 1)));
                        }
                        s.Push(j);
                    }
                }
            }
            
            return res;
        }
    }

}