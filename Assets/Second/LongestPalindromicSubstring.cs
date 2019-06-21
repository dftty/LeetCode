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
}
