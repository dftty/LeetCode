using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniquePaths : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	Unique Paths

	DP 问题
	分解为子问题如下：
	result[i, j] = result[i - 1, j] + result[i, j - 1];
	 */
	public int UniquePaths_(int m, int n) {
        int[,] result = new int[m,n];
        result[0, 0] = 1;
        
        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                if(i == 0 || j == 0){
					result[ i, j] = 1;
				}
				else{
                	result[i, j] = result[i - 1, j] + result[i, j - 1];
				}
            }
        }
        
        return result[m - 1, n - 1];
    }
}
