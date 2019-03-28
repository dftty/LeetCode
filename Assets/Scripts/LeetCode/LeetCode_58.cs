using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_58 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Easy https://leetcode.com/problems/length-of-last-word/description/
	// 2018/6/2
    public int LengthOfLastWord(string s) {
        int count = 0;
        
        int i = s.Length - 1;
        while(i >= 0 && s[i] == ' '){
            i--;
        }
        
        for(; i >= 0; i--){
            if(s[i] != ' '){
                count++;
                continue;
            }else{
                break;
            }
        }
        
        return count;
    }
}
