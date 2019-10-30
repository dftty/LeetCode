using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurroundedRegions : MonoBehaviour
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
    https://leetcode.com/problems/surrounded-regions/

    深度优先搜索解法，首先我们深度优先搜索，将所有'O'都改为X，然后在每个区域的遍历中判断该区域是否有O存在，如果有，
    则保存在一个HashSet中，最后我们将其反转回'O'
     */
    public void Solve(char[][] board) {
        if (board == null || board.Length == 0) return ;
        HashSet<KeyValuePair<int, int>> flipBackPair = new HashSet<KeyValuePair<int, int>>();
        
        for (int i = 0; i < board.Length; i++){
            for (int j = 0; j < board[i].Length; j++){
                if (board[i][j] == 'O'){
                    HashSet<KeyValuePair<int, int>> temp = new HashSet<KeyValuePair<int, int>>(); 
                    bool isEdge = dfs(temp, i, j, board);
                    if (isEdge){
                        flipBackPair.UnionWith(temp);
                    }
                }
            }
        }
        
        foreach(KeyValuePair<int, int> pair in flipBackPair){
            board[pair.Key][pair.Value] = 'O';
        }
        
    }
    
    bool dfs(HashSet<KeyValuePair<int, int>> temp, int i, int j, char[][] board){
        bool isEdge = false;
        board[i][j] = 'X';
        temp.Add(new KeyValuePair<int, int>(i, j));
        if (i - 1 >= 0 && board[i - 1][j] == 'O'){
            isEdge |= dfs(temp, i - 1, j, board);
        }
        
        if (i + 1 < board.Length && board[i + 1][j] == 'O'){
            isEdge |= dfs(temp, i + 1, j, board);
        }
        
        if (j - 1 >= 0 && board[i][j - 1] == 'O'){
            isEdge |= dfs(temp, i, j - 1, board);
        }
        
        if (j + 1 < board[i].Length && board[i][j + 1] == 'O'){
            isEdge |= dfs(temp, i, j + 1, board);
        }
        
        if (i == 0 || j == 0 || i == board.Length - 1 || j == board[i].Length - 1){
            return isEdge |= true;
        }else{
            return isEdge |= false;
        }
    }


    /**
    并查集解法，对于二维数组，需要保存 m * n个记录
     */
    int[] union;
    bool[] hasEdges;
    public void Solve_(char[][] board) {
        if (board == null || board.Length == 0) return ;
        int height = board.Length, width = board[0].Length;
        union = new int[height * width];
        hasEdges = new bool[union.Length];
        
        for (int i = 0; i < union.Length; i++){
            union[i] = i;
        }
        
        for (int i = 0; i < hasEdges.Length; i++){
            int x = i / width, y = i % width;
            hasEdges[i] = board[x][y] == 'O' && (x == 0 || y == 0 || x == height - 1 || y == width - 1);
        }
        
        for (int i = 0; i < union.Length; i++){
            int x = i / width, y = i % width;
            int up = x - 1, right = y + 1;
            if (up >= 0 && board[x][y] == board[up][y]) Union(x * width + y, up * width + y);
            if (right < width && board[x][y] == board[x][right]) Union(x * width + y, x * width + right);
        }
        
        for (int i = 0; i < height; i++){
            for (int j = 0; j < width; j++){
                if (board[i][j] == 'O' && !hasEdges[find(i * width + j)]){
                    board[i][j] = 'X';
                }
            }
        }
        
    }
    
    void Union(int x, int y){
        int index_x = find(x);
        int index_y = find(y);
        
        bool hasEdge = hasEdges[index_x] || hasEdges[index_y];
        union[index_x] = union[index_y];
        hasEdges[index_y] = hasEdge;
    }
    
    int find(int x){
        if (union[x] != x){
            union[x] = find(union[x]);
        }
        
        return union[x];
    }
}
