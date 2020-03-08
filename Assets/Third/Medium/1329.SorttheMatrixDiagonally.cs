using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Third
{

    public class SorttheMatrixDiagonally : MonoBehaviour
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
        https://leetcode.com/problems/sort-the-matrix-diagonally/
        Medium
        Tag : 数组 排序

        思路： 计算出总共的对角数，每次遍历中使用桶排序记录数字，然后将桶排序中的
        数字放回到原始数组中。

        */
        public int[][] DiagonalSort(int[][] mat) {
            int m = mat.Length, n = mat[0].Length;
            if (m == 1 || n == 1) return mat;
            int[] bucket = new int[101];
            
            // 当前对角线的起始数组下标
            int x = m - 1, y = 0;
            
            for (int i = 0; i < n + m - 1; i++){
                int j = x, k = y;
                for (;j < m && k < n; j++, k++){
                    bucket[mat[j][k]]++;
                }
                j = x;
                k = y;
                for (int l = 0; l < bucket.Length; l++){
                    while (bucket[l] > 0){
                        mat[j++][k++] = l;
                        bucket[l]--;
                    }
                }
                
                if (x == 0) y++;
                x = Math.Max(0, x - 1);
            }
            return mat;
        }
    }

}