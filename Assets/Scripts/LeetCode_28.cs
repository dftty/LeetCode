using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_28 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Easy https://leetcode.com/problems/implement-strstr/description/
	// Discuss solution
	// Brute force
	public int StrStr(string haystack, string needle) {
        for(int i = 0; ; i++){
			for(int j = 0; ; j++){
				if(j == needle.Length) return i;
				if(i + j == haystack.Length) return -1;
				if(needle[j] != haystack[i + j]) break;
			}
		}
    }


	// KMP 字符串匹配算法， 时间复杂度O(m + n)
	// 计算匹配数
	List<int> search(string text, string pattern){
		List<int> positions = new List<int>();
		int[] max_match_lengths = calc_max_match_length(pattern);
		int count = 0;

		for(int i = 0; i < text.Length; i++){
			while(count > 0 && pattern[count] != text[i]){
				count = max_match_lengths[count - 1];
			}

			if(pattern[count] == text[i]){
				count++;
			}

			if(count == pattern.Length){
				positions.Add(i - pattern.Length + 1);
				count = max_match_lengths[count - 1];
			}
		}

		return positions;
	}

	// 计算字符串跳转的位数
	int[] calc_max_match_length(string pattern){
		int[] max_match_lengths = new int[pattern.Length];
		int max_length = 0;

		for(int i = 0; i < pattern.Length; i++){
			while(max_length > 0 && pattern[i] != pattern[max_length]){
				max_length = max_match_lengths[max_length - 1];
			}

			if(pattern[i] == pattern[max_length]){
				max_length++;
			}

			max_match_lengths[i] = max_length;
		}

		return max_match_lengths;
	}
}
