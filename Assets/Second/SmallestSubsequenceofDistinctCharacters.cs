using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SmallestSubsequenceofDistinctCharacters : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
    https://leetcode.com/problems/smallest-subsequence-of-distinct-characters/
	Discuss 解法
	首先用一个数组对文本中出现的所有字母计数，记录每个字母出现了多少次
	然后另一个数组记录结果中是否已经使用这个字母

	每次循环，判断是否已经使用这个字母，如果是，则跳过，
    如果没有，则判断当前字母和结果字母的最后一位的大小
	
    技巧：循环判断两个字母的大小
         使用一维数组计数
	 */
	public string SmallestSubsequence(string text) {
        List<char> temp = new List<char>();
        
        int[] cnt = new int[26];
        int[] use = new int[26];
        
        foreach(char c in text){
            cnt[c - 'a']++;
        }
        
        foreach(char c in text){
            cnt[c - 'a']--;
            if(use[c - 'a']++ > 0) continue;
            
            while(temp.Count > 0 && temp[temp.Count - 1] > c && cnt[temp[temp.Count - 1] - 'a'] > 0){
                use[temp[temp.Count - 1] - 'a'] = 0;
                temp.RemoveAt(temp.Count - 1);
            }
            
            temp.Add(c);
        }
        
        return new String(temp.ToArray());
    }
}
