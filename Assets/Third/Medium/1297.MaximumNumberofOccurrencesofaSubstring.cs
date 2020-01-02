using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Third
{

    public class MaximumNumberofOccurrencesofaSubstring : MonoBehaviour
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
        https://leetcode.com/problems/maximum-number-of-occurrences-of-a-substring/
        Medium
        Tag: 字符串 滑动窗口

        思路：使用字典记录子字符串出现的次数，使用滑动窗口来满足条件
        因为最短的子字符串一定会出现最大的次数，因此无需考虑最大长度

        */
        public int MaxFreq(string s, int maxLetters, int minSize, int maxSize) {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            Dictionary<char, int> count = new Dictionary<char, int>();
            int i = 0;
            int res = 0;
            for (int j = 0; j < s.Length; j++){
                if (!count.ContainsKey(s[j])){
                    count.Add(s[j], 1);
                }else{
                    count[s[j]]++;
                }
                
                if (j - i + 1 > minSize){
                    count[s[i]]--;
                    if (count[s[i]] == 0){
                        count.Remove(s[i]);
                    }

                    i++;
                }
                
                if (count.Count <= maxLetters && j - i + 1 >= minSize){
                    string temp = s.Substring(i, j - i + 1);
                    if (dic.ContainsKey(temp)){
                        dic[temp]++;
                    }else {
                        dic.Add(temp, 1);
                    }
                    res = Math.Max(res, dic[temp]);
                }
            }
            return res;
        }

    }

}