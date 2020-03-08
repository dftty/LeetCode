using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Third
{

    public class MinimumNumberofTapstoOpentoWateraGarden : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public int MinTaps(int n, int[] ranges) {
            int[] dp = new int[n + 1];
            
            for (int i = 0; i < dp.Length; i++){
                dp[i] = n + 2;
            }
            
            dp[0] = 0;
            
            for (int i = 0; i <= n; i++){
                for (int j = Math.Max(i - ranges[i] + 1, 0); j <= Math.Min(i + ranges[i], n); j++){
                    dp[j] = Math.Min(dp[j], dp[Math.Max(0, i - ranges[i])] + 1);
                }
            }
            
            return dp[n] < n + 2 ? dp[n] : -1;
        }
    }

}