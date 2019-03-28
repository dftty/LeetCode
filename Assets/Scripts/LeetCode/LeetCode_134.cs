using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_134 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/gas-station/
	// 2018/9/26
	// Discuss solution
	public int CanCompleteCircuit(int[] gas, int[] cost) {
        int start = gas.Length - 1;
        int end = 0;
        int sum = gas[start] - cost[start];
        
        while(end < start){
            if(sum > 0){
                sum += gas[end] - cost[end];
                end++;
            }else{
                start--;
                sum += gas[start] - cost[start];
            }
        }
        
        return sum >= 0 ? start : -1;
    }
}
