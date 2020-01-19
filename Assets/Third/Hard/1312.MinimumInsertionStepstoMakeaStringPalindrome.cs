using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Third
{

    public class MinimumInsertionStepstoMakeaStringPalindrome : MonoBehaviour
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
        https://leetcode.com/problems/minimum-insertion-steps-to-make-a-string-palindrome/
        Hard
        Tag: 动态规划

        思路： 我们想通常的回文字符串一样来进行匹配，我们就有两个指针i，j分别指向开始和结尾

            我们会遇到两种情况：
                1. i，j处的字符匹配
                2. i，j处的字符不匹配
            
            对于情况1，我们只需要对指针进行增减即可， i++， j--
            对于情况2，有两种选择
                1. 在j处插入一个字符来匹配i，这种情况下i++， j保持不变
                2. 在i处插入一个字符来匹配j，这种情况下j++， i保持不变
        
        时间复杂度O(n ^ 2) 空间复杂度O(n ^ 2)

        */
        int[,] dp;
        public int MinInsertions(string s) {
            dp = new int[s.Length, s.Length];
            
            for (int i = 0; i < s.Length; i++){
                for (int j = 0; j < s.Length; j++){
                    dp[i, j] = -1;
                }
            }
            
            return Dp(s, 0, s.Length - 1);
        }
        
        public int Dp(string s, int i, int j){
            if (i >= j){
                return 0;
            }else if (dp[i, j] != -1){
                return dp[i, j];
            }
            
            return dp[i, j] = s[i] == s[j] ? Dp(s, i + 1, j - 1) : 1 + Math.Min(Dp(s, i + 1, j), Dp(s, i, j - 1));
        }
    }

}