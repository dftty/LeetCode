using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Third
{
    public class SpiralMatrixII : MonoBehaviour
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
        https://leetcode.com/problems/spiral-matrix-ii/
        Medium
        Tag: 数组

        思路：和54题类似，可以先创建数组，然后在while循环中逐一赋值

        提交错误次数：1次
        */
        public int[][] GenerateMatrix(int n) {
            int[][] res = new int[n][];
            
            for (int i = 0; i < n; i++){
                res[i] = new int[n];
            }
            
            int top = 0, bottom = n - 1, left = 0, right = n - 1;
            int count = 1;
            while (top <= bottom || left <= right){
                for (int i = left; i <= right; i++){
                    res[top][i] = count++;
                }
                
                top++;
                
                for (int i = top; i <= bottom; i++){
                    res[i][right] = count++;
                }
                
                right--;
                
                if (top <= bottom){
                    for (int i = right; i >= left; i--){
                        res[bottom][i] = count++;
                    }
                }
                
                bottom--;
                
                if (left <= right){
                    for (int i = bottom; i >= top; i--){
                        res[i][left] = count++;
                    }
                }
                
                left++;
            }
            
            return res;
        }

        /**
        c++ 实现
        vector<vector<int>> generateMatrix(int n) {
            vector<vector<int>> v(n, vector<int>(n, 0));
            
            int top = 0, bottom = n - 1, left = 0, right = n - 1;
            int cnt = 1;
            while (top <= bottom && left <= right){
                for (int i = left; i <= right; i++){
                    v[top][i] = cnt++;
                }
                
                top++;
                
                for (int i = top; i <= bottom; i++){
                    v[i][right] = cnt++;
                }
                
                right--;
                
                if (top <= bottom){
                    for (int i = right; i >= left; i--){
                        v[bottom][i] = cnt++;
                    }
                }
                
                bottom--;
                
                if (left <= right){
                    for (int i = bottom; i >= top; i--){
                        v[i][left] = cnt++;
                    }
                }
                
                left++;
            }
            
            return v;
        }

        */
    }

}