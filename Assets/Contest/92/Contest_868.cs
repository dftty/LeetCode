using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contest_868 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int[][] Transpose(int[][] A) {
        if(A == null || A[0].Length == 0) return A;
        
        int[][] result = new int[A[0].Length][];

		for(int i = 0 ; i < result.Length; i++){
			result[i] = new int[A.Length];
		}
        
        for(int i = 0; i < A[0].Length; i++){
            for(int j = 0; j < A.Length; j++){
                result[i][j] = A[j][i];
            }
        }
        
        return result;
    }
}
