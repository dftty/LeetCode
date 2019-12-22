using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Third
{

    public class MaximumSideLengthofaSquarewithSumLessthanorEqualtoThreshold : MonoBehaviour
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
        https://leetcode.com/problems/maximum-side-length-of-a-square-with-sum-less-than-or-equal-to-threshold/
        Medium
        Tag: 数组 二分查找

        

        关键点：二维数组的前缀和数组

        */
        public int MaxSideLength(int[][] mat, int threshold) {
            int m = mat.Length, n = mat[0].Length;
            int[][] sum = new int[m + 1][];
            sum[0] = new int[n + 1];
            for (int i = 1; i <= m; i++){
                sum[i] = new int[n + 1];
                for (int j = 1; j <= n ;j++){
                    sum[i][j] = sum[i - 1][j] + sum[i][j - 1] - sum[i - 1][j - 1] + mat[i - 1][j - 1];
                }
            }
            
            int lo = 0, hi = Math.Min(m, n);
            
            while (lo <= hi){
                int middle = (lo + hi) / 2;
                
                if (BinarySearch(mat, sum, middle, threshold)){
                    lo = middle + 1;
                }else{
                    hi = middle - 1;
                }
            }
            
            return hi;
        }
        
        bool BinarySearch(int[][] mat, int[][] sum, int len, int threshold){
            for (int i = len; i <= mat.Length; i++){
                for (int j = len; j <= mat[0].Length; j++){
                    if (sum[i][j] - sum[i - len][j] - sum[i][j - len] + sum[i - len][j - len] <= threshold) return true;
                }
            }
            return false;
        }
    }

}