using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Third
{

    public class SetMatrixZeroes : MonoBehaviour
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
        https://leetcode.com/problems/set-matrix-zeroes/
        Medium 
        Tag: 数组

        思路：可以使用matrix数组的第一行和第一列来保存改行或者该列是否需要设置为0
        对于第一行和第一列需要特殊判断。

        */
        public void SetZeroes(int[][] matrix) {
            if (matrix == null || matrix.Length == 0) return; 
            int m = matrix.Length, n = matrix[0].Length;
            bool row = false;
            bool col = false;
            for (int i = 0; i < m; i++){
                if (matrix[i][0] == 0){
                    col = true;
                }
            }
            
            for (int i = 0; i < n; i++){
                if (matrix[0][i] == 0){
                    row = true;
                }
            }
            
            for (int i = 1; i < m; i++){
                for (int j = 1; j < n; j++){
                    if (matrix[i][j] == 0){
                        matrix[i][0] = 0;
                        matrix[0][j] = 0;
                    }
                }
            }
            
            
            for (int i = 1; i < m; i++){
                if (matrix[i][0] == 0){
                    for (int j = 0; j < n; j++){
                        matrix[i][j] = 0;
                    }
                }
            }
            
            for (int j = 1; j < n; j++){
                if (matrix[0][j] == 0){
                    for (int i = 0; i < m; i++){
                        matrix[i][j] = 0;
                    }
                }
            }
            
            if (row){
                for (int i = 0; i < n; i++){
                    matrix[0][i] = 0;
                }
            }
            
            if (col){
                for (int i = 0; i < m; i++){
                    matrix[i][0] = 0;
                }
            }
        }


    }

}