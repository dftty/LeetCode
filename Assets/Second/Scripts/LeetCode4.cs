using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode4 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
		int m = nums1.Length, n = nums2.Length;
		if(m > n){
			m = nums2.Length;
			n = nums1.Length;
			int[] temp = nums1;
			nums1 = nums2;
			nums2 = temp;
		} 
        
        

		int imin = 0, imax = m, half = (m + n + 1) / 2;
		while(imin <= imax){
			int i = (imin + imax) / 2;
			int j = half - i;

			if(j != 0 && i < m && nums2[j - 1] > nums1[i]){
				imin = i + 1;
			}else if(i != 0 && j < n && nums1[i - 1] > nums2[j]){
				imax = i - 1;
			}else{
				int max_left = 0;

				if(i == 0){
					max_left = nums2[j - 1];
				}else if(j == 0){
					max_left = nums1[i - 1];
				}else{
					max_left = Math.Max(nums1[i - 1], nums2[j - 1]);
				}

				if((m + n) % 2 == 1){
					return max_left;
				}

				int max_right = 0;
				if(i == m){
					max_right = nums2[j];
				}else if(j == n){
					max_right = nums1[i];
				}else{
					max_right = Math.Min(nums1[i], nums2[j]);
				}

				return (max_right + max_left) / 2f;
			}
		}
		return 0;
    }
}
