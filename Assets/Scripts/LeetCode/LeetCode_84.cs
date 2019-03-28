using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_84 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log(LargestRectangleArea(new int[]{2, 1, 2}));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Hard https://leetcode.com/problems/largest-rectangle-in-histogram/description/
    // 2018/4/21
    // Discuss solution
	public int LargestRectangleArea(int[] heights) {
        Stack<int> stack = new Stack<int>();
        int max_area = 0;
        
        for(int i=0; i<=heights.Length; ++i){
            int height_bound = (i == heights.Length) ? 0 : heights[i];
            
            while(stack.Count != 0){
                int h = heights[stack.Peek()];
                
                // calculate the area for every ascending slope.
                if(h < height_bound){
                    break;
                }
                stack.Pop();
                
                // at the end, the area with the height of the minimal element.
                int index_bound = stack.Count == 0 ? -1 : stack.Peek();
                max_area = Math.Max(max_area, h*((i-1)-index_bound));
            }
            
            stack.Push(i);
        }
        
        return max_area;
    }

}
