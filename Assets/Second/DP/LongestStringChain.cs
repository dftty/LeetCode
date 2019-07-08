using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LongestStringChain : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	
	 */
	public int LongestStrChain(string[] words) {
        Dictionary<string, int > map = new Dictionary<string, int>();
        
        Array.Sort(words, (a, b) => {
            return a.Length - b.Length;
        });
        
        foreach(string str in words){
            int max = 1;
            for(int i = 0; i < str.Length; i++){
                string sub = str.Substring(0, i) + str.Substring(i + 1);
                int count = 0;
                if(map.ContainsKey(sub)){
                    count = map[sub] + 1;
                }
                max = Math.Max(max, count);
            }
            if(map.ContainsKey(str)){
                map[str] = Math.Max(max, map[str]);
            }else{
                map.Add(str, max);
            }
            
        }
        
        int result = 0;
        foreach(KeyValuePair<string, int> p in map){
            result = Math.Max(result, p.Value);
        }
        
        return result;
    }
}
