using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_915 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log(PartitionDisjoint(new int[]{5, 0, 3, 8, 6}));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/partition-array-into-disjoint-intervals/
	// 2018/10/9
	// Discuss solution
	public int PartitionDisjoint(int[] A) {
        int localmax = A[0], max = A[0], index = 0;
        for(int i = 1; i < A.Length; i++){
            if(localmax > A[i]){
                localmax = max;
                index = i;
            }else{
                max = Math.Max(max, A[i]);
            }
        }
        return index + 1;
    }
}
