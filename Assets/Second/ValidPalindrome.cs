using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Text.RegularExpressions;

public class ValidPalindrome : MonoBehaviour
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
    https://leetcode.com/problems/valid-palindrome/

    O(n) 时间， O(n)空间解法
     */
    public bool IsPalindrome(string s) {
        StringBuilder sb = new StringBuilder();
        
        for(int i = 0; i < s.Length; i++){
            if(s[i] >= 'a' && s[i] <= 'z'){
                sb.Append(s[i]);
            }
            
            if(s[i] >= 'A' && s[i] <= 'Z'){
                sb.Append(s[i]);
            }
            
            if(s[i] >= '0' && s[i] <= '9'){
                sb.Append(s[i]);
            }
        }
        
        string str = sb.ToString().ToLower();
        int mid = str.Length % 2 == 0 ? str.Length / 2 - 1 : str.Length / 2;
        return Check(str, mid, str.Length % 2 == 0 ? mid + 1: mid);
    }
    
    bool Check(string str,  int left, int right){
        while(left >= 0 && right < str.Length){
            if(str[left] != str[right]){
                return false;
            }
            
            left--;
            right++;
        }
        
        return true;
    }


    /**
    另一种解法，利用正则表达式
     */
    public bool IsPalindrome_(string s) {
        s = Regex.Replace(s, "[^a-zA-Z0-9]", "");
        string str = s.ToLower();
        int mid = str.Length % 2 == 0 ? str.Length / 2 - 1 : str.Length / 2;
        return Check(str, mid, str.Length % 2 == 0 ? mid + 1: mid);
    }
}
