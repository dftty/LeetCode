using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;
using System.Linq;

public class LeetCode_890 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/find-and-replace-pattern/description/
	// 2018/8/19
	// Discuss solution
    public IList<string> FindAndReplacePattern(string[] words, string pattern) {
        List<string> result = new List<string>();
        int[] p = GetArray(pattern);
        
        for(int i = 0; i < words.Length; i++){
            int[] w = GetArray(words[i]);
            if(Enumerable.SequenceEqual(p, w)){
                result.Add(words[i]);
            }
        }
        return result;
    }
    
    public int[] GetArray(string str){
        Dictionary<char, int> tempSet = new Dictionary<char, int>();
        int n = str.Length;
        int[] result = new int[n];
        
        for(int i = 0; i < n; i++){
            if(!tempSet.ContainsKey(str[i])){
                tempSet.Add(str[i], tempSet.Count);
            }
            result[i] = tempSet[str[i]];
        }
        
        return result;
    }


	public IList<string> FindAndReplacePattern_(string[] words, string pattern) {
        List<string> result = new List<string>();
        
        
        for(int i = 0; i < words.Length; i++){
			bool isTrue = true;
            for(int j = 0; j < words[i].Length; j++){
				for(int k = j + 1; k < words[i].Length; k++){
					char jj = words[i][j];
					char kk = words[i][k];

					char pj = pattern[j];
					char pk = pattern[k];

					if(jj == kk){
						if(pj != pk) isTrue = false;
					}
					if(jj != kk){
						if(pj == pk) isTrue = false;
					}
				}
			}

			if(isTrue) result.Add(words[i]);
        }
        return result;
    }

}
