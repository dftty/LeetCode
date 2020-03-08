using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Third
{
    
    public class ReduceArraySizetoTheHalf : MonoBehaviour
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
        https://leetcode.com/problems/reduce-array-size-to-the-half/
        Medium
        Tag: 数组

        思路：使用字典保存数组中每个数字出现的次数

        */
        public int MinSetSize(int[] arr) {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            
            for (int i = 0; i < arr.Length; i++){
                if (dic.ContainsKey(arr[i])){
                    dic[arr[i]]++;
                }else{
                    dic.Add(arr[i], 1);
                }
            }
            
            List<int> list = new List<int>(dic.Values);
            list.Sort();
            int res = 0;
            int count = 0;
            for (int i = list.Count - 1; i >= 0; i--){
                count += list[i];
                res++;
                
                if (count >= arr.Length / 2){
                    return res;
                }
            }
            return res;
        }
    }

}