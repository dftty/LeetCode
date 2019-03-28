using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class c_1_4 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log(GetMaxCount_(new int[]{3, 5, 7, 8, 10}, new int[]{1, 3, 4, 7, 9}));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// <summary>
	/// while循环解法
	/// </summary>
	/// <param name="array1"></param>
	/// <param name="array2"></param>
	/// <returns></returns>
	public int GetMaxCount_(int[] array1, int [] array2){
		int count = int.MaxValue;
		int index1 = 0, index2 = 0;
		while(index1 < array1.Length && index2 < array2.Length){
			if(array1[index1] < array2[index2]){
				count = Math.Min(count, array2[index2] - array1[index1]);
				index1++;
			}else{
				count = Math.Min(count, array1[index1] - array2[index2]);
				index2++;
			}
		}

		return count;
	}
}
