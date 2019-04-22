using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RotateImage : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	Rotate Image
	Discuss 解法
	* clockwise rotate
	* first reverse up to down, then swap the symmetry 
	* 1 2 3     7 8 9     7 4 1
	* 4 5 6  => 4 5 6  => 8 5 2
	* 7 8 9     1 2 3     9 6 3
	 */
	public void Rotate(int[][] matrix) {
        if(matrix == null || matrix.Length == 0) return; 
        Array.Reverse(matrix);
        
        for(int i = 0; i < matrix.Length; i++){
            for(int j = i + 1; j < matrix[i].Length; j++){
                int temp = matrix[i][j];
                matrix[i][j] = matrix[j][i];
                matrix[j][i] = temp;
            }
        }
    }
}
