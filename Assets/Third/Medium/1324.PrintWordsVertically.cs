using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

namespace Third
{

    public class PrintWordsVertically : MonoBehaviour
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
        https://leetcode.com/problems/print-words-vertically/
        Medium
        Tag: 字符串

        思路：题目中要求结果字符串中尾部不能有空格，因此可以将字符串切分，
        然后从后向前逐一将字符添加到list中

        */
        public IList<string> PrintVertically(string s) {
            List<StringBuilder> list = new List<StringBuilder>();
            
            string[] strs = s.Split(' ');
            
            for (int i = strs.Length - 1; i >= 0; i--){
                string t = strs[i];
                for (int j = 0; j < t.Length; j++){
                    if (list.Count == j){
                        list.Add(new StringBuilder());
                    }
                    
                    list[j].Insert(0, t[j]);
                }
                
                for (int j = t.Length; j < list.Count; j++){
                    list[j].Insert(0, ' ');
                }
            }
            
            IList<string> res = new List<string>();
            foreach (StringBuilder sb in list){
                res.Add(sb.ToString());
            }
            
            return res;
        }
    }

}