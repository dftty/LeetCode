using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberofClosedIslands : MonoBehaviour
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
    https://leetcode.com/problems/number-of-closed-islands/

    标准的dfs算法

    做题时没有注意bool返回值，每个返回值应该与下一个返回值做&运算，
    */
    public int ClosedIsland(int[][] grid) {
        int res = 0;
        
        for (int i = 0; i < grid.Length; i++){
            for (int j = 0; j < grid[i].Length; j++){
                if (grid[i][j] == 0){
                    bool close = dfs(grid, i, j);
                    
                    if (close){
                        res++;
                    }
                }
            }
        }
        
        return res;
    }
    
    bool dfs(int[][] grid, int i, int j){
        grid[i][j] = 1;
        bool close = true;
        if (i + 1 < grid.Length && grid[i + 1][j] == 0){
            close &= dfs(grid, i + 1, j);
        }
        
        if (i - 1 >= 0 && grid[i - 1][j] == 0){
            close &= dfs(grid, i - 1, j);
        }
        
        if (j + 1 < grid[i].Length && grid[i][j + 1] == 0){
            close &= dfs(grid, i, j + 1);
        }
        
        if (j - 1 >= 0 && grid[i][j - 1] == 0){
            close &= dfs(grid, i, j - 1);
        }
        
        if (i == 0 || j == 0 || i == grid.Length - 1 || j == grid[i].Length - 1){
            close = false;
        }
        
        return close;
    }
}
