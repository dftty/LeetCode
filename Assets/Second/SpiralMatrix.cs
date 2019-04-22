using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralMatrix : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	Spiral Matrix
	
	这个解法在写的时候遇到了许多边界问题和循环次数问题
	 */
	public IList<int> SpiralOrder(int[][] matrix) {
        if(matrix == null || matrix.Length == 0) return new List<int>();
        int m = matrix.Length; 
        int n = matrix[0].Length;
		// 这里应该选较小的数计算循环次数
        int count = m > n ? n : m;
        count = count % 2 == 0 ? count / 2 : count / 2 + 1;
        IList<int> result = new List<int>();
        
        for(int i = 0; i < count; i++){
            for(int j = i; j < n - i; j++){
                result.Add(matrix[i][j]);
            }
            
            for(int j = i + 1; j < m - i - 1; j++){
                result.Add(matrix[j][n - i - 1]);
            }    
            
            
            if(m - i - 1 != i){
                for(int j = n - i - 1; j >= i; j--){
                    result.Add(matrix[m - i - 1][j]);
                }    
            }
            
            if(i != n - i - 1){
                for(int j = m - i - 2; j >= i + 1; j--){
                    result.Add(matrix[j][i]);
                }       
            }
        }
        
        return result;
    }

    public IList<int> SpiralOrder_Discuss(int[][] matrix) {
        if(matrix == null || matrix.Length == 0) return new List<int>();
        IList<int> result = new List<int>();

        int rowStart = 0;
        int rowEnd = matrix.Length - 1;
        int colStart = 0;
        int colEnd = matrix[0].Length - 1;

        while(rowStart <= rowEnd && colStart <= colEnd){
            for(int i = colStart; i <= colEnd; i++){
                result.Add(matrix[rowStart][i]);
            }

            rowStart++;

            for(int i = rowStart; i <= rowEnd; i++){
                result.Add(matrix[i][colEnd]);
            }

            colEnd--;

            if(rowStart <= rowEnd){
                for(int i = colEnd; i >= colStart; i--){
                    result.Add(matrix[rowEnd][i]);
                }

                rowEnd--;
            }

            if(colStart <= colEnd){
                for(int i = rowEnd; i >= rowStart; i--){
                    result.Add(matrix[i][colStart]);
                }

                colStart++;
            }
        }
        return result;
    }
}
