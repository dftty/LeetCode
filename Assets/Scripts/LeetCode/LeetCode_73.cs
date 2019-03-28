using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_73 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/set-matrix-zeroes/description/
	// 2018/3/3
	// Discuss solution O(1) space
	public void SetZeroes(int[,] matrix) {
        bool row = false,colomn = false;
        
        if(matrix == null) return;
        
        int m = matrix.GetLength(0);
        int n = matrix.GetLength(1);
        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                if(matrix[i, j] == 0){
                    if(i == 0){
                        row = true;
                    }
                    if(j == 0){
                        colomn = true;
                    }
                    
                    matrix[0, j] = 0;
                    matrix[i, 0] = 0;
                }
            }
        }
        
        for(int i = 1; i < m; i++){
            for(int j = 1; j < n; j++){
                if(matrix[0, j] == 0 || matrix[i, 0] == 0){
                    matrix[i, j] = 0;
                }
            }
        }
        
        if(row){
            for(int i = 0; i < n; i++){
                matrix[0, i] = 0;
            }
        }
        
        if(colomn){
            for(int i = 0; i < m; i++){
                matrix[i, 0] = 0;
            }
        }
    }
}
