﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MergeIntervals : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	Merge Intervals
	对数组使用第一个数组排序，然后遍历添加到一个新的List中即可
	 */
	public int[][] Merge(int[][] intervals) {
        if(intervals == null || intervals.Length == 0) return new int[0][];
        Array.Sort(intervals, (a, b) =>{
            return a[0] - b[0];
        });
        List<int[]> result = new List<int[]>();
        result.Add(intervals[0]);
        int resultIndex = 0;
        
        for(int i = 1; i < intervals.Length; i++){
            if(intervals[i][0] <= result[resultIndex][1]){
                result[resultIndex][1] = Math.Max(result[resultIndex][1], intervals[i][1]);
            }else{
                result.Add(intervals[i]);
                resultIndex++;
            }
        }
        
        return result.ToArray();
    }
}
