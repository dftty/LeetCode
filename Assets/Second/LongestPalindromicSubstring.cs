using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongestPalindromicSubstring : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int lo = 0;
    int max = 0;
    /**
    https://leetcode.com/problems/longest-palindromic-substring/

    最长回文字符串
    遍历字符串中的每个字符，把它当做回文字符串最中间的字符开始左右扩张，找出最大的回文串
     */
    public string LongestPalindrome(string s) {
        int len = s.Length;
        
        if(len < 2){
            return s;
        }
        
        for(int i = 0; i < len; i++){
            checkPalindromic(s, i, i); // 假设回文串长度为奇数
            checkPalindromic(s, i, i + 1);  // 假设回文串长度为偶数
        }
        
        return s.Substring(lo, max);
    }
    
    public void checkPalindromic(string s, int j, int k){
        while(j >= 0 && k < s.Length && s[k] == s[j]){
            j--;
            k++;
        }
        
        if(max < k - j - 1){
            lo = j + 1;
            max = k - j - 1;
        }
    }


    /**
    动态规划解法，dp[i][j] 代表从i到j的子字符串是否是回文
     */
    public string LongestPalindrome_DP(string s) {
        if(s.Length == 1) return s;
        int n = s.Length;
        bool[][] dp = new bool[n][];
        int start = 0;
        int len = 0;
        for(int i = n - 1; i >= 0; i--){
            if(dp[i] == null){
                dp[i] = new bool[n];
            }
            
            for(int j = i; j < n; j++){
                dp[i][j] = s[i] == s[j] && ((j - i < 2) || dp[i + 1][j - 1]);
                if(dp[i][j] &&j - i + 1 > len){
                    len = j - i + 1;
                    start = i;
                }
            }
        }
        
        return s.Substring(start, len);
    }
}
