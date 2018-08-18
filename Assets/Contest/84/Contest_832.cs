using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contest_832 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int[][] FlipAndInvertImage(int[][] A) {
		if(A == null) return A;
        int m = A.Length;
        int n = A[0].Length;
		
        for(int i = 0; i < m; i++){
            for(int j = 0;j < n / 2; j++){
                int temp = A[i][j];
                A[i][j] = A[i][n - j - 1];
                A[i][n - j - 1] = temp;
            }
        }
        
        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                if(A[i][j] == 0){
                    A[i][j] = 1;
                }else{
                    A[i][j] = 0;
                }
            }
        }
        
        return A;
    }
}
