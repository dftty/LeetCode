using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Third
{
    
    public class RotateImage : MonoBehaviour
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
        https://leetcode.com/problems/rotate-image/
        Medium
        Tag: 数组

        思路： 顺时针旋转矩阵可以先对矩阵进行上下反转，然后反转对角线上的数字即可
        示例如下
        1 2 3       7 8 9       7 4 1   
        4 5 6  =>   4 5 6   =>  8 5 2
        7 8 9       1 2 3       9 6 3

        技巧：遇到矩阵类需要交换位置的题目，首先考虑是否可以对矩阵进行
        上下或左右反转

        提交错误次数：0次
        */
        public void Rotate(int[][] matrix) {
            if (matrix == null || matrix.Length == 0) return ;
            Array.Reverse(matrix);
            
            for (int i = 0; i < matrix.Length; i++){
                for (int j = 0; j < i; j++){
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = temp;
                }
            }
        }

<<<<<<< HEAD
        /**
        c++ 实现
=======

        /**
        c++ 实现

>>>>>>> 406ceb1fc1c42364bcd8c4ead42007eb7d40eca9
        void rotate(vector<vector<int>>& matrix) {
            reverse(matrix.begin(), matrix.end());
            
            for (int i = 0; i < matrix.size(); i++){
                for (int j = 0; j < i; j++){
                    swap(matrix[i][j], matrix[j][i]);
                }
            }
        }
<<<<<<< HEAD


        */
=======
        */
        
>>>>>>> 406ceb1fc1c42364bcd8c4ead42007eb7d40eca9
    }

}