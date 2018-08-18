using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_44 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Hard https://leetcode.com/problems/wildcard-matching/description/
	// 2018/8/11
	// DP solution like 10
    public bool IsMatch(string s, string p) {
        bool[,] result = new bool[s.Length + 1, p.Length + 1];
        
        int index = 0;
        result[0, 0] = true;
        while(index < p.Length && p[index] == '*'){
            index++;
            result[0, index] = true;
        }
        
        for(int i = 0; i < s.Length; i++){
            for(int j = 0; j < p.Length; j++){
                if(p[j] == '?') result[i + 1, j + 1] = result[i, j];
                
                if(p[j] == s[i]) result[i + 1, j + 1] = result[i, j];
                
                if(p[j] == '*'){
                    result[i + 1, j + 1] = result[i + 1, j] || result[i, j + 1];
                }
            }
        }
        
        return result[s.Length, p.Length];
    }

}
