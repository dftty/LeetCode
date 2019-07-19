using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterleavingString : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(IsInterleave("ab", "bc", "babc"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
    https://leetcode.com/problems/interleaving-string/

    动态规划dp[i, j] 表示长度为i的s1 和长度为j的s2 是否可以组成长度为i + j 的s3 字符串
    dp[i, 0] 表示长度为i的s1 字符串是否可以按顺讯组成长度为i的s3 字符串
    dp[0, j] 表示长度为j的s2 字符串是否可以按顺序组成长度为j的s3 字符串

    做题的时候在第二个bool值赋值的时候出现了之前赋值为true没有进行或操作的错误
     */
    public bool IsInterleave(string s1, string s2, string s3) {
        int m = s1.Length, n = s2.Length;
        if(m + n != s3.Length) return false;
        bool[,] dp = new bool[m + 1, n + 1];
        dp[0, 0] = true;
        for(int i = 1; i <= m ; i++){
            if(s1[i - 1] != s3[i - 1]){
                break;
            }
            dp[i, 0] = true;
        }
        for(int i = 1; i <= n ; i++){
            if(s2[i - 1] != s3[i - 1]){
                break;
            }
            dp[0, i] = true;
            
        }
        for(int i = 1; i <= m; i++){
            for(int j = 1; j <= n; j++){
                // if(s1[i - 1] == s3[i + j - 1]){
                //     dp[i, j] = dp[i - 1, j];
                // }
                
                // if(s2[j - 1] == s3[i + j - 1]){
                //     dp[i, j] = dp[i, j - 1] || dp[i, j];
                // }
                dp[i, j] = (dp[i - 1, j] && s1[i - 1] == s3[i + j - 1]) || (dp[i, j - 1] && s2[j - 1] == s3[i + j - 1]);
            }
        }
        return dp[m , n];
    }
}
