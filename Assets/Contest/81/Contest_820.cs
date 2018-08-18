using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Contest_820 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log(MinimumLengthEncoding_(new string[]{"time", "me", "bell"}));
		Debug.Log("time".Substring(2));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Mesium https://leetcode.com/problems/short-encoding-of-words/description/
	// 2018/4/22
	// Discuss
	public int MinimumLengthEncoding(string[] words) {
        int result = 0;

		HashSet<string> sets = new HashSet<string>();
		List<string> itemsToRemove = new List<string>();
		for(int i = 0; i < words.Length; i++){
			if(sets.Contains(words[i])) continue;
			sets.Add(words[i]);
		}

		
		for(int i = 0; i < words.Length; i++){
			for(int j = 1; j < words[i].Length; j++){
				sets.Remove(words[i].Substring(j));
			}
		}

		foreach(string s in sets){
			result += s.Length + 1;
		}

		return result;
    }

	// Contest No.1 solution
	public int MinimumLengthEncoding_(string[] words){
		int result = 0;

		Array.Sort(words, (a , b) => b.Length - a.Length);


		for(int i = 0; i < words.Length; i++){
			int can = 1;
			for(int j = 0; j < i; j++){
				if(words[i].Equals(words[j].Substring(words[j].Length - words[i].Length))){
					can = 0;
				}
			}
			if(can == 1) result += words[i].Length + 1;
		}

		return result;
	}

}
