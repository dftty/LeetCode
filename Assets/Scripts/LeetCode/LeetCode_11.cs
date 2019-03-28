using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_11 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int[] height = new int[]{1, 2, 1};
		Debug.Log(MaxArea(height));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/container-with-most-water/description/
	// 2018/2/11
	// Discuss O(n) solution
	// The widest area should the first choose
	public int MaxArea(int[] height) {
        int i = 0, j = height.Length - 1;
		int water = 0;
		int length = 0;
		while(i < j){
			length = height[i] < height[j] ? height[i] : height[j];
			if(length * (j - i) > water){
				water = length * (j - i);
			}

			if(height[i] < height[j]){
				i++;
			}else{
				j--;
			}
		}

		return water;
    }
}
