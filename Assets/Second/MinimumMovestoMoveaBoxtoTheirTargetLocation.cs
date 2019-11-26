using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MinimumMovestoMoveaBoxtoTheirTargetLocation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // char[][] grid = new char[][];
    }

    public int[][] d = {new int[]{1, 0}, new int[]{0, 1}, new int[]{-1, 0}, new int[]{0, -1}};
    public const int N = 20;
    int[,,,] flag = new int[N, N, N, N];

    struct Node
    {
        public int px, py, bx, by;

        public Node(int px, int py, int bx, int by)
        {
            this.px = px;
            this.py = py;
            this.bx = bx;
            this.by = by;
        }
    }


    public int MinPushBox(char[][] grid) {
        int n = grid.Length, m = grid[0].Length;
        int px = 0, py = 0, bx = 0, by = 0, tx = 0, ty = 0;

        for (int i = 0; i < n; i++){
            for (int j = 0; j < m; j++){
                if (grid[i][j] == 'S'){
                    px = i;
                    py = j;
                    grid[i][j] = '.';
                } else if (grid[i][j] == 'T'){
                    tx = i;
                    ty = j;
                    grid[i][j] = '.';
                } else if (grid[i][j] == 'B'){
                    bx = i;
                    by = i;
                    grid[i][j] = '.';
                }
            }
        }

        for (int i = 0; i < N; i++){
            for (int j = 0; j < N; j++){
                for (int k = 0; k < N; k++){
                    for (int l = 0; l < N; l++){
                        flag[i, j, k ,l] = int.MinValue;
                    }
                }
            }
        }

        List<Node> list = new List<Node>();
        list.Add(new Node(px, py, bx, by));
        flag[px, py, bx, by] = 0;
        while(list.Count > 0){
            Node node = list[0];
            if (node.bx == tx && node.by == ty) return flag[node.px, node.py, node.bx, node.by];
            list.RemoveAt(0);

            for (int i = 0; i < 4; i++){
                int nx = node.px + d[i][0];
                int ny = node.py + d[i][1];

                if (nx < 0 || nx >= n || ny < 0 || ny >= m || grid[nx][ny] != '.') continue;
                if (nx == node.bx && ny == node.by) continue;
                if (flag[nx, ny, node.bx, node.by] >= 0) continue;
                flag[nx, ny, node.bx, node.by] = flag[node.px, node.py, node.bx, node.by];
                list.Insert(0, new Node(nx, ny, node.bx, node.by));
            }

            if (Math.Abs(node.px - node.bx) + Math.Abs(node.py - node.by) == 1){
                int k;
                for (k = 0; k < 4; k++){
                    int nx = node.px + d[k][0];
                    int ny = node.py + d[k][1];
                    if (nx == node.bx && ny == node.by) break;
                }

                int nbx = node.bx + d[k][0];
                int nby = node.by + d[k][1];
                if (!(nbx < 0 || nbx >= n || nby < 0 || nby >= m || grid[nbx][nby] != '.') && flag[node.bx, node.by, nbx, nby] < 0){
                    flag[node.bx, node.by, nbx, nby] = flag[node.px, node.py, node.bx, node.by] + 1;
                    list.Add(new Node(node.bx, node.by, nbx, nby));
                }
            }
        }

        return -1;
    }
}
