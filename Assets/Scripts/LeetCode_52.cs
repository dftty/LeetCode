using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_52 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log(TotalNQueens(4));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int TotalNQueens(int n) {
        int result = 0;
        
        int[] cols = new int[n];
        int[] dia_45 = new int[n * 2 - 1];
        int[] dia_135 = new int[n * 2 - 1];
        
        helper(n, 0, cols, dia_45, dia_135, ref result);
        
        return result;
    }
    
    public void helper(int n, int row, int[] cols, int[] dia_45, int[] dia_135, ref int result){
        if(row == n){
            result++;
            return ;
        }
            
        for(int col = 0; col != n; col++){
            if(cols[col] == 0 && dia_45[col + row] == 0 && dia_135[n - 1 + col - row] == 0){
                cols[col] = dia_45[col + row] = dia_135[n - 1 + col - row] = 1;
                helper(n, row + 1, cols, dia_45, dia_135, ref result);
                cols[col] = dia_45[col + row] = dia_135[n - 1 + col - row] = 0;
            }
        }
        
    }
}
