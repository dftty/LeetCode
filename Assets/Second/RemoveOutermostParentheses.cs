using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class RemoveOutermostParentheses : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	https://leetcode.com/problems/remove-outermost-parentheses/
	Remove Outermost Parentheses

	简单题，使用stack可以求解
	 */
	public string RemoveOuterParentheses(string S) {
        Stack<char> stack = new Stack<char>();
        StringBuilder sb = new StringBuilder();
		int startIndex = 0;
		int count = 0;
        for(int i = 0; i < S.Length; i++){
			count++;
			if(stack.Count == 1 && stack.Peek() == '(' && S[i] == ')'){
				sb.Append(S.Substring(startIndex, count).Substring(1, count - 2));
				stack.Pop();
				count = 0;
				startIndex = i + 1;
			}else if(stack.Count > 0 && stack.Peek() == '(' && S[i] == ')'){
				stack.Pop();
			}else{
				stack.Push(S[i]);
			}
        }
        
        return sb.ToString();
    }

	/**
	Discuss解法，只用了一个简单的int值记录
	 */
	public string removeOuterParentheses(string S) {
        StringBuilder sb = new StringBuilder();
		int count = 0;
		for(int i = 0; i < S.Length; i++){
			if(S[i] == '(' && count++ > 0) sb.Append(S[i]);
			if(S[i] == ')' && count-- > 1) sb.Append(S[i]);
		}
		return sb.ToString();
    }
}
