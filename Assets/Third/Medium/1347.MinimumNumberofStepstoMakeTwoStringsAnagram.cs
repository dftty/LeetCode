using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Third
{
    public class MinimumNumberofStepstoMakeTwoStringsAnagram : MonoBehaviour
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
        https://leetcode-cn.com/problems/minimum-number-of-steps-to-make-two-strings-anagram/
        Medium
        Tag: 字符串

        思路：对两个字符串中的字符进行计数，然后计算字符差的绝对值的和，
        结果就是和除以2

        */
        public int MinSteps(string s, string t) {
            int[] count = new int[26];

            foreach (char c in s){
                count[c - 'a']--;
            }
            foreach (char c in t){
                count[c - 'a']++;
            }
            int res = 0;
            for (int i = 0; i < count.Length; i++){
                res += Math.Abs(count[i]);
            }
            return res / 2;
        }
    }

}