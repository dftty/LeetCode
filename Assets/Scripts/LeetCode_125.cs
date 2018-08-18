using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_125 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log(IsPalindrome("p0~p"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    // Easy https://leetcode.com/problems/valid-palindrome/description/
    // 2018/6/6
    public bool IsPalindrome(string s) {
        int lo = 0;
        int hi = s.Length - 1;
        s = s.ToLower();
        
        while(lo <= hi){
            while(lo < s.Length && (!(s[lo] >= 97 && s[lo] <= 122) && !(s[lo] >= 48 && s[lo] <= 57))) lo++;
            while(hi >=0 && (!(s[hi] >= 97 && s[hi] <= 122) && !(s[hi] >= 48 && s[hi] <= 57))) hi--;
            
            if(lo < hi && s[lo] != s[hi]){
                return false;
            }else if(lo <= hi){
                lo++;
                hi--;
            }
        } 
        
        return true;
    }
}
