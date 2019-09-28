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
}
