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
                while(stack.Peek() != '|' || stack.Peek() != '&' || stack.Peek() != '!'){
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
                    
                }
            }
        }
        return false;
    }
}
