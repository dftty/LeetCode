using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_56 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Medium https://leetcode.com/problems/merge-intervals/description/
    // 2018/2/26
	public IList<Interval> Merge(IList<Interval> intervals) {
        if(intervals.Count == 0) return intervals;
        QuickSort(intervals, 0, intervals.Count - 1);
        
        IList<Interval> result = new List<Interval>();
        result.Add(intervals[0]);
        
        for(int i = 1; i < intervals.Count; i++){
            if(intervals[i].start <= result[result.Count - 1].end){
                result[result.Count - 1].end = Math.Max(intervals[i].end , result[result.Count - 1].end) ;
            }else{
                result.Add(intervals[i]);
            }
        }
        
        return result;
    }
    
    void QuickSort(IList<Interval> intervals, int p, int q){
        if(p > q){
            return ;
        }
        
        Interval val = intervals[p];
        int i = p;
        int j = q;
        while(i != j){
            while(i < j && intervals[j].start >= val.start) j--;
            while(i < j && intervals[i].start <= val.start) i++;
            
            if(i < j){
                Interval temp = intervals[j];
                intervals[j] = intervals[i];
                intervals[i] = temp;
            }
        }
        
        intervals[p] = intervals[i];
        intervals[i] = val;
        
        QuickSort(intervals, p, i - 1);
        QuickSort(intervals, i + 1, q);
        
        return ;
    }

    public class Interval{
		public int start;
		public int end;
		public Interval() { start = 0; end = 0; }
		public Interval(int s, int e) { start = s; end = e; }
	}
}
