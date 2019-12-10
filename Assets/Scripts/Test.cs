﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;

public class Test : MonoBehaviour {

    // Start is called before the first frame update
        void Start()
        {
            PalindromePartition("abc", 2);
        }

        // Update is called once per frame
        void Update()
        {
            
        }

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
