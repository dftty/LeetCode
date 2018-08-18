﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_85 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Hard https://leetcode.com/problems/maximal-rectangle/description/
	// 2018/4/26
	public int MaximalRectangle(char[,] matrix) {
        int result = -1;

		int[] height = new int[matrix.GetLength(0)];

		for(int i = 0; i < matrix.GetLength(0); i++){
			for(int j = 0; j < matrix.GetLength(1); j++){
				if(matrix[i,j] == '1'){
					height[j]++;
				}else{
					height[j] = 0;
				}
			}

			// 这里利用84题的方法，计算最大面积
			int area = LargestRectangleArea(height);
			result = Math.Max(result, area);
		}

		return result;
    }

	public int LargestRectangleArea(int[] heights) {
        Stack<int> stack = new Stack<int>();
        int max_area = 0;
        
        for(int i=0; i<=heights.Length; ++i){
            int height_bound = (i == heights.Length) ? 0 : heights[i];
            
            while(stack.Count != 0){
                int h = heights[stack.Peek()];
                
                // calculate the area for every ascending slope.
                if(h < height_bound){
                    break;
                }
                stack.Pop();
                
                // at the end, the area with the height of the minimal element.
                int index_bound = stack.Count == 0 ? -1 : stack.Peek();
                max_area = Math.Max(max_area, h*((i-1)-index_bound));
            }
            
            stack.Push(i);
        }
        
        return max_area;
    }
}
