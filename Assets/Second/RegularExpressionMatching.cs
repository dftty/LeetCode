using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularExpressionMatching : MonoBehaviour
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
    https://leetcode.com/problems/regular-expression-matching/
     */
    public bool IsMatch(string s, string p) {
        bool[,] dp = new bool[s.Length + 1, p.Length + 1];
        
        dp[0, 0] = true;
        for(int i = 1; i < p.Length; i++){
            if(p[i] == '*' && dp[0, i - 1]){
                dp[0, i + 1] = true;
            }
        }
        
        for(int i = 1; i <= s.Length; i++){
            for(int j = 1; j <= p.Length; j++){
                if(s[i - 1] == p[j - 1] || p[j - 1] == '.'){
                    dp[i, j] = dp[i - 1, j - 1];
                }
                
                if(p[j - 1] == '*'){
                    if(s[i - 1] != p[j - 2] && p[j - 2] != '.'){
                        dp[i, j] = dp[i, j - 2];
                    }else{
                        dp[i, j] = dp[i, j - 1] || dp[i - 1, j] || dp[i, j - 2];
                    }
                }
            }
        }
        
        return dp[s.Length, p.Length];
    }
}
