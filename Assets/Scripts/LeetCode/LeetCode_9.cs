using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_9 : MonoBehaviour {

    void Start(){
        
    }

    // Easy https://leetcode.com/problems/palindrome-number/description/
    // 2018/8/7
    // 
    public bool IsPalindrome(int x) {
        if(x < 0) return false;
        int[] digit = new int[32];
        int index = 0;
        while(x != 0){
            digit[index++] = Math.Abs(x % 10);
            x = x / 10;
        }
        
        for(int i = 0; i < index; i++){
            if(digit[i] != digit[index - i - 1]){
                return false;
            }
        }
        
        return true;
    }


    // Discuss solution
    public bool IsPalindrome_(int x){
        if(x < 0 || (x != 0 && x % 10 == 0)) return false;

        int reverse = 0;
        while(x > reverse){
            reverse = reverse * 10 + x % 10;
            x = x / 10;
        }

        return x == reverse || x == reverse / 10;
    }

}


