using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Third
{

    public class PerfectSquares : MonoBehaviour
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
        https://leetcode.com/problems/perfect-squares/
        Tag: 动态规划

        思路：和选硬币题目类似，不过硬币面值变成了perfect number

        */
        public int NumSquares(int n) {
            List<int> list = new List<int>();
            for (int i = 1; i * i <= n; i++){
                list.Add(i * i);
            }
            int[] dp = new int[n + 1];
            for (int i = 1; i <= n; i++){
                dp[i] = int.MaxValue;
                for (int j = 0; j < list.Count; j++){
                    if (i - list[j] >= 0){
                        dp[i] = Math.Min(dp[i], dp[i - list[j]] + 1);
                    }
                }
            }
            
            return dp[n];
        }
    }

}