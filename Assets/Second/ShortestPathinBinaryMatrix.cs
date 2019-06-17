using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortestPathinBinaryMatrix : MonoBehaviour
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
    https://leetcode.com/problems/shortest-path-in-binary-matrix/

    BFS，使用DFS会导致TLE
    
     */
    public int ShortestPathBinaryMatrix(int[][] grid) {
        int m = grid.Length;
        int n = grid[0].Length;
        int[][] dir = new int[][]{new int[]{1, 0}, new int[]{0, 1}, new int[]{-1, 0}, new int[]{0, -1}, new int[]{1, 1}, new int[]{1, -1}, new int[]{-1, 1}, new int[]{-1, -1}};
        if(grid[0][0] == 1 || grid[m - 1][n - 1] == 1) return -1;
        
        bool[,] isUse = new bool[m, n];
        
        Queue<int[]> queue = new Queue<int[]>();
        
        queue.Enqueue(new int[]{0, 0});
        int res = 0;
        isUse[0, 0] = true;
        
        while(queue.Count > 0){
            int size = queue.Count;
            res++;
            for(int i = 0; i < size; i++){
                int[] temp = queue.Dequeue();
                
                if(temp[0] == m - 1 && temp[1] == n - 1){
                    return res;
                }
                
                for(int j = 0; j < 8; j++){
                    int x = temp[0] + dir[j][0];
                    int y = temp[1] + dir[j][1];
                    
                    if(x >= 0 && y >= 0 && x < m && y < n && grid[x][y] == 0 && isUse[x, y] == false){
                        queue.Enqueue(new int[]{x, y});
                        isUse[x, y] = true;
                    }
                }
            }
            
        }
        return -1;
    }
}
