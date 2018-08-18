using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;

public class LeetCode_14 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/longest-common-prefix/description/
	// 2018/5/3
	// 边界情况， 字符串数组为空和第一个元素为空字符串
	public string LongestCommonPrefix(string[] strs) {
        if(strs == null || strs.Length == 0) return "";
        Array.Sort(strs, (a, b) => a.Length - b.Length);
        
        int temp = strs[0].Length;
        
        for(int i = 0; i < strs.Length; i++){
            for(int j = 0; j < strs[0].Length; j++){
                if(strs[i][j] == strs[0][j]){
                    continue;
                }else{
                    temp = Math.Min(temp, j);
                }
            }
        }
        
        return strs[0].Substring(0, temp);
    }
}
