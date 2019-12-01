using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MaximumScoreWordsFormedbyLetters : MonoBehaviour
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
    Discuss 解法
    使用回溯进行穷举，计算所有的可能。
    */
    int result = 0;
    public int MaxScoreWords(string[] words, char[] letters, int[] score) {
        int[] count = new int[26];
        
        foreach(char ch in letters){
            count[ch - 'a']++;
        }
        
        backTrack(words, count, score, 0, 0);
        return result;
    }
    
    void backTrack(string[] words, int[] count, int[] score, int start, int res){
        for (int i = start; i < words.Length; i++){
            bool valid = true;
            
            for (int j = 0; j < words[i].Length; j++){
                count[words[i][j] - 'a']--;
                res += score[words[i][j] - 'a'];
                if (count[words[i][j] - 'a'] < 0){
                    valid = false;
                }
            }
            
            if (valid){
                backTrack(words, count, score, i + 1, res);
                result = Math.Max(res, result);
            }
            
            for (int j = 0; j < words[i].Length; j++){
                count[words[i][j] - 'a']++;
                res -= score[words[i][j] - 'a'];
            }
        }
        
    }
}
