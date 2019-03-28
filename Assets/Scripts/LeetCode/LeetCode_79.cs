using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class LeetCode_79 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		char[,] board = new char[,]{{'a', 'a'}};
		Debug.Log(Exist(board, "aaa"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/word-search/discuss/27658/Accepted-very-short-Java-solution.-No-additional-space.
	// 2018/3/12
	// Discuss解决方法
	public bool Exist(char[,] board, string word) {
		char[] words = word.ToCharArray();
		
		for(int  i = 0; i < board.GetLength(0); i++){
			for(int j = 0; j < board.GetLength(1); j++){
				int[,] temp = new int[board.GetLength(0), board.GetLength(1)];
				if(BackTrack(board, words, i, j, 0, temp)) return true;
			}
		}
		return false;
    }

	public bool BackTrack(char[,] board, char[] words, int x, int y, int i, int[,] temp){
		if(i == words.Length) return true;
		if(x < 0 || y < 0 || x == board.GetLength(0) || y == board.GetLength(1)) return false;
		if(temp[x, y] == 1 ) return false;
		if(words[i] != board[x, y]) return false;

		temp[x, y] = 1;

		bool exist = BackTrack(board, words, x, y + 1, i + 1, temp)
					|| BackTrack(board, words, x, y - 1, i + 1, temp)
					|| BackTrack(board, words, x + 1, y, i + 1, temp)
					|| BackTrack(board, words, x - 1, y, i + 1, temp);

		temp[x, y] = 0;
		return exist;

	}
}
