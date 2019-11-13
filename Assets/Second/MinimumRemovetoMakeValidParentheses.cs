using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimumRemovetoMakeValidParentheses : MonoBehaviour
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
    https://leetcode.com/problems/minimum-remove-to-make-valid-parentheses/

    使用栈记录括号和括号对应的下标，然后遍历找出所有不匹配的括号，将下标遍历到HashSet中
    最后遍历字符串重新组成结果字符串返回
    */
    public string MinRemoveToMakeValid(string s) {
        Stack<KeyValuePair<char,int>> stack = new Stack<KeyValuePair<char,int>>();
        
        for (int i = 0; i < s.Length; i++){
            if (s[i] >= 'a' && s[i] <= 'z'){
                continue;
            }
            if (stack.Count == 0){
                stack.Push(new KeyValuePair<char,int>(s[i], i));
                continue;
            }
            
            if (s[i] == ')' && stack.Peek().Key == '('){
                stack.Pop();
            }else{
                stack.Push(new KeyValuePair<char,int>(s[i], i));
            }
        }
        
        HashSet<int> removeSet = new HashSet<int>();
        
        foreach(KeyValuePair<char, int> pair in stack){
            removeSet.Add(pair.Value);
        }
        
        List<char> list = new List<char>();
        
        for (int i = 0; i < s.Length; i++){
            if (!removeSet.Contains(i)){
                list.Add(s[i]);
            }
        }
        
        return new string(list.ToArray());
    }
}
