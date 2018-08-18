using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_96 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/unique-binary-search-trees/description/
	// 2018/7/14
	// Discuss solution
	// F(i, n) = G(i - 1) * G(n - i)
	public int NumTrees(int n) {
        int[] result = new int[n + 1];
        result[0] = result[1] = 1;
        
        for(int i = 2; i <= n; i++){
            for(int j = 1; j <= i; j++){
                result[i] += result[j -1] * result[i - j];
            }
        }
        
        return result[n];
    }
}
