using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/longest-substring-without-repeating-characters/description/
	// 2018/5/5
	// Two Pointer 
	public int LengthOfLongestSubstring(string s) {
        int result = 0;
        
        int i = 0, j = 0;
        
        while(i < s.Length && j < s.Length){
            for(int k = i; k <= j - 1; k++){
                if(s[j] == s[k]){
                    i = k + 1;
                }
            }
            result = Math.Max(result, j - i + 1);
            j++;
        }
        
        return result;
    }
}
