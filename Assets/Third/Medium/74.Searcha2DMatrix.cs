using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Third
{

    public class Searcha2DMatrix : MonoBehaviour
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
        https://leetcode.com/problems/search-a-2d-matrix/
        Medium
        Tag: 数组 二分查找

        思路：使用两次二分查找，第一次找到这个数字所属的matrix[mid]数组，
        然后第二次使用二分查找找到目标数。

        */
        public bool SearchMatrix(int[][] matrix, int target) {
            if (matrix == null || matrix.Length == 0) return false;
            int m = matrix.Length, n = matrix[0].Length;
            if (n == 0) return false;
            int lo = 0, hi = m - 1;
            int mid = -1;
            while (lo <= hi){
                int middle = (lo + hi) / 2;
                if (matrix[middle][0] <= target && target <= matrix[middle][n - 1]){
                    mid = middle;
                    break;
                }
                
                if (target < matrix[middle][0]){
                    hi = middle - 1;
                }else{
                    lo = middle + 1;
                }
            }
            
            if (mid == -1) return false;
            lo = 0;
            hi = n - 1;
            while (lo <= hi){
                int middle = (lo + hi) / 2;
                
                if (matrix[mid][middle] == target){
                    return true;
                }
                
                if (matrix[mid][middle] > target){
                    hi = middle - 1;
                }else{
                    lo = middle + 1;
                }
            }
            return false;
        }


        /**
        思路：可以将这个矩阵看成一个整体的数组来使用二分查找，
        每次计算middle之后，可以算出当前middle在matrix中的哪行哪列，然后比较即可
        
        n = matrix[0].Length
        row = middle / n;
        col = middle % n;
        
        提交错误次数：2次
            计算数组位置错误
        */
        public bool SearchMatrix_(int[][] matrix, int target) {
            if (matrix == null || matrix.Length == 0) return false;
            int m = matrix.Length, n = matrix[0].Length;
            if (n == 0) return false;
            
            int lo = 0, hi = m * n - 1;
            while (lo <= hi){
                int middle = (lo + hi) / 2;
                
                int i = middle / n;
                int j = middle % n;
                if (matrix[i][j] == target){
                    return true;
                }
                
                if (matrix[i][j] > target){
                    hi = middle - 1;
                }else{
                    lo = middle + 1;
                }
            }
            
            return false;
        }
    }

}