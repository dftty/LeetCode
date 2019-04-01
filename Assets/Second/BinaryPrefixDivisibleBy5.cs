using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaryPrefixDivisibleBy5 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	Binary Prefix Divisible By 5
	Given an array A of 0s and 1s, consider N_i: the i-th subarray from A[0] to A[i] 
	interpreted as a binary number (from most-significant-bit to least-significant-bit.)
	Return a list of booleans answer, where answer[i] is true if and only if N_i is divisible by 5.

	是否可以被某个数整除，这类型题目大多会用到模运算，使用模运算后值会为余数

	计算从0到i 组成的二进制数是否可以被5整除
	i每向后移动一次，前一个数就需要左移一位，那么将上次的数 * 2 就可以了，然后加上A[i]的值，最后在模5，判断是否等于0。
	每个数只需要记录模5之后的值即可。
	 */
	public IList<bool> PrefixesDivBy5(int[] A) {
        IList<bool> result = new List<bool>();
        int num = 0;
        
        for(int i = 0; i < A.Length; i++){
            num = (num * 2 + A[i]) % 5;
            result.Add(num == 0);
        }
        
        return result;
    }
}
