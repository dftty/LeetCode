using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_32 : MonoBehaviour {

    void Start(){
        
    }

    // Hard https://leetcode.com/problems/longest-valid-parentheses/description/
    // 2018/8/9
    // use stack  栈中放的是数组下标
    public int LongestValidParentheses(string s) {
        int n = s.Length;
        Stack<int> stack = new Stack<int>();

        for(int i = 0; i < n; i++){
            if(stack.Count == 0){
                stack.Push(i);
            }else if(s[i] == ')'){
                if(stack.Peek() == '(') stack.Pop();
                else stack.Push(i);
            }
        }    

        if(stack.Count == 0) return n;
        int a = n, b = 0;
        int max = 0;
        while(stack.Count > 0){
            b = stack.Pop();
            max = Math.Max(max, a - b - 1);
            a = b;
        }
        max = Math.Max(max, a);
        return max;
    }


    // Discuss DP solution
    // 
    public int LongestValidParentheses_(string s) {
        if (s == null || s.Length == 0) return 0;
        
        // build && init dp[i]: longest valid string that ends at index i
        int n = s.Length;
        int[] dp = new int[n];

        // calculate dp && track global max
        int max = 0;
        for (int i = 1; i < n; i++) {
            if (s[i] == '(') continue;

            bool consecutiveEnd = s[i - 1] == '(';
            int priorIndex = consecutiveEnd ? i - 1 : i - dp[i - 1] - 1;
            if (priorIndex < 0 || s[priorIndex] != '(') continue;

            dp[i] = 2 + addPriorLength(priorIndex, dp);
            dp[i] += consecutiveEnd ? 0 : dp[i - 1]; //add length from (priorIndex, i - 1]
            max = Math.Max(max, dp[i]);
        }

        return max;
    }

    private int addPriorLength(int priorIndex, int[] dp) {
        return (priorIndex - 1 >= 0) ? dp[priorIndex - 1] : 0;
    }
    

}


