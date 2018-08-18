using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_885 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/boats-to-save-people/description/
	// 2018/8/5
	// First sort, then use two pointer
	public int NumRescueBoats(int[] people, int limit) {
        if(people == null) return 0;
        Array.Sort(people);
        int hi = people.Length - 1;
        int lo = 0;
        int result = 0;
        while(lo <= hi){
            if(people[hi] == limit || people[hi] + people[lo] > limit){
                result++;
                hi--;
            }else if(people[hi] + people[lo] <= limit){
                result++;
                hi--;
                lo++;
            }
        }
        
        return result;
    }
}
