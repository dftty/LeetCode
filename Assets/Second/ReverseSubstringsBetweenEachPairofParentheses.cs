using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;

public class ReverseSubstringsBetweenEachPairofParentheses : MonoBehaviour
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
    https://leetcode.com/problems/reverse-substrings-between-each-pair-of-parentheses/

    递归解法
     */
    public string ReverseParentheses(string s) {
        int position = s.IndexOf('(');
        
        if (position == -1) return s;
        
        int level = 0;
        for (int i = position; i < s.Length; i++){
            if (s[i] == '('){
                level++;
            }else if(s[i] == ')'){
                level--;
                
                if (level == 0){
                    string ans = s.Substring(0, position);
                    string sub = s.Substring(position + 1, i - position - 1);
                    sub = ReverseParentheses(sub);
                    char[] ch = sub.ToCharArray();
                    Array.Reverse(ch);
                    sub = new string(ch);
                    ans = ans + sub + ReverseParentheses(s.Substring(i + 1));
                    return ans;
                }
            }
        }
        
        return "";
    }

    /**
    非递归解法
     */
    public string ReverseParentheses_(string s) {
        StringBuilder res = new StringBuilder();
        Stack<char> stack = new Stack<char>();
        List<StringBuilder> list = new List<StringBuilder>();
        list.Add(new StringBuilder(""));
        foreach (char c in s){
            if (c == '('){
                stack.Push(c);
                list.Add(new StringBuilder(""));
            }else if (stack.Count > 0 && c == ')'){
                char[] arr = list[list.Count - 1].ToString().ToCharArray();
                Array.Reverse(arr);
                list[list.Count - 2].Append(new string(arr));
                list.RemoveAt(list.Count - 1);
                stack.Pop();
            }else {
                list[list.Count - 1].Append(c);
            }
        }
        
        foreach(StringBuilder sbStr in list){
            res.Append(sbStr);
        }
        
        return res.ToString();
    }
}
