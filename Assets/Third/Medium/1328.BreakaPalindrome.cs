using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Third
{

    public class BreakaPalindrome : MonoBehaviour
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
        https://leetcode.com/problems/break-a-palindrome/
        Medium
        Tag : 字符串

        思路：如果字符串的长度为1，那么直接返回空字符串，
        遍历字符串的前一半，如果其中有非 'a' 的字符，则把该字符设置为 'a' 即可，
        否则就把最后一个字符设置为'b'

        */
        public string BreakPalindrome(string s) {
            if (s.Length == 1)
            {
                return "";
            }
            
            int mid = s.Length / 2;
            char[] ch = s.ToCharArray();
            for (int i = 0; i < mid; i++){
                if (ch[i] == 'a'){
                    continue;
                }
                
                ch[i] = 'a';
                return new string(ch);
            }
            
            ch[ch.Length - 1] = 'b';
            return new string(ch);
        }
    }

}