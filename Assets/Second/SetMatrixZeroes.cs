using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMatrixZeroes : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	O(m + n)空间解法, 如何使用常数空间来解决该问题？
	要使用常数空间，但是每行和每列的0值必须需要记录，这样我们可以想
	是否可以用数组本身来保存需要记录的值。
	*/
	public void SetZeroes(int[][] matrix) {
        HashSet<int> cols = new HashSet<int>();
        HashSet<int> rows = new HashSet<int>();
        
        for(int i = 0; i < matrix.Length; i++){
            for(int j = 0; j < matrix[i].Length; j++){
                if(matrix[i][j] == 0){
                    cols.Add(j);
                    rows.Add(i);
                }
            }
        }
        
        foreach(int col in cols){
            for(int j = 0; j < matrix.Length; j++){
                matrix[j][col] = 0;
            }
        }
        
        foreach(int row in rows){
            for(int i = 0; i < matrix[0].Length; i++){
                matrix[row][i] = 0;
            }
        }
    }

	/**
	常数空间解法，利用数组本身来保存指定值
	 */
	public void SetZeroes_Discuss(int[][] matrix) {
        if(matrix == null) return ;

		int col0 = 1, rows = matrix.Length, cols = matrix[0].Length;

		for(int i = 0; i < rows; i++){
            if(matrix[i][0] == 0){
				col0 = 0;
			}
            
			for(int j = 1; j < cols; j++){
				if(matrix[i][j] == 0){
					matrix[i][0] = matrix[0][j] = 0;
				}
			}
		}

		for(int i = rows - 1; i >= 0; i--){
			for(int j = cols - 1; j >= 1; j--){
				if(matrix[i][0] == 0 || matrix[0][j] == 0){
					matrix[i][j] = 0;
				}
			}

			if(col0 == 0){
				matrix[i][0] = 0;
			}
		}
    }
}
