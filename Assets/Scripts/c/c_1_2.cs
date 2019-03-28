using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class c_1_2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log(GetMaxCount(new int[]{1, 3, 5, 7, 9}, new int[]{2, 3, 4, 7, 8}));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int GetMaxCount(int[] array1, int [] array2){
		int count = 0;
		int index1 = 0;
		for(int i = 0; i < array2.Length; i++){
			while(index1 < array1.Length && array2[i] >= array1[index1]){
				index1++;
			}
			count += array1.Length - index1;
		}


		return count;
	}
}
