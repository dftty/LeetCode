using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class c_1_3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log(GetMaxCount_(new int[]{3, 5, 7, 8, 10}, new int[]{1, 3, 4, 7, 9}));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// <summary>
	/// for循环解法
	/// </summary>
	/// <param name="array1"></param>
	/// <param name="array2"></param>
	/// <returns></returns>
	public int GetMaxCount(int[] array1, int [] array2){
		int count = 0;
		int index1 = 0;
		for(int i = 0; i < array2.Length; i++){
			while(index1 < array1.Length && array2[i] > array1[index1]){
				index1++;
			}

			if(index1 < array1.Length && array2[i] == array1[index1]){
				count++;
				index1++;
			}
		}

		return count;
	}

	/// <summary>
	/// while循环解法
	/// </summary>
	/// <param name="array1"></param>
	/// <param name="array2"></param>
	/// <returns></returns>
	public int GetMaxCount_(int[] array1, int [] array2){
		int count = 0;
		int index1 = 0, index2 = 0;
		while(index1 < array1.Length && index2 < array2.Length){
			if(array1[index1] < array2[index2]){
				index1++;
			}else if(array1[index1] > array2[index2]){
				index2++;
			}else{
				count++;
				index1++;
				index2++;
			}
		}

		return count;
	}
}
