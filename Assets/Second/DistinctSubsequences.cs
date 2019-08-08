using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistinctSubsequences : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(NumDistinct("aab", "ab"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
    https://leetcode.com/problems/distinct-subsequences/

    动态规划
    重要的是找到递推公式
     */
    public int NumDistinct(string s, string t) {
        int m = s.Length, n = t.Length;
        int[,] dp = new int[m + 1, n + 1];
        for(int i = 0; i <= m; i++){
            dp[i, 0] = 1;
        }
        
        for(int j = 1; j <= n; j++){
            for(int i = 1; i <= m; i++){
                if(s[i - 1] == t[j - 1]){
                    dp[i, j] = dp[i - 1, j - 1] + dp[i - 1, j];
                }else{
                    dp[i, j] = dp[i - 1, j];
                }
            }
        }
        
        return dp[m, n];
    }
}
