using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_64 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/minimum-path-sum/description/
	// 2018/3/8
	public int MinPathSum(int[,] grid) {
        int m = grid.GetLength(0);
        int n = grid.GetLength(1);
        int[,] result = new int[m, n];
        
        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                int up = int.MaxValue,left = int.MaxValue;
                if(i - 1 >= 0){
                    up = result[i - 1, j];
                }
                
                if(j - 1 >= 0){
                    left = result[i, j - 1];
                }
                
                int count = Math.Min(up, left);
                if(count == int.MaxValue) count = 0;
                
                result[i, j] += grid[i, j] + count;
            }
        }
        
        return result[m - 1, n - 1];
    }
}
