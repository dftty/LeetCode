using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;

public class Test : MonoBehaviour {

        void Start()
        {
            int[][] arr = new int[2][]{new int[2]{0, 1}, new int[2]{1, 0}};
            int k = 1;
            ShortestPath(arr, k);
        }

        // Update is called once per frame
        void Update()
        {
            
        }


        /**
        
        */

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
                if (node.x == m - 1 && node.y == n - 1) return flag[node.x, node.y, node.z];
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
            int res = int.MinValue;
            for (int i = 0; i <= k; i++){
                res = Math.Min(res, flag[m - 1, n - 1, i]);
                Console.WriteLine(flag[m - 1, n - 1, i]);
            }
            
            return res;
        }
        
        struct Node{
            public int x, y, z;
            
            public Node(int x, int y, int z){
                this.x = x;
                this.y = y;
                this.z = z;
            }
        }
        

        public int PalindromePartition(string s, int k) {
            int m = s.Length;
            int[,] cost = new int[m, m];
            
            for (int i = 0; i < s.Length; i++){
                for (int j = 1; j < s.Length; j++){
                    cost[i, j] = go(s, i, j);
                }
            }
            
            int[,] dp = new int[m + 1, k + 1];

            for (int i = 0; i <= m; i++){
                for (int j = 0; j <= k; j++){
                    dp[i, j] = 1 << 29;
                }
            }
            dp[0, 0] = 0;
            for (int i = 1; i <= m; i++){
                for (int j = 1; j <= k; j++){
                    for (int x = 0; x < i; x++){
                        dp[i, j] = Math.Min(dp[i, j], dp[x, j - 1] + cost[x, i - 1]);
                    }
                }
            }
            
            return dp[m, k];
        }
        
        int go(string s, int x, int y){
            int res = 0;
            while (x < y){
                if (s[x] != s[y]) res++;
                x++;
                y--;
            }
            
            return res;
        }

}
