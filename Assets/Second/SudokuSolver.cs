using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SudokuSolver : MonoBehaviour
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
    https://leetcode.com/problems/sudoku-solver/

    Discuss解法，使用回溯
     */
    public void SolveSudoku(char[][] board) {
        if (board == null || board.Length == 0){
            return ;
        }
        
        Solve(board);
    }
    
    public bool Solve(char[][] board){
        for (int i = 0; i < 9; i++){
            for (int j = 0; j < 9; j++){
                if (board[i][j] == '.'){
                    // 注意这里要从1到9
                    for (char ch = '1'; ch <= '9'; ch++){
                        if (Check(board, i, j, ch)){
                            board[i][j] = ch;
                            if (Solve(board)){
                                return true;
                            }else{
                                board[i][j] = '.';
                            }
                        }
                    }
                    return false;
                }
            }
        }
        
        return true;
    }
    
    /// <summary>
    /// 这里检查是否已有这个数字
    /// </summary>
    /// <param name="board"></param>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <param name="c"></param>
    /// <returns></returns>
    public bool Check(char[][] board, int row, int col, char c){
        for (int i = 0; i < 9; i++){
            if (board[row][i] != '.' && board[row][i] == c) return false;
            if (board[i][col] != '.' && board[i][col] == c) return false;
            
            int rowIndex = 3 * (row / 3) + (i / 3);
            int colIndex = 3 * (col / 3) + (i % 3);
            if (board[rowIndex][colIndex] != '.' && board[rowIndex][colIndex] == c) return false;
        }
        
        return true;
    }
}
