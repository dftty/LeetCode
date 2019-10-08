using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PathwithMaximumGold : MonoBehaviour
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
    https://leetcode.com/problems/path-with-maximum-gold/

    深度优先搜索题目
     */
    int max = 0;
    public int GetMaximumGold(int[][] grid) {
        for (int i = 0; i < grid.Length; i++){
            for (int j = 0; j < grid[i].Length; j++){
                if (grid[i][j] != 0){
                    dfs(i, j, grid, 0);
                }
            }
        }
        
        return max;
    }
    
    void dfs(int i, int j, int[][] grid, int m){
        int temp = grid[i][j];
        m += grid[i][j];
        grid[i][j] = 0;
        max = Math.Max(max, m);
        if (i - 1 >= 0 && grid[i - 1][j] != 0){
            dfs(i - 1, j, grid, m);
        }
        
        if (j - 1 >= 0 && grid[i][j - 1] != 0){
            dfs(i, j - 1, grid, m);
        }
        
        if (i + 1 < grid.Length && grid[i + 1][j] != 0){
            dfs(i + 1, j, grid, m);
        }
        
        if (j + 1 < grid[i].Length && grid[i][j + 1] != 0){
            dfs(i, j + 1, grid, m);
        }
        
        grid[i][j] = temp;
    }
}
