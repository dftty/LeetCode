using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberofEnclaves : MonoBehaviour {

	// Use this for initialization
	void Start () {
		List<int> list = new List<int>();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	
	Number of Enclaves
	Given a 2D array A, each cell is 0 (representing sea) or 1 (representing land)

	A move consists of walking from one land square 4-directionally to another land square, or off the boundary of the grid.

	Return the number of land squares in the grid for which we cannot walk off the boundary of the grid in any number of moves.

	类似于FloodFill的深度优先搜索问题，可以直接用递归解决
	循环数组，如果位于边界并且值为1，则调用查找方法。
	 */
	public int NumEnclaves(int[][] A) {
        int result = 0;
        int m = A.Length;
        int n = A[0].Length;
        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                if(i == 0 || j == 0 || i == m - 1 || j == n - 1){
                    if(A[i][j] != 1){
                        continue;
                    }
                    Check(A, i, j, m , n);
                }
            }
        }
        
        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                if(A[i][j] == 1){
                    result++;
                }
            }
        }
        
        return result;
        
    }
    
	/**
	查找方法，当进入该方法时就设置数组值为0
	*/
    public void Check(int[][] A, int i, int j, int m, int n){
        A[i][j] = 0;
        if(i - 1 >= 0 && A[i - 1][j] != 1){
            Check(A, i - 1, j, m, n);
        }
        
        if(i + 1 < m && A[i + 1][j] != 1){
            Check(A, i + 1, j, m, n);
        }
        
        if(j - 1 >= 0 && A[i][j - 1] != 1){
            Check(A, i, j - 1, m, n);
        }
        
        if(j + 1 < n && A[i][j + 1] != 1){
            Check(A, i, j + 1, m, n);
        }
    }
}
