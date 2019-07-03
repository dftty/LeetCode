using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;

public class MultiplyStrings : MonoBehaviour
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
    https://leetcode.com/problems/multiply-strings/
    字符串乘法
     */
    public string Multiply(string num1, string num2) {
        if(num1 == "0" || num2 == "0"){
            return "0";
        }
        
        StringBuilder res = new StringBuilder();
        int len1 = num1.Length, len2 = num2.Length;
        for(int i = len1 - 1; i >= 0; i--){
            StringBuilder temp = new StringBuilder();
            for(int j = 0; j < len1 - 1 - i; j++){
                temp.Append('0');
            }
            int left = 0;
            for(int j = len2 - 1; j >= 0; j--){
                int multi = (num1[i] - '0') * (num2[j] - '0');
                multi += left;
                
                temp.Append(multi % 10);
                left = multi / 10;
            }
            
            if(left != 0){
                temp.Append(left);
            }
            StringBuilder sb = new StringBuilder();
            int first = 0, second = 0;
            left = 0;
            while(first < res.Length || second < temp.Length){
                int num = left;
                if(first < res.Length){
                    num += res[first] - '0';
                    first++;
                }
                if(second < temp.Length){
                    num += temp[second] - '0';
                    second++;
                }
                sb.Append(num % 10);
                left = num / 10;
            }
            if(left != 0){
                sb.Append(left);
            }
            res = sb;
        }
        char[] chars = res.ToString().ToCharArray();
        Array.Reverse(chars);
        return new string(chars);
    }
}
