using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_54 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int[,] nums = new int[,]{{1, 2, 3}, {4, 5, 6}, {7, 8, 9}, {10, 11, 12}, {13, 14, 15}};
		SpiralOrder(nums);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/spiral-matrix/description/
	// 2018/2/24
	// 外层循环为Min(m, n),如果为奇数，则除二加一，否则除二
	// 每个内层循环进行四次添加，分别为向右，向下，向左，向上。
	public IList<int> SpiralOrder(int[,] matrix) {
        IList<int> result = new List<int>();

		int min = Math.Min(matrix.GetLength(0), matrix.GetLength(1));

		int round = min % 2 == 0 ? min / 2 : min / 2 + 1;

		for(int i = 0; i < round; i++){
			for(int k = i; k < matrix.GetLength(1) - i; k++){
				result.Add(matrix[i, k]);
			}

			for(int l = i + 1; l < matrix.GetLength(0) - i; l++){
				result.Add(matrix[l, matrix.GetLength(1) - i - 1]);
			}
			if(min % 2 != 0 && matrix.GetLength(0) % 2 != 0 && i == round - 1){
				continue;
			}
			for(int m = matrix.GetLength(1) - i - 2; m >= i; m--){
				result.Add(matrix[matrix.GetLength(0) - i - 1, m]);
			}
			if(min % 2 != 0 && matrix.GetLength(1) % 2 != 0 && i == round - 1){
				continue;
			}
			for(int n = matrix.GetLength(0) - i - 2; n >= i + 1; n--){
				result.Add(matrix[n, i]);
			}
		}

		return result;
    }

	// Discuss solution 
	// 同样的解法，代码更简洁
	public IList<int> SpiralOrder_Discuss(int[,] matrix) {
        IList<int> result = new List<int>();

		int m = matrix.GetLength(0);
		int n = matrix.GetLength(1);

		int up = 0, right = n - 1, down = m - 1, left = 0;
		while(true){
			for(int col = left; col <= right ; col++) result.Add(matrix[up, col]);
			if(++up > down) break;

			for(int row = up; row <= down; row++) result.Add(matrix[row, right]);
			if(--right < left) break;

			for(int col = right; col > left; col--) result.Add(matrix[down, col]);
			if(--down < up) break;
			
			for(int row = down; row < up; row++) result.Add(matrix[row, left]);
			if(++left > right) break;
		}
		

		return result;
    }
}
