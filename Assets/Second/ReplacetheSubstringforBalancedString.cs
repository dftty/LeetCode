using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ReplacetheSubstringforBalancedString : MonoBehaviour
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
    https://leetcode.com/problems/replace-the-substring-for-balanced-string/

    Discuss 解法
    Sliding Window 题目
    
     */
    public int BalancedString(string s) {
        int[] count = new int[128];
        foreach (char str in s){
            count[str]++;
        }
        
        int n = s.Length, res = n, i = 0;
        for (int j = 0; j < n; j++){
            --count[s[j]];
            while(i < n && count['Q'] <= n / 4 && count['W'] <= n / 4 && count['E'] <= n / 4 && count['R'] <= n / 4){
                res = Math.Min(res, j - i + 1);
                ++count[s[i++]];
            }
        }
        
        return res;
    }
}
