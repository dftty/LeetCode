using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_76 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		MinWindow("ADOBECODEBANC", "ABC");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public string MinWindow(string s, string t) {
        int[] map = new int[128];

		for(int i = 0; i < t.Length; i++){
			map[t[i]]++;
		}
		int counter = t.Length, begin = 0, end = 0, d = int.MaxValue, head = 0;
		while(end < s.Length){
			char c = s[end++];
			if(map[c]-- > 0) counter--;
			while(counter == 0){
				if(end - begin < d) d = end - (head=begin);
				if(map[s[begin++]]++ == 0) counter++;
			}
		}

		return d == int.MaxValue ? "" : s.Substring(head, d);
    }
}
