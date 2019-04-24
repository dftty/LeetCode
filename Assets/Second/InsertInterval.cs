using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InsertInterval : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	Insert Interval

	首先添加所有小于newInterval的范围，然后计算出覆盖区域，最后，如果intervals中还有剩余，则添加。
	 */
	public int[][] Insert(int[][] intervals, int[] newInterval) {
        if(intervals == null || newInterval == null) return intervals;
        
        int i = 0;
        List<int[]> result = new List<int[]>();
        while(i < intervals.Length && intervals[i][1] < newInterval[0]){
            result.Add(intervals[i++]);
        }
        
        while(i < intervals.Length && intervals[i][0] <= newInterval[1]){
            newInterval[0] = Math.Min(intervals[i][0], newInterval[0]);
            newInterval[1] = Math.Max(intervals[i][1], newInterval[1]);
            i++;
        }
        
        result.Add(newInterval);
        while(i < intervals.Length){
            result.Add(intervals[i++]);
        }
        
        return result.ToArray();
    }
}
