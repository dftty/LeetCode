using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_91 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log(NumDecodings("266"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/decode-ways/description/
	// 2018/6/19
	// 本题起始解码是1， 所以当0出现时，是不能单独解码的。
	// 第二个问题， 在使用动态规划递归的时候，没有保存当前计算好的值，导致算法时间复杂度超过限制。
	public int NumDecodings(string s) {
		int result = 0;
		if(s == null || s.Equals("")) return result;
		int[] temp = new int[s.Length + 1];
		temp[0] = 1;
		compute(s.Length, temp, s);
		return temp[s.Length];
        
    }

	public int compute(int i, int[] temp, string s){ 
        if(i < 0) return 0;
		else if(i == 0) return 1;

		int k = 0, m = 0;
        if(s[i - 1] != '0'){
		    k = temp[i - 1] == 0 ? compute(i - 1, temp, s) : temp[i - 1];
        }
		if(i - 2 >= 0 && s[i - 1] <= '6' && s[i - 2] == '2'){
			m = temp[i - 2] == 0 ? compute(i - 2, temp, s) : temp[i - 2];
		}else if(i - 2 >= 0 && s[i - 2] == '1'){
            m = temp[i - 2] == 0 ? compute(i - 2, temp, s) : temp[i - 2];
        }
		temp[i] = k + m;

		return temp[i];
    }
}
