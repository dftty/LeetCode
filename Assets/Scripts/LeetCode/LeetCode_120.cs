using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_120 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/triangle/description/
	// 2018/3/20
	// 
	public int MinimumTotal(IList<IList<int>> triangle) {
        int min = 0;

		if(triangle == null || triangle.Count == 0 || triangle[0].Count == 0){
			return 0;
		}

		int[] results = new int[triangle[triangle.Count - 1].Count];
		results[0] = triangle[0][0];
		for(int i = 1; i < triangle.Count; i++){
			int current = results[0];
			for(int j = 0; j < triangle[i].Count; j++){
				if(j == 0){
					results[0] = current + triangle[i][j];
				}else if(j == triangle[i].Count - 1){
					results[triangle[i].Count - 1] = current + triangle[i][j];
				}else {
					min = Math.Min(current, results[j]);
					current = results[j];
					results[j] = min + triangle[i][j];
				}
			}
		}

		min = int.MaxValue;

		for(int i = 0; i < results.Length; i++){
			if(results[i] < min){
				min = results[i];
			}
		}

		return min;
    }
}
