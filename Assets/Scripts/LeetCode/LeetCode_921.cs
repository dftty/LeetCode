using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_921 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/minimum-add-to-make-parentheses-valid/
	// 2018/10/16
	public int MinAddToMakeValid(string S) {
        Stack<char> stack = new Stack<char>();
        
        for(int i = 0; i < S.Length; i++){
            if(stack.Count == 0){
                stack.Push(S[i]);
                continue;
            }
            
            if(stack.Peek() == '(' && S[i] == ')'){
                stack.Pop();
            }else{
                stack.Push(S[i]);
            }
        }
        
        return stack.Count;
    }
}
