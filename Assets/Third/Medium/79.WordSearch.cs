using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Third
{

    public class WordSearch : MonoBehaviour
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
        https://leetcode.com/problems/word-search/
        Medium
        Tag: 数组 回溯 深度优先搜索

        思路：深度优先搜索， 会导致TLE错误

        提交错误次数：1次
            错误原因：混淆 | 和|| 运算符，忘记||的短路性质。
        */
        public bool Exist(char[][] board, string word) {
            if (board == null || board.Length == 0 || string.IsNullOrEmpty(word)) return false;
            for (int i = 0; i < board.Length; i++){
                for (int j = 0; j < board[i].Length; j++){
                    if (word[0] == board[i][j]){
                        bool has = Dfs(board, word, i, j, 0);
                        
                        if (has){
                            return true;
                        }
                    }
                }
            }
            
            return false;
        }
        
        bool Dfs(char[][] board, string word, int i, int j, int strIndex){
            bool has = false;
                    
            if (strIndex == word.Length){
                return true;
            }
            
            if (i < 0 || i >= board.Length || j < 0 || j >= board[i].Length){
                return false;
            }
            
            if (board[i][j] != word[strIndex]){
                return has;
            }
            
            char c = board[i][j];
            board[i][j] = '.';
            
            // 这段代码会导致TLE错误，原因是使用了 | 运算符
            // 错误原因分析： | 并非短路运算符，因此假如有一个Dfs调用返回true之后，
            // 还会继续调用后面的方法，导致TLE错误。
            // has |= Dfs(board, word, i + 1, j, strIndex + 1);
            // has |= Dfs(board, word, i - 1, j, strIndex + 1);
            // has |= Dfs(board, word, i, j + 1, strIndex + 1);
            // has |= Dfs(board, word, i, j - 1, strIndex + 1);

            has = Dfs(board, word, i + 1, j, strIndex + 1)|| 
                Dfs(board, word, i - 1, j, strIndex + 1)||
                Dfs(board, word, i, j + 1, strIndex + 1)||
                Dfs(board, word, i, j - 1, strIndex + 1);
            
            board[i][j] = c;
            
            return has;
        }
    }

}