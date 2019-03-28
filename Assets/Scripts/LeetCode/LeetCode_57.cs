using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_57 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Hard https://leetcode.com/problems/insert-interval/description/
	// 2018/4/17
	public IList<Interval> Insert(IList<Interval> intervals, Interval newInterval) {
        IList<Interval> result = new List<Interval>();

		Stack<Interval> temp_stack = new Stack<Interval>();

        if(intervals == null || intervals.Count == 0){
            result.Add(newInterval);
            return result;
        }
        
        bool isUse = false;
        
		for(int i = 0; i < intervals.Count; i++){
            if(temp_stack.Count > 0){
                if(newInterval.end > intervals[i].end){
                    if(i == intervals.Count - 1){
                        Interval temp = temp_stack.Pop();
                        temp.end = newInterval.end;
                        result.Add(temp);
                        isUse = true;
                    }
                    continue;
                }else{
                    if(newInterval.end < intervals[i].start){
                        Interval temp = temp_stack.Pop();
                        temp.end = newInterval.end > temp.end ? newInterval.end : temp.end;
                        result.Add(temp);
                        result.Add(intervals[i]);
                        isUse = true;
                    }else{
                        Interval temp = temp_stack.Pop();
                        temp.end = intervals[i].end;
                        result.Add(temp);
                        isUse = true;
                    }
                    continue;
                }
            }
            
            if(isUse == true) {
				result.Add(intervals[i]);
				continue;
			}
            
            if(newInterval.end < intervals[i].start){
                result.Add(newInterval);
                result.Add(intervals[i]);
                isUse = true;
            }else if(newInterval.start < intervals[i].start){
                intervals[i].start = newInterval.start;
                temp_stack.Push(intervals[i]);
            }else if(newInterval.start <= intervals[i].end && newInterval.end > intervals[i].end){
                temp_stack.Push(intervals[i]);
            }else if(newInterval.start <= intervals[i].end && newInterval.end <= intervals[i].end){
                result.Add(intervals[i]);
                isUse = true;
            }else {
                result.Add(intervals[i]);
            }
		}
        
        if(temp_stack.Count > 0){
            Interval temp = temp_stack.Pop();
            if(temp.end < newInterval.end) temp.end = newInterval.end;
            result.Add(temp);
        }
        
        if(!isUse && newInterval.start > intervals[intervals.Count - 1].end) result.Add(newInterval);

		return result;
    }
}

public class Interval {
     public int start;
    public int end;
	public Interval() { start = 0; end = 0; }
    public Interval(int s, int e) { start = s; end = e; }
}
