using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_88 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Easy https://leetcode.com/problems/merge-sorted-array/description/
	// 2018/2/12
	public void Merge(int[] nums1, int m, int[] nums2, int n) {
        int[] temp = new int[m];
        for(int i = 0 ; i < m; i++){
            temp[i] = nums1[i];
        }
        
        int j = 0, k = 0;
        
        if(n == 0){
            return ;
        }
        
        if(m == 0){
            for(int i = 0; i < n; i++){
                nums1[i] = nums2[i];
            }
            return;
        }
        
        for(int i = 0; i < m + n; i++){
            if(j >= m){
                j = m - 1;
                temp[j] = int.MaxValue;
            }
            if( k >= n){
                k = n - 1;
                nums2[k] = int.MaxValue;
            }
            if(temp[j] > nums2[k]){
                nums1[i] = nums2[k];
                k++;
            }else{
                nums1[i] = temp[j];
                j++;
            }
        }
    }
}
