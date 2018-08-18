using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_20 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Easy https://leetcode.com/problems/valid-parentheses/description/
	// use stack
	public bool IsValid(string s) {
        if("".Equals(s)) return true;
        
        Stack<char> result = new Stack<char>();
        result.Push(s[0]);
        
        for(int i = 1; i < s.Length; i++){
            if(result.Count == 0){
                result.Push(s[i]);
            }else{
                if(')' == s[i] && result.Peek() == '('){
                    result.Pop();
                }else if(']' == s[i] && result.Peek() == '['){
                    result.Pop();
                }else if('}' == s[i] && result.Peek() == '{'){
                    result.Pop();
                }else{
                    result.Push(s[i]);
                }
            }
        }
        
        return result.Count == 0 ? true : false;
        
    }
}
