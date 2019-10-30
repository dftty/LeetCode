using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MaximumLengthofaConcatenatedStringwithUniqueCharacters : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int res = 0;
    /**
    https://leetcode.com/problems/maximum-length-of-a-concatenated-string-with-unique-characters/

    回溯法
    要求从所有含有独一无二的字符的字符串组合中选出长度最长的
     */
    public int MaxLength(IList<string> arr) {
        List<string> list = (List<string>)arr;
        list.Sort();
        BackTrack(list, "", 0, new char[26]);
        return res;
    }
    
    public void BackTrack(List<string> arr, string combine, int start, char[] count){
        res = Math.Max(res, combine.Length);
        
        for (int i = start; i < arr.Count; i++){
            string temp = arr[i];
            //if (combine.Length + temp.Length > 26) break;
            bool unique = true;
            for (int j = 0; j < temp.Length; j++){
                count[temp[j] - 'a']++;
                if (count[temp[j] - 'a'] > 1){
                    unique = false;
                }
            }
            
            if (unique){
                BackTrack(arr, combine + temp, i + 1, count);
            }
            
            for (int j = 0; j < temp.Length; j++){
                count[temp[j] - 'a']--;
            }
        }
    }
}
