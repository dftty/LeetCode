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
            int k = 1;
        }

        // Update is called once per frame
        void Update()
        {
            
        }


        /**
        
        */

        /** 
        
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