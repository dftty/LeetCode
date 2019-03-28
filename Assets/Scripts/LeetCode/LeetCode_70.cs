using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_70 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Easy https://leetcode.com/problems/climbing-stairs/description/
	// DP 类似斐波那契数列
	public int ClimbStairs(int n) {
        if(n == 1) return 1;
        
        int first = 1, second = 1;
        int result = 0;
        for(int i = 0; i < n - 1; i++){
            int temp = first + second;
            first = second;
            second = temp;
            result = temp;
        }
        
        return result;
    }
}
