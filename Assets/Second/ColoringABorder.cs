using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoringABorder : MonoBehaviour {

	// Use this for initialization
	void Start () {
		ColorBorder(new int[][]{new int[]{1,2,1,2,1,2}, new int[]{2,2,2,2,1,2}, new int[]{1,2,2,2,1,2}}, 1, 3, 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	List<int[]> coor = new List<int[]>();
    int m = 0;
    int n = 0;


    /**
    
     */
    public int[][] ColorBorder(int[][] grid, int r0, int c0, int color) {
        int checkColor = grid[r0][c0];
        m = grid.Length; 
        n = grid[0].Length;
        DFS(grid, r0, c0, checkColor);
        
        List<int[]> list = new List<int[]>();
        for(int i = 0; i < coor.Count; i++){
            if(Check(grid, coor[i][0], coor[i][1], -1)){
                list.Add(coor[i]);
            }
        }
        
        // for(int i = 0; i < coor.Count; i++){
        //     if(!Check(grid, coor[i][0], coor[i][1], -1)){
        //         grid[coor[i][0]][coor[i][1]] = checkColor;
        //     }
        // }
        
        for(int i = 0; i < list.Count; i++){
            grid[list[i][0]][list[i][1]] = color;
        }
        
        
        
        return grid;
    }
    
    public void DFS(int[][] grid, int x, int y, int color){
        if(grid[x][y] != color) return ;
        
        coor.Add(new int[]{x, y});
        grid[x][y] = -1;
        if(x - 1 >= 0){
            DFS(grid, x - 1, y, color);
        }
        if(x + 1 < m){
            DFS(grid, x + 1, y, color);
        }
        
        if(y - 1 >= 0){
            DFS(grid, x, y - 1, color);
        }
        
        if(y + 1 < n){
            DFS(grid, x, y + 1, color);
        }
    }
    
    public bool Check(int[][] grid, int x, int y, int color){
        if(x == 0 || y == 0 || x == m - 1|| y == n - 1) return true;
        
        int count = 0;
        if(grid[x - 1][y] == color){
            count++;
        }
        
        if(grid[x + 1][y] == color){
            count++;
        }

        if(grid[x][y - 1] == color){
            count++;
        }
        
        if(grid[x][y - 1] == color){
            count++;
        }
        
        
        
        return count < 4;
    }
}
