using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_63 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	// Medium https://leetcode.com/problems/unique-paths-ii/description/
	// 2018/3/6
	// 同62题
	public int UniquePathsWithObstacles(int[,] obstacleGrid) {
        int m = obstacleGrid.GetLength(0);
        int n = obstacleGrid.GetLength(1);
        int[,] temp = new int[m, n];
        
        int result = GetCount(m - 1, n - 1, temp, obstacleGrid);
        
        return result;
    }
    
    int GetCount(int m, int n, int[,] temp, int[,] obstacleGrid){
        if(m < 0 || n < 0 || obstacleGrid[m, n] == 1) return 0;
        else if(m == 0 && n == 0) return 1;
        
        if(temp[m, n] == 0){
            temp[m, n] = GetCount(m - 1, n, temp, obstacleGrid) + GetCount(m, n - 1, temp, obstacleGrid);
        }
        
        return temp[m, n];
    }
}
