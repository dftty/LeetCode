using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Third
{

    public class MinimumNumberofFlipstoConvertBinaryMatrixtoZeroMatrix : MonoBehaviour
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
        https://leetcode.com/problems/minimum-number-of-flips-to-convert-binary-matrix-to-zero-matrix/
        Hard
        Tag: 广度优先搜索

        思路：题目要求我们求出将矩阵mat变为全零矩阵的最少反转次数，因此一种合适的方法是使用广度优先搜索，
        我们把起始状态加入队列，并搜索其相邻的状态。 如果相邻的状态未被搜索过，则将其加入队尾，知道搜索到
        全零状态。

        每种变化的数组都表示一个状态，二维数组在保存时比较复杂，因此可以考虑将数组映射成一个int数
        例如   矩阵
        0 0 0
        0 1 0
        1 0 0
        展开就是  000010100 代表十进制数20，这样我们就设计了一个从二维矩阵到整数的映射方法
        因此我们需要如下函数：
            Encode(mat) 将二维矩阵mat映射成十进制数 x
            Decode(x) 将十进制数x映射成二维矩阵mat
        
        提交错误次数：0次
        */
        int m = 0;
        int n = 0;
        public int[][] d = {new int[]{1, 0}, new int[]{0, 1}, new int[]{-1, 0}, new int[]{0, -1}, new int[]{0, 0}};
        
        public int MinFlips(int[][] mat) {
            m = mat.Length;
            n = mat[0].Length;
                    
            int num = Encode(mat), res = 0;
            if (num == 0) return 0;
            
            HashSet<int> useSet = new HashSet<int>();
            Queue<int> queue = new Queue<int>();

            useSet.Add(num);
            queue.Enqueue(num);
            while (queue.Count > 0){
                res++;
                int len = queue.Count;
                for (int i = 0; i < len; i++){
                    int[][] status = Decode(queue.Dequeue());
                    
                    for (int j = 0; j < m; j++){
                        for (int k = 0; k < n; k++){
                            Convert(status, j, k);
                            num = Encode(status);
                            if (num == 0) return res;
                            if (!useSet.Contains(num)){
                                useSet.Add(num);
                                queue.Enqueue(num);
                            }
                            Convert(status, j, k);
                        }
                    }
                    
                }
            }
            
            return -1;
        }
        
        int Encode(int[][] mat){
            int res = 0;
            
            for (int i = 0; i < m; i++){
                for (int j = 0; j < n; j++){
                    res = res * 2 + mat[i][j];
                }
            }
            
            return res;
        }
        
        int[][] Decode(int target){
            int[][] res = new int[m][];
            
            for (int i = m - 1; i >= 0; i--){
                res[i] = new int[n];
                for (int j = n - 1; j >= 0; j--){
                    res[i][j] = target & 1;
                    target = (target >> 1);
                }
            }
            
            return res;
        }
        
        void Convert(int[][] mat, int i, int j){
            
            for (int k = 0; k < 5; k++){
                int x = i + d[k][0];
                int y = j + d[k][1];
                
                if (x >= 0 && x < m && y >= 0 && y < n){
                    mat[x][y] ^= 1;
                }
            }
        }

    }

}