using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_37 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Hard https://leetcode.com/problems/sudoku-solver/description/
	// 2018/8/18
	// Discuss solution backtrack
	public void SolveSudoku(char[,] board) {
        if(board == null) return ;
        int m = board.GetLength(0);
        int n = board.GetLength(1);
        solve(board, m, n);
    }
    
    public bool solve(char[,] board, int m, int n){
        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                if(board[i, j] == '.'){
                    for(char k = '1'; k <= '9'; k++){
                        if(isSolve(board, i, j, k)){
                            board[i, j] = k;
                        
                            if(solve(board, m, n)){
                                return true;
                            }else{
                                board[i, j] = '.';
                            }
                        }
                    }
                    return false;
                }
            }
        }
        return true;
    }
    
    public bool isSolve(char[,] board, int row, int col, char c){
        for(int i = 0; i < 9; i++){
            if(board[row, i] == c) return false;
            if(board[i, col] == c) return false;
            if(board[3 * (row / 3) + i / 3, 3 * (col / 3) + i % 3] == c) return false;
        }
        
        return true;
    }
}
