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

	解题思路：假设第i行在翻转x列之后值全部为0
	1. 如果还有其他的值全部为0的行j，那么j行翻转之前的值应该和i行相同
	2. 如果有其他的值全部为1的行k，那么k行翻转之前的值应该和i行完全相反

	这样，题目就变成了找到第i行，在matrix中有完全相同和完全相反的列的数量最大。
	 */
	public int MaxEqualRowsAfterFlips(int[][] matrix) {
        int res = 0;
        int len = matrix.Length;
        int[] flip = new int[matrix[0].Length];
        
        for(int i = 0; i < len; i++){

			// 这是该行翻转之后的值
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

	思路同上，找出完全相同或完全相反的行

	对于每一行，我们使用第一个数字和其余数字做异或然后加 '0' 得出一个char数组
	例如： 对于 [0, 0, 1]  和 [1, 1, 0] 两个数组中的每个值都和数组中第一个数做异或然后加 '0'得出一个char数组
		[0, 0, 1] => ['0', '0', '1'] => "001"
		[1, 1, 0] => ['0', '0', '1'] => "001"
	然后将char数组转成string作为key保存在字典中，这样就可以找到答案了。

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
