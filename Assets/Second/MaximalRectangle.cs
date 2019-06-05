using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MaximalRectangle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	Discuss动态规划解法
	 */
	public int MaximalRectangle_(char[][] matrix) {
        if(matrix == null || matrix.Length == 0) return 0;
        int m = matrix.Length;
        int n = matrix[0].Length;
        
        int[] left = new int[n];
        int[] right = new int[n];
        int[] height = new int[n];
        for(int i = 0; i < n; i++){
            right[i] = n;
        }
        
        int max_area = 0;
        for(int i = 0; i < m; i++){
            int cur_left = 0,cur_right = n;
            for(int j = 0; j < n ;j++){
                if(matrix[i][j] == '1'){
                    height[j]++;
                }else{
                    height[j] = 0;
                }
            }
            
            for(int j = 0; j < n; j ++){
                if(matrix[i][j] == '1'){
                    left[j] = Math.Max(left[j], cur_left);
                }else{
                    left[j] = 0;
                    cur_left = j + 1;
                }
            }
            
            for(int j = n - 1; j >= 0; j--){
                if(matrix[i][j] == '1'){
                    right[j] = Math.Min(right[j], cur_right);
                }else{
                    right[j] = n;
                    cur_right = j;
                }
            }
            
            for(int j = 0; j < n ;j++){
                max_area = Math.Max(max_area, (right[j] - left[j]) * height[j]);
            }
        }
        
        return max_area;
    }

	/**
	基于 LargestRectangleinHistogram 题的stack解法，时间复杂度O(mn)
	 */
	public int MaximalRectangle_D(char[][] matrix) {
        if(matrix == null || matrix.Length == 0) return 0;

		int m = matrix.Length, n = matrix[0].Length;
		int[] height = new int[n + 1];
		int maxArea = 0;

		for(int i = 0; i < m; i++){
			Stack<int> stack = new Stack<int>();

			for(int j = 0; j < n + 1; j++){
                if(j < n){
                    if(matrix[i][j] == '1'){
                        height[j]++;
                    }else{
                        height[j] = 0;
                    }
                }
				if(stack.Count == 0 || height[j] > height[stack.Peek()]){
					stack.Push(j);
				}else{
					while(stack.Count > 0 && height[j] <= height[stack.Peek()]){
						int tp = stack.Pop();
						maxArea = Math.Max(maxArea, height[tp] * (stack.Count == 0 ? j : j - stack.Peek() - 1));
					}
					stack.Push(j);
				}
			}
		}
		return maxArea;
    }
}
