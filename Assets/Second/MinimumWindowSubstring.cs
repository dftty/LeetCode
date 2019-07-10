using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimumWindowSubstring : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MinWindow("ADOBECODEBANC", "ABC");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
    https://leetcode.com/problems/minimum-window-substring/submissions/
    用一个数组来保存t字符串的字符个数
     */
    public string MinWindow(string s, string t) {
        int[] ch = new int[128];
        int count = t.Length, start = 0, end = 0, len = int.MaxValue;
        int resStart = 0;
        foreach(char c in t)
        {
            ch[c]++;
        }
        
        while(end < s.Length){
            if(ch[s[end]] > 0){ 
                count--;
            }
            ch[s[end]]--;
            end++;
            while(count == 0){
                if(len > end - start){
                    len = end - start;
                    resStart = start;
                }
                
                ch[s[start]]++;
                if(ch[s[start]] > 0){
                    count++;
                }
                start++;
            }
        }
        
        if(len != int.MaxValue){
            return s.Substring(resStart, len);
        }
        
        return "";
    }
}
