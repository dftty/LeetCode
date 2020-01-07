using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Third
{

    public class XORQueriesofaSubarray : MonoBehaviour
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
        https://leetcode.com/problems/xor-queries-of-a-subarray/
        Medium
        Tag: 

        思路： 可以计算该数组的前缀异或，然后每个区间之内的异或为pre[query[i][1] + 1] ^ pre[query[i][1]]
        */

        public int[] XorQueries(int[] arr, int[][] queries) {
            int n = arr.Length;
            int[] pre = new int[n + 1];
            
            for (int i = 1; i <= n; i++){
                pre[i] = pre[i - 1] ^ arr[i - 1];
            }
            
            int[] res = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++){
                res[i] = pre[queries[i][1] + 1] ^ pre[queries[i][0]];
            }
            
            return res;
        }


        /**
        暴力解法 O(n^2) 时间
        */
        public int[] XorQueries_(int[] arr, int[][] queries) {
            int n = arr.Length;
            int[,] dp = new int[n, n];
            
            for (int i = 0; i < n; i++){
                int start = 0;
                for (int j = i; j < n; j++){
                    start ^= arr[j];
                    dp[i, j] = start;
                }
            }
            
            int[] res = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++){
                res[i] = dp[queries[i][0], queries[i][1]];
            }
            
            return res;
        }
    }

}