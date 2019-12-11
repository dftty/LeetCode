using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MinimumMovestoMoveaBoxtoTheirTargetLocation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        char[][] grid = new char[4][];

        grid[0] = new char[]{'#', 'T', '#', '#', '#', '#'};
        grid[1] = new char[]{'#', '.', '.', 'B', '.', '#'};
        grid[2] = new char[]{'#', '.', '#', '#', '.', '#'};
        grid[3] = new char[]{'#', '.', '.', '.', 'S', '#'};

        MinPushBox(grid);
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


    /**
    https://leetcode.com/problems/minimum-moves-to-move-a-box-to-their-target-location/

    解法来源： Contest 163 第四名 cuiaoxiang  
    由于c# 中没有双端队列，因此采用List替代

    思路如下：如果题目中没有人，那么只需要对箱子进行BFS即可找到最小路径，但是题目中加入了人推箱子，
    因此也需要保存人的状态，创建一个flag的四维数组来保存箱子和人的状态。

    */
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
                    by = j;
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
                // 这里入队首是因为这种状态只有人移动了，箱子没有移动
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
