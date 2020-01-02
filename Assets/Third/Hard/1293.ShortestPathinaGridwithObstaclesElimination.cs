using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Third
{

    public class ShortestPathinaGridwithObstaclesElimination : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            int[][] arr = new int[2][]{new int[2]{0, 1}, new int[2]{1, 0}};
        }

        // Update is called once per frame
        void Update()
        {
            
        }


        /**
        https://leetcode.com/problems/shortest-path-in-a-grid-with-obstacles-elimination/
        Hard
        Tag: 广度优先搜索

        思路：使用一个三维数组来保存所有的状态，使用广度优先搜索来进行判断

        */

        int[][] d = new int[4][]{new int[]{-1, 0}, new int[]{1, 0}, new int[]{0, -1}, new int[]{0, 1}};
        public int ShortestPath(int[][] grid, int k) {
            int m = grid.Length, n = grid[0].Length;
            bool[,,] check = new bool[m, n, k + 1];
            
            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(new int[]{0, 0, 0});
            
            int res = 0;
            while (queue.Count > 0){
                int count = queue.Count;
                for (int i = 0; i < count; i++){
                    int[] arr = queue.Dequeue();
                    
                    if (arr[0] == m - 1 && arr[1] == n - 1) return res;
                    
                    for (int j = 0; j < 4; j++){
                        int nx = arr[0] + d[j][0];
                        int ny = arr[1] + d[j][1];
                        
                        if (nx < 0 || nx >= m || ny < 0 || ny >= n) continue;
                        int nz = arr[2] + grid[nx][ny];
                        if (nz > k || check[nx, ny, nz]) continue;
                        check[nx, ny, nz] = true;
                        queue.Enqueue(new int[]{nx, ny, nz});
                    }
                }
                
                res++;
            }
            
            return -1;
        }

        /** 
        
        该解法使用int数组来保存结果，但是对于达成条件时，最小值可能在第三维数组中的某一个中，因此无法判断。

        public int[][] d = {new int[]{1, 0}, new int[]{0, 1}, new int[]{-1, 0}, new int[]{0, -1}};
        public const int N = 41;
        
        public int ShortestPath(int[][] grid, int k) {
            int m = grid.Length, n = grid[0].Length;
            int[,,] flag = new int[m, n, k + 1];
            for (int i = 0; i < m; i++){
                for (int j = 0; j < n; j++){
                    for (int l = 0; l <= k; l++){
                        flag[i, j, l] = int.MinValue;
                    }
                }
            }
            
            List<Node> list = new List<Node>();
            list.Add(new Node(0, 0, 0));
            flag[0, 0, 0] = 0;
            
            
            while (list.Count > 0){
                Node node = list[0];
                if (node.x == m - 1 && node.y == n - 1 && node.z == k) return flag[node.x, node.y, node.z];
                list.RemoveAt(0);
                
                for (int i = 0; i < 4; i++){
                    int nx = node.x + d[i][0];
                    int ny = node.y + d[i][1];
                    
                    if (nx < 0 || nx >= m || ny < 0 || ny >= n) continue;
                    int nz = node.z + grid[nx][ny];
                    if (nz > k) continue;
                    if (flag[nx, ny, nz] >= 0) continue;
                    
                    flag[nx, ny, nz] = flag[node.x, node.y, node.z] + 1;
                    list.Add(new Node(nx, ny, nz));
                }
            }
            
            return -1;
        }
        struct Node{
            public int x, y, z;
            
            public Node(int x, int y, int z){
                this.x = x;
                this.y = y;
                this.z = z;
            }
        }
        
        */
       
    }

}