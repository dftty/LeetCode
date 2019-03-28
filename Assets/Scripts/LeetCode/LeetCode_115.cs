using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_115 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Hard https://leetcode.com/problems/distinct-subsequences/description/
	// 2018/8/23
	// Discuss solution DP
	// 
	public int NumDistinct(string s, string t) {
        int[,] result = new int[t.Length + 1, s.Length + 1];
        
        for(int i = 0; i < s.Length; i++){
            result[0, i] = 1;
        }
        
        for(int i = 0; i < t.Length; i++){
            for(int j = 0; j < s.Length; j++){
                if(t[i] == s[j]){
                    result[i + 1, j + 1] = result[i, j] + result[i + 1, j];
                }else{
                    result[i + 1, j + 1] = result[i + 1, j];
                }
            }
        }
        
        return result[t.Length, s.Length];
    }
}
