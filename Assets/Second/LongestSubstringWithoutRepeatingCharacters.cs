using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LongestSubstringWithoutRepeatingCharacters : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	自己的解法：
	使用一个字典保存当前循环的字符的位置，如果已经存在，则更新位置，并且更新非重复字符串的起始点
	 */
	public int LengthOfLongestSubstring(string s) {
        if(string.IsNullOrEmpty(s)) return 0;
        int result = 1;
        int start = 0;
        Dictionary<char, int> dic = new Dictionary<char, int>();
        for(int i = 0; i < s.Length; i++){
            if(dic.ContainsKey(s[i])){
                start = Math.Max(dic[s[i]] + 1, start);
                dic[s[i]] = i;
            }else{
                dic.Add(s[i], i);
            }
            result = Math.Max(result, i - start + 1);
        }
        
        return result;
    }
}
