using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Third
{

    public class MinimumFlipstoMakeaORbEqualtoc : MonoBehaviour
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
        https://leetcode.com/problems/minimum-flips-to-make-a-or-b-equal-to-c/
        Medium
        Tag: 

        思路：分别计算每个数字的比特位，保存在数组中，

        */
        public int MinFlips(int a, int b, int c) {
            int[][] arr = new int[3][];
            
            arr[0] = new int[32];
            int index = 0;
            while (a > 0){
                arr[0][index++] = a & 1;
                a = a >> 1;
            }
            
            arr[1] = new int[32];
            index = 0;
            while (b > 0){
                arr[1][index++] = b & 1;
                b = b >> 1;
            }
            
            arr[2] = new int[32];
            index = 0;
            while (c > 0){
                arr[2][index++] = c & 1;
                c = c >> 1;
            }
            
            int res = 0;
            for (int i = 0; i < 32; i++){
                if (arr[2][i] == 1){
                    if (arr[0][i] == 1 || arr[1][i] == 1){
                        continue;
                    }
                    
                    res++;
                }else{
                    if (arr[0][i] == 1){
                        res++;
                    }
                    
                    if (arr[1][i] == 1){
                        res++;
                    }
                }
            }
            
            return res;
        }

        public int MinFlips_(int a, int b, int c) {
            int res = 0;
            while (a > 0 || b > 0 || c > 0)
            {
                int bit_c = c & 1;
                int bit_a = a & 1;
                int bit_b = b & 1;
                if (bit_c == 1)
                {
                    if (bit_a == 0 && bit_b == 0) res++;
                }
                else
                {
                    if (bit_a == 1) res++;
                    if (bit_b == 1) res++;
                }

                c = c >> 1;
                a = a >> 1;
                b = b >> 1;
            }

            return res;
        }
    }

}