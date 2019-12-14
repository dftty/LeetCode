using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Third
{

    public class SpiralMatrix : MonoBehaviour
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
        https://leetcode.com/problems/spiral-matrix/
        Medium
        Tag: 数组

        思路： 使用四个指针记录矩阵的上下左右的下标

        提交错误次数：1次
            https://leetcode.com/submissions/detail/284757431/
            while循环条件应该为&&
        */
        public IList<int> SpiralOrder(int[][] matrix) {
            IList<int> res = new List<int>();
            if (matrix == null || matrix.Length == 0) return res;
            int top = 0, bottom = matrix.Length - 1, left = 0, right = matrix[0].Length - 1;
            
            while (top <= bottom && left <= right){
                for (int i = left; i <= right; i++){
                    res.Add(matrix[top][i]);
                }
                
                top++;
                
                for (int i = top; i <= bottom; i++){
                    res.Add(matrix[i][right]);
                }
                
                right--;
                
                if (bottom >= top){
                    for (int i = right; i >= left; i--){
                        res.Add(matrix[bottom][i]);
                    }
                }
                
                bottom--;
                
                if (right >= left){
                    for (int i = bottom; i >= top; i--){
                        res.Add(matrix[i][left]);
                    }
                }
                
                left++;
            }
            
            return res;
        }

        /**

        c++ 版本
        vector<int> spiralOrder(vector<vector<int>>& matrix) {
            vector<int> res;
            if (matrix.size() == 0) return res;
            int top = 0, bottom = matrix.size() - 1, left = 0, right = matrix[0].size() - 1;
            while (top <= bottom && left <= right){
                for (int i = left; i <= right; i++){
                    res.push_back(matrix[top][i]);
                }
                
                top++;
                
                for (int i = top; i <= bottom; i++){
                    res.push_back(matrix[i][right]);
                }
                
                right--;
                
                if (top <= bottom){
                    for (int i = right; i >= left; i--){
                        res.push_back(matrix[bottom][i]);
                    }
                }
                
                bottom--;
                
                if (left <= right){
                    for (int i = bottom; i >= top; i--){
                        res.push_back(matrix[i][left]);
                    }
                }
                
                left++;
            }
            
            return res;
        }

        */

    }

}