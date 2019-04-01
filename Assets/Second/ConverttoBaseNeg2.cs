using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConverttoBaseNeg2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /**
    Convert to Base -2

    Given a number N, return a string consisting of "0"s and "1"s that represents its value in base -2 (negative two).

    The returned string must have no leading zeroes, unless the string is "0".

    Negative base 问题，在Discuss 中看到解法
    https://en.wikipedia.org/wiki/Negative_base#Calculation
    是用一个负数为基，构建一个自然数系统，类似于我们学习的2进制，8进制，10进制数，只不过这次的基为负数，
    在上面链接中给出类如何求解以-r （r >= 2）为基的一类问题。
     */
	public string BaseNeg2(int N) {
        string result = "";
        while(N != 0){
            int reminder = N % -2;
            N = N / -2;
            if(reminder < 0){
                reminder += 2;
                N += 1;
            }
            
            result = reminder + result;
        }
        
        return string.IsNullOrEmpty(result) ? "0" : result;
    }
}
