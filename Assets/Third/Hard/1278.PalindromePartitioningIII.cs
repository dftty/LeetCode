using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Third
{

    public class PalindromePartitioningIII : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            PalindromePartition("abc", 2);
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        /**
        https://leetcode.com/problems/palindrome-partitioning-iii/
        Hard
        Tag : 动态规划
        Contest 中第九名的解法，原解法为c++

        思路：可以利用一个cost数组来保存s字符串的子数组构成回文需要修改的字符数量
        cost[i, j] 代表从i到j的子字符串构成回文需要修改的字符数量

        dp[i, j] 代表从0到i的长度的字符串s切分成j块所需要的最小的修改字符数


        失误：解题是最初把dp[i, j]中的值都设置为int.MaxValue，导致在计算dp[x, j - 1] + cost[x, i - 1]时
        溢出，变成负最小值。

        当dp数组会进行加法运算时，小心不要使用int.MaxValue进行初始化

        */
        public int PalindromePartition(string s, int k) {
            int m = s.Length;
            int[,] cost = new int[m, m];
            
            for (int i = 0; i < s.Length; i++){
                for (int j = 1; j < s.Length; j++){
                    cost[i, j] = go(s, i, j);
                }
            }
            
            int[,] dp = new int[m + 1, k + 1];

            for (int i = 0; i <= m; i++){
                for (int j = 0; j <= k; j++){
                    dp[i, j] = 1 << 29;
                }
            }
            dp[0, 0] = 0;
            for (int i = 1; i <= m; i++){
                for (int j = 1; j <= k; j++){
                    for (int x = 0; x < i; x++){
                        dp[i, j] = Math.Min(dp[i, j], dp[x, j - 1] + cost[x, i - 1]);
                    }
                }
            }
            
            return dp[m, k];
        }
        
        int go(string s, int x, int y){
            int res = 0;
            while (x < y){
                if (s[x] != s[y]) res++;
                x++;
                y--;
            }
            
            return res;
        }
    }

}