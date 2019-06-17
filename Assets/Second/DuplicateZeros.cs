using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuplicateZeros : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DuplicateZeros_Discuss(new int[]{1, 0, 2, 3, 0, 4, 5, 0});
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	https://leetcode.com/problems/duplicate-zeros/
	Discuss解法
	用j指针记录数组中0的个数和数组长度
	 */
	public void DuplicateZeros_Discuss(int[] arr){
		int n = arr.Length, i = 0, j = 0;
		for(i = 0; i < n; i++, j++){
			if(arr[i] == 0) j++;
		}

		for(i = i - 1; i >= 0; i--){
			if(--j < n){
				arr[j] = arr[i];
			}

			if(arr[i] == 0 && --j < n){
				arr[j] = 0;
			}
		}
	}

	/**
	我的解法，首先遍历数组，计算没有超出界限的加倍的0的个数，然后从后向前赋值
	
	 */
	public void DuplicateZeros_(int[] arr) {
        int count_0 = 0;
        int index = 0;
        int len = arr.Length;
        for(int j = 0; j < len; j++){
            if(index >= len){
                break;
            }
            
            if(arr[j] == 0){
                count_0++;
                index += 2;
            }else{
                index += 1;
            }
        }
        
        int i = len - count_0 - 1 + (index > len ? 1 : 0);
        int newIndex = len - 1;
        if(arr[i] == 0 && index > len){
            arr[newIndex--] = 0;
            i--;
        }
        
        
        while(i >= 0){
            if(arr[i] == 0){
                arr[newIndex--] = 0;
                arr[newIndex--] = 0;
            }else{
                arr[newIndex--] = arr[i];
            }
            
            i--;
        }
        
    }
}
