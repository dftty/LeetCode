using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;

public class LeetCode_72 : MonoBehaviour {

    void Start(){
        
    }

    // Hard https://leetcode.com/problems/edit-distance/description/
    // 2018/8/17
    // discuss solution DP
    public int MinDistance(string word1, string word2) {
        int m = word1.Length;
        int n = word2.Length;
        
        int[,] result = new int[m + 1, n + 1];
        for(int i = 1; i <= m; i++){
            result[i, 0] = i;
        }
        
        for(int i = 1; i <= n; i++){
            result[0, i] = i;
        }
        
        for(int i = 1; i <= m; i++){
            for(int j = 1; j <= n; j++){
                if(word1[i - 1] == word2[j - 1]){
                    result[i, j] = result[i - 1, j - 1];
                }else{
                    result[i, j] = Math.Min(result[i, j - 1] + 1, Math.Min(result[i - 1, j] + 1, result[i - 1, j - 1] + 1));
                }
            }
        }
        
        return result[m,n];
    }
}


