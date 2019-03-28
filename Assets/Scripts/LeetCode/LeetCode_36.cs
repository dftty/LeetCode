using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_36 : MonoBehaviour {

    void Start(){
        
    }

    // Medius https://leetcode.com/problems/valid-sudoku/description/
    // 2018/8/9
    // use hashset 只需要判断有数字的地方是否没有问题
    public bool IsValidSudoku(char[,] board) {
        HashSet<char> hashSet = new HashSet<char>();
        
        int m = board.GetLength(0);
        int n = board.GetLength(1);
        
        for(int i = 0; i < n; i++){
            hashSet.Clear();
            for(int j = 0; j < m; j++){
                if(board[i, j] == '.') continue;
                if(hashSet.Contains(board[i, j])) return false;
                hashSet.Add(board[i, j]);
            }
            hashSet.Clear();
            for(int j = 0; j < n; j++){
                if(board[j, i] == '.') continue;
                if(hashSet.Contains(board[j, i])) return false;
                hashSet.Add(board[j, i]);
            }
        }
        
        for(int i = 0; i < m; i += 3){
            for(int j = 0 ; j < n; j += 3){
                hashSet.Clear();
                 for(int k = 0; k < 3; k++){
                     for(int l = 0; l < 3; l++){
                         if(board[i + k, j + l] == '.')continue;
                         if(hashSet.Contains(board[i + k, j + l])) return false;
                         hashSet.Add(board[i + k, j + l]);
                     }
                 }
            }
        }
        
        return true;
    }

}


