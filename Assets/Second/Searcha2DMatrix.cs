using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Searcha2DMatrix : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	Searcha2DMatrix
	典型的二分查找问题，两次二分查找即可解决
	 */
	public bool SearchMatrix(int[][] matrix, int target) {
        if(matrix == null || matrix.Length == 0) return false;
        if(matrix[0] == null || matrix[0].Length == 0) return false;
        int lo = 0, hi = matrix.Length - 1;
        int targetRow = -1;
        while(lo <= hi){
            int mid = (lo + hi) / 2;
            int len = matrix[mid].Length - 1;
            if(matrix[mid][0] <= target && target <= matrix[mid][len]){
                targetRow = mid;
                break;
            }else if(target > matrix[mid][len]){
                lo = mid + 1;
            }else{
                hi = mid - 1;
            }
        }
        
        if(targetRow == -1) return false;
        lo = 0;
        hi = matrix[targetRow].Length - 1;
        while(lo <= hi){
            int mid = (lo + hi) / 2;
            if(target == matrix[targetRow][mid]){
                return true;
            }else if(target > matrix[targetRow][mid]){
                lo = mid + 1;
            }else{
                hi = mid - 1;
            }
        }
        
        return false;
    }

	
}
