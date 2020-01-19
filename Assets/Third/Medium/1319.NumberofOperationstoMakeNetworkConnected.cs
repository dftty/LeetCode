using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Third
{

    public class NumberofOperationstoMakeNetworkConnected : MonoBehaviour
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
        https://leetcode.com/problems/number-of-operations-to-make-network-connected/
        Medium
        Tag: 并查集

        思路：使用并查集对电脑进行分组，在分组的过程中计算出额外的边，
        最后比较电脑的组数和额外的边的数量即可

        */
        public int MakeConnected(int n, int[][] connections) {
            int[] array = new int[n];
            
            for (int i = 0; i < array.Length; i++){
                array[i] = i;
            }
            
            int extra = 0;
            
            for (int i = 0; i < connections.Length; i++){
                int x = Find(connections[i][0], array);
                int y = Find(connections[i][1], array);
                
                if (x == y){
                    extra++;
                }else{
                    array[x] = array[y];
                }
            }
            
            int compon = 0;
            for (int i = 0; i < array.Length; i++){
                if (array[i] == i) compon++;
            }
            return extra >= compon - 1 ? compon - 1 : -1;
        }
        
        int Find(int index, int[] array){
            if (array[index] != index){
                array[index] = Find(array[index], array);
            }
            
            return array[index];
        }
    }

}