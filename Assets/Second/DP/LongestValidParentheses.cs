using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LongestValidParentheses : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
    https://leetcode.com/problems/longest-valid-parentheses/

    stack 解法
    在stack中额外添加一个值
     */
    public int LongestValidParentheses_(string s) {
        Stack<int> stack = new Stack<int>();
        stack.Push(-1);
        int res = 0;
        for(int i = 0; i < s.Length; i++){
            if(s[i] == ')' && stack.Count > 1 && s[stack.Peek()] == '('){
                stack.Pop();
                res = Math.Max(res, i - stack.Peek());
            }else{
                stack.Push(i);
            }
        }
        
        return res;
    }
}
