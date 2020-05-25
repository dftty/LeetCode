using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Third
{

    public class OnesandZeroes : MonoBehaviour
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
        https://leetcode.com/problems/ones-and-zeroes/
        Tag: 动态规划

        思路：0-1背包类型问题，不过有两种判断条件

        */
        public int FindMaxForm(string[] strs, int m, int n) {
            int[,,] dp = new int[strs.Length + 1, m + 1, n + 1];
            
            for (int i = 1; i <= strs.Length; i++){
                int zero = 0;
                int one = 0;
                foreach (char c in strs[i - 1]){
                    if (c == '0'){
                        zero++;
                    }else{
                        one++;
                    }
                }
                
                for (int j = 0; j <= m; j++){
                    for (int k = 0; k <= n; k++){
                        int res = dp[i - 1,j,k];
                        if (j >= zero && k >= one){
                            res = Math.Max(res, dp[i - 1,j - zero,k - one] + 1);
                        }
                        
                        dp[i,j,k] = res;
                    }
                }
            }
            
            return dp[strs.Length,m,n];
        }
    }

}