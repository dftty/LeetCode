using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FlipColumnsForMaximumNumberofEqualRows : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	https://leetcode.com/problems/flip-columns-for-maximum-number-of-equal-rows/
	时间复杂度O(n^3)
	 */
	public int MaxEqualRowsAfterFlips(int[][] matrix) {
        int res = 0;
        int len = matrix.Length;
        int[] flip = new int[matrix[0].Length];
        
        for(int i = 0; i < len; i++){
            for(int j = 0; j < flip.Length; j++){
                flip[j] = 1 - matrix[i][j];
            }
            int temp = 0;
            
            for(int k = 0; k < len; k++){
                if(Equal(matrix[i], matrix[k]) || Equal(matrix[k], flip)){
                    temp++;
                } 
            }
            res = Math.Max(res, temp);
        }
        
        return res;
    }
    
    public bool Equal(int[] first, int[] second){
        for(int i = 0; i < first.Length; i++){
            if(first[i] != second[i]) return false;
        }
        
        return true;
    }

	/**
	利用字典来记录已经遍历的数组
	 */
	public int MaxEqualRowsAfterFlips_(int[][] matrix)
	{
		int NR = matrix.Length;
		int NC = matrix[0].Length;
		Dictionary<string, int> D = new Dictionary<string, int>();
		for (int r = 0; r < NR; r++)
		{
			char[] A = new char[NC];
			int x0 = matrix[r][0];
			for (int c = 0; c < NC; c++)
			// 这里使用异或运算符
				A[c] = (char)((matrix[r][c] ^ x0) + '0');
			string h = new string(A);
			int n;
			D.TryGetValue(h, out n);
			D[h] = n + 1;
		}

		int res = 0;
		foreach(int i in D.Values){
			res = Math.Max(res, i);
		}
		return res;
	}
}
