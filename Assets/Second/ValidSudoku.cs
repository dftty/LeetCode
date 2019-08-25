using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidSudoku : MonoBehaviour
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
    https://leetcode.com/problems/valid-sudoku/

    首先验证行列，然后验证3x3区域
     */
    public bool IsValidSudoku(char[][] board) {
        if (board == null || board.Length == 0){
            return false;
        }
        
        HashSet<int> rowSet = new HashSet<int>();
        HashSet<int> colSet = new HashSet<int>();
        for (int i = 0; i < board.Length; i++){
            rowSet.Clear();
            colSet.Clear();
            for (int j = 0; j < board[0].Length; j++){
                if (board[i][j] != '.'){
                    if (rowSet.Contains(board[i][j])) return false;
                    rowSet.Add(board[i][j]);
                }
                
                if(board[j][i] != '.'){
                    if (colSet.Contains(board[j][i])) return false;
                    colSet.Add(board[j][i]);
                }
            }
        }
        rowSet.Clear();
        for (int i = 0; i < board.Length; i += 3){
            for (int j = 0; j < board.Length; j += 3){
                rowSet.Clear();
                
                for (int k = i; k < i + 3; k++){
                    for (int l = j; l < j + 3; l++){
                        if (board[k][l] != '.' && rowSet.Contains(board[k][l])){
                            return false;
                        }else if(board[k][l] != '.'){
                            rowSet.Add(board[k][l]);
                        }
                    }
                }
            }
        }
        
        return true;
    }

    /**
    利用除法运算和模运算来计算区块中的行列坐标
     */
    public bool IsValidSudoku_Dis(char[][] board) {
        if (board == null || board.Length == 0){
            return false;
        }
        
        HashSet<int> rowSet = new HashSet<int>();
        HashSet<int> colSet = new HashSet<int>();
        HashSet<int> cube = new HashSet<int>();

        for (int i = 0; i < board.Length; i++){
            rowSet.Clear();
            colSet.Clear();
            cube.Clear();
            for (int j = 0; j < board.Length; j++){
                if (board[i][j] != '.'){
                    if (!rowSet.Add(board[i][j])) return false;
                }

                if (board[j][i] != '.'){
                    if (!colSet.Add(board[j][i])) return false;
                }

                int rowIndex = 3 * (i / 3) + j / 3;
                int colIndex = 3 * (i % 3) + j % 3;
                if (board[rowIndex][colIndex] != '.'){
                    if (!cube.Add(board[rowIndex][colIndex])){
                        return false;
                    }
                }
            }
        }
        
        return true;
    }
}
