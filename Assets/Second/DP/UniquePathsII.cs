using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniquePathsII : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	Unique Paths II
	和UniquePath类似，只是添加了障碍
	 */
	public int UniquePathsWithObstacles(int[][] obstacleGrid) {
        int n = obstacleGrid[0].Length;
		int[] result = new int[n];
		result[0] = 1;

		foreach(int[] row in obstacleGrid){
			for(int j = 0; j < n; j++){
				if(row[j] == 0){
					result[j] = 0;
				}else if(j > 0){
					result[j] += result[j - 1];
				}
			}
		}

		return result[n - 1];
    }
}
