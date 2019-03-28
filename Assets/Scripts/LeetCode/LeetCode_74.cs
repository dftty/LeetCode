using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_74 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int[,] temp = new int[1, 0];
		Debug.Log(temp);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/search-a-2d-matrix/description/
	// 2018/3/9
	// 二分搜索， 提交三次通过， 原因边界和特殊情况。
    public bool SearchMatrix(int[,] matrix, int target) {
        int m = matrix.GetLength(0);
        int n = matrix.GetLength(1);

        if(n == 0){
            return false;
        }
        
        int row = 0;

        int lo = 0;
        int hi = m - 1;
        while(lo <= hi){
            int middle = (lo + hi) >> 1;
            if(target == matrix[middle,0]) return true;
            if(target == matrix[middle,n - 1]) return true;

            if(target > matrix[middle,0] && target < matrix[middle,n - 1]){
                row = middle;
                break;
            }else if(target < matrix[middle,0]){
                hi = middle - 1;
            }else if(target > matrix[middle,n - 1]){
                lo = middle + 1;
            }
        }

        lo = 1;
        hi = n - 2;
        while(lo <= hi){
            int middle = (lo + hi) >> 1;
            if(target == matrix[row,middle]) return true;
            else if(target < matrix[row,middle]) hi = middle - 1;
            else lo = middle + 1;
        }

        return false;
    }
	
}
