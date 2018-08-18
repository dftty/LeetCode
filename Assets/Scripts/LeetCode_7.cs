using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_7 : MonoBehaviour {

    void Start(){
        
    }

    // Easy https://leetcode.com/problems/reverse-integer/description/
    // 2018/8/7
    // 每次循环中先计算一个newResult， 然后判断和result是否相等，这样可以判断出是否溢出。
    public int Reverse(int x) {
        int result = 0;

        while(x != 0){
            int tail = x % 10;
            int newResult = result * 10 + tail;
            if((newResult - tail) / 10 != result) return 0;
            x = x / 10;
            result = newResult; 
        }

        return result;
    }

}


