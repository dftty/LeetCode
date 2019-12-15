using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Third
{

    public class SequentialDigits : MonoBehaviour
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
        https://leetcode.com/problems/sequential-digits/
        Medium 
        Tag: 回溯

        思路：
        定义一个方法GetDigitByLength。作用是传入一个长度，
        返回len长度的所有的该数字组成的数组

        例如，传入len为3 返回值为[123, 234, 345, 456, 567, 678, 789]

        因此，我们可以计算出low的长度len，从该长度开始遍历，从GetDigitByLength方法获取
        返回值，然后如果满足条件则添加到结果列表中。

        */
        public IList<int> SequentialDigits_(int low, int high) {
            int len = 0;
            int temp = low;
            while (temp > 0){
                len++;
                temp = temp / 10;
            }
            
            IList<int> res = new List<int>();
            for (int i = len; i <= 10; i++){
                List<int> list = GetDigitByLength(i);
                if (list[0] > high) break;
                foreach (int n in list){
                    if (n >= low && n <= high){
                        res.Add(n);
                    }
                }
            }
            return res;
        }
        
        List<int> GetDigitByLength(int len){
            List<int> res = new List<int>();
            
            int start = 0;
            int addValue = 0;
            for (int i = 1; i <= len; i++){
                start = start * 10 + i;
                addValue = addValue * 10 + 1;
            }
            
            res.Add(start);
            for (int i = 0; i < 10; i++){
                int next = res[res.Count - 1] + addValue;
                if (next % 10 != 0){
                    res.Add(next);
                }else {
                    break;
                }
            }
            
            return res;
        }


        /**
        思路： 回溯法，从起点12开始一直向后计算，满足low和high的条件就添加到结果列表


        */
        public IList<int> SequentialDigits__(int low, int high) {
            IList<int> res = new List<int>();
            BackTrack(res, 2, 12, 11, low, high);
            return res;
        }
        
        void BackTrack(IList<int> res, int len, int start, int addValue, int low, int high){
            if (len >= 10){
                return ;
            }
            
            for (int i = 0; i < 9; i++){
                int temp = start + addValue * i;
                if (temp > high){
                    return ;
                }
                
                if (temp % 10 == 0){
                    break;
                }
                
                if (temp >= low && temp <= high){
                    res.Add(temp);
                }
            }
            
            start = start * 10 + len + 1;
            addValue = addValue * 10 + 1;
            BackTrack(res, len + 1, start, addValue, low, high);
        }
    }

}