using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_42 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log(Trap_1(new int[]{0,1,0,2,1,0,1,3,2,1,2,1}));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Hard https://leetcode.com/problems/trapping-rain-water/description/
	// 2018/4/9
	// 
	public int Trap(int[] height) {

		if(height.Length <= 2){
			return 0;
		}
		int low = 0;
		int hi = height.Length - 1;
		while(height[low] == 0) low++;
		while(height[hi] == 0) hi--;

		int left = height[low];
		int right = height[hi];

		low++;
		hi--;

		int result = 0;

		while(low <= hi){
			if(left <= right){
				for(int i = low; low <= hi; low++){
					if(height[low] >= left){
						left = height[low++];
						break;
					}else{
						result += left - height[low];
					}
				}
			}else{
				for(int i = hi; hi >= low; hi--){
					if(height[hi] >= right){
						right = height[hi--];
						break;
					}else{
						result += right - height[hi];
					}
				}
			}
		}
		return result;
	}

	// Discuss Solution 
	// use stack
	public int Trap_1(int[] height){
		int ans = 0, current = 0;
		Stack<int> st = new Stack<int>();
		while (current < height.Length) {
			while (st.Count > 0 && height[current] > height[st.Peek()]) {
				int top = st.Peek();
				st.Pop();
				if (st.Count == 0)
					break;
				int distance = current - st.Peek() - 1;
				int bounded_height = Math.Min(height[current], height[st.Peek()]) - height[top];
				ans += distance * bounded_height;
			}
			st.Push(current++);
		}
		return ans;
	}
}
