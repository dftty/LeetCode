using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralMatrixII : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	Spiral Matrix II
	和SpiralMatrix 一样
	 */
	public int[][] GenerateMatrix(int n) {
        int[][] result = new int[n][];
        
        for(int i = 0; i < n; i++){
            result[i] = new int[n];
        }
        
        int rowMin = 0, rowMax = n - 1;
        int colMin = 0, colMax = n - 1;
        int index = 1;
        while(rowMin <= rowMax || colMin <= colMax){
            for(int i = colMin; i <= colMax; i++){
                result[rowMin][i] = index++;
            }
            
            rowMin++;
            
            for(int i = rowMin; i <= rowMax; i++){
                result[i][colMax] = index++;
            }
            
            colMax--;
            
            for(int i = colMax; i >= colMin; i--){
                result[rowMax][i] = index++;
            }
            
            rowMax--;
            
            for(int i = rowMax; i >= rowMin; i--){
                result[i][colMin] = index++;
            }
            
            colMin++;
        }
        
        return result;
    }
}
