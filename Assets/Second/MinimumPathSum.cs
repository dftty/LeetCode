using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MinimumPathSum : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	Minimum Path Sum
	DP问题
	
	dp[i, j] = Math.Min(dp[i - 1][j], dp[i, j - 1]) + grid[i][j]
	空间复杂度O(m * n)
	 */
	public int MinPathSum(int[][] grid) {
        int m = grid.Length;
        int n = grid[0].Length;
        
        for(int i = 1; i < grid[0].Length; i++){
            grid[0][i] += grid[0][i - 1];
        }
        
        for(int i = 1; i < grid.Length; i++){
            grid[i][0] += grid[i - 1][0];
        }
        
        for(int i = 1; i < m; i++){
            for(int j = 1; j < n; j++){
                grid[i][j] = Math.Min(grid[i - 1][j] + grid[i][j], grid[i][j - 1] + grid[i][j]);
            }
        }
        
        return grid[m - 1][n - 1];
    }

	/**
	Discuss解法， 仅需要O(m)的空间
	 */
	public int MinPathSum_Discuss(int[][] grid) {
        int m = grid.Length;
        int n = grid[0].Length;

		int[] dp = new int[m];
		dp[0] = grid[0][0];
        
        for(int i = 1; i < grid[0].Length; i++){
            dp[i] = dp[i - 1] + grid[0][i];
        }
        
        for(int j = 1; j < n; j++){
			dp[0] += grid[0][j];
			for(int i = 0; i < m; i++){
				dp[i] = Math.Min(dp[i - 1], dp[i]) + grid[i][j];
			}
		}
        
        return dp[m - 1];
    }


}
