using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_861 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int[][] test = new int[][]{new int[]{}};
		// [],[],[]
		Debug.Log(MatrixScore(test));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int MatrixScore(int[][] A) {
        if(A == null || A.Length == 0) return 0;
        if(A[0] == null || A[0].Length == 0) return 0;
        for(int i = 0; i < A.GetLength(0); i++){
			
            if(A[i][0] == 0){
                for(int j = 0; j < A[0].Length; j++){
                    A[i][j] = A[i][j] == 0 ? 1 : 0;
                }
            }
        }
        
          
        for(int j = 1; j < A[0].Length; j++){
            int count = 0;
            for(int i = 0; i < A.GetLength(0); i++){
                if(A[i][j] == 0) count++;
            }
            
            if(count > (A.GetLength(0) / 2)){
                for(int i = 0; i < A.GetLength(0); i++){
                    A[i][j] = A[i][j] == 0 ? 1 : 0;
                }
            }
        }
        
        int result = 0;
        for(int i = 0; i < A.GetLength(0); i++){
            for(int j = 0; j < A[0].Length; j++){
                if(A[i][j] == 1){
                    result += (1 << (A[0].Length - j - 1));
                }
            }
        }
        return result;
    }
}
