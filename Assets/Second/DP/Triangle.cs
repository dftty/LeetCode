using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Triangle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	Medium 题目
	可以从三角的最下面数组到最上面数组这样循环，每次选择最小的和
	 */
	public int MinimumTotal(IList<IList<int>> triangle) {
        if(triangle == null || triangle.Count == 0){
            return 0;
        }
        int n = triangle.Count;
        int[] dp = new int[triangle[n - 1].Count];
        
        for(int i = 0; i < triangle[n - 1].Count; i++){
            dp[i] = triangle[n - 1][i];
        }
        
        for(int i = n - 2; i >= 0; i--){
            IList<int> temp = triangle[i];
            for(int j = 0; j < temp.Count; j++){
                dp[j] = Math.Min(temp[j] + dp[j], temp[j] + dp[j + 1]);
            }
        }
        return dp[0];
    }
}
