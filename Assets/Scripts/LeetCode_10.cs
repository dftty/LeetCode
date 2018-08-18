using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_10 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log(IsMatch("mississippi", "mis*is*p*."));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Hard https://leetcode.com/problems/regular-expression-matching/description/
	// Discuss DP solution
	public bool IsMatch(string s, string p) {
        if (s == null || p == null) {
			return false;
		}
		bool[,] dp = new bool[s.Length+1,p.Length+1];
		dp[0,0] = true;
		for (int i = 0; i < p.Length; i++) {
			if (p[i] == '*' && dp[0,i-1]) {
				dp[0,i+1] = true;
			}
		}
		for (int i = 0 ; i < s.Length; i++) {
			for (int j = 0; j < p.Length; j++) {
				if (p[j] == '.') {
					dp[i+1,j+1] = dp[i,j];
				}
				if (p[j] == s[i]) {
					dp[i+1,j+1] = dp[i,j];
				}
				if (p[j] == '*') {
					if (p[j - 1] != s[i] && p[j - 1] != '.') {
						dp[i+1,j+1] = dp[i+1,j-1];
					} else {
						dp[i+1,j+1] = (dp[i+1,j] || dp[i,j+1] || dp[i+1,j-1]);
					}
				}
			}
		}
		return dp[s.Length,p.Length];
    }
}
