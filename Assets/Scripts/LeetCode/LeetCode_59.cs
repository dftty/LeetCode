using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_59 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/spiral-matrix-ii/description/
	// 2018/2/27
	// 同54题
	public int[,] GenerateMatrix(int n) {
        int[,] result = new int[n,n];
        
        int up = 0,left = 0, right = n - 1, down = n - 1;
        int count = 1;
        while(true){
            for(int i = left; i <= right; i++) result[up, i] = count++;
            if(++up > down) break;
            for(int i = up; i <= down; i++) result[i, right] = count++;
            if(--right < left) break;
            for(int i = right; i >= left; i--) result[down, i] = count++;
            if(--down < up) break;
            for(int i = down; i >= up; i--) result[i, left] = count++;
            if(++left > right) break;
        }
        
        return result;
    }
}
