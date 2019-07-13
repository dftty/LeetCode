using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildcardMatching : MonoBehaviour
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
    https://leetcode.com/problems/wildcard-matching/

    动态规划题目
     */
    public bool IsMatch(string s, string p) {
        int m = s.Length, n = p.Length;
        bool[,] dp = new bool[m + 1,n + 1];
        
        for(int j = 1; j <= n ;j++){
            if(p[j - 1] != '*'){
                break;
            }else{
                dp[0, j] = true;
            }
        }
        
        dp[0, 0] = true;
        
        for(int i = 1; i <= m ;i++){
            for(int j = 1; j <= n; j++){
                if(p[j - 1] != '*'){
                    if(dp[i - 1, j - 1] && (s[i - 1] == p[j - 1] || p[j - 1] == '?')){
                        dp[i, j] = true;
                    }
                }else{
                    dp[i, j] = dp[i - 1, j] || dp[i, j - 1];
                }
            }
        }
        
        return dp[m, n];
    }
}
