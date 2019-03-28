using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_200 : MonoBehaviour {

    // Medium https://leetcode.com/problems/number-of-islands/description/
    // 2018/8/2
    // loop grid, if grid[i, j] == '1' then dfs let grid to 0;
    public int NumIslands(char[,] grid) {
        if(grid == null) return 0;
        int result = 0;
        int m = grid.GetLength(0);
        int n = grid.GetLength(1);
        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                if(grid[i, j] == '0') continue;
                Flood(grid, i, j, m, n);
                result++;
            }
        }
        return result;
    }
    
    public void Flood(char[,] grid, int i, int j, int m, int n){
        if(i < 0 || i >= m || j < 0 || j >= n || grid[i, j] == '0'){
            return ;
        }
        
        grid[i, j] = '0';
        Flood(grid, i - 1, j, m, n);
        Flood(grid, i + 1, j, m, n);
        Flood(grid, i, j - 1, m, n);
        Flood(grid, i, j + 1, m, n);
    }

}


