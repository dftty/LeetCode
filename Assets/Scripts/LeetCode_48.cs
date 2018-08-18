using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_48 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int[,] nums = new int[,]{{ 5, 1, 9,11},{ 2, 4, 8,10},{13, 3, 6, 7},{15,14,12,16}};
		//int[,] nums = new int[,]{{1, 2 ,3}, {4, 5, 6}, {7, 8, 9}};
		Rotate_Discuss(nums);
		//Rotate(nums);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/rotate-image/description/
	// 2018/2/23
	public void Rotate(int[,] matrix) {
		int n = matrix.GetLength(0);
		for(int i = 0; i < n / 2; i++){
			for(int j = 0; j < n - (2 * i + 1); j++){
				int first = matrix[i, j + i];
				int second = matrix[j + i, n - i - 1];
				int third = matrix[n - i - 1, n - j - i - 1];
				int four = matrix[n - i - j - 1, i];

				matrix[i, j + i] = four;
				matrix[j + i, n - i - 1] = first;
				matrix[n - i - 1, n - j - i - 1] = second;
				matrix[n - i - j - 1, i] = third;
			}
		}
    }

	// Discuss 解法
	// 先求这个矩阵的转置
	// 然后水平交换元素即可
	public void Rotate_Discuss(int[,] matrix) {
		for(int i = 0; i < matrix.GetLength(0) - 1; i++){
			for(int j = i + 1; j < matrix.GetLength(1); j++){
				int temp = matrix[i, j];
				matrix[i, j] = matrix[j, i];
				matrix[j, i] = temp;
			}
		}

		for(int i = 0; i < matrix.GetLength(0); i++){
			for(int j = 0; j < matrix.GetLength(1) / 2; j++){
				int temp = matrix[i, j];
				matrix[i, j] = matrix[i, matrix.GetLength(1) - j - 1];
				matrix[i, matrix.GetLength(1) - j - 1] = temp;
			}
		}

		Debug.Log("22");
    }
}
