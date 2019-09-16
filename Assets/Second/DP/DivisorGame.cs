using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivisorGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	https://leetcode.com/problems/divisor-game/
	Divisor Game
	动态规划 Disscuss solution
	 */
	public bool DivisorGame_(int N) {
        bool[] dp = new bool[N + 1];
        for(int i = 1; i <= N; i++){
            for(int j = 1; j < i; j++){
                if(i % j == 0){
                    dp[i] |= !dp[i - j];
                }
            }
        }
        
        return dp[N];
    }
}
