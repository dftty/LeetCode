using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParsingABooleanExpression : MonoBehaviour
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
    https://leetcode.com/problems/parsing-a-boolean-expression/

    表达式判断，利用stack来求解
     */
    public bool ParseBoolExpr(string s) {
        Stack<char> stack = new Stack<char>();
        
        for(int i = 0; i < s.Length; i++){
            if(s[i] == '!' || s[i] == '&' || s[i] == '|'){
                stack.Push(s[i]);
                i++;
                continue;
            }
            if(s[i] == ')'){
                bool hasT = false;
                bool hasF = false;
                while(stack.Count > 0 && stack.Peek() != '|' && stack.Peek() != '&' && stack.Peek() != '!'){
                    char ch = stack.Pop();
                    if(ch == 't'){
                        hasT = true;
                    }else{
                        hasF = true;
                    }
                }
                char c = stack.Pop();
                if(c == '|'){
                    stack.Push(hasT ? 't' : 'f');
                }else if(c == '&'){
                    stack.Push(hasF ? 'f' : 't');
                }else {
                    stack.Push(hasT ? 'f' : 't');
                }
            }else if(s[i] == 't' || s[i] == 'f'){
                stack.Push(s[i]);
            }
        }

        while(stack.Count > 1){
            stack.Pop();
        }

        return stack.Pop() == 't';
    }
}
