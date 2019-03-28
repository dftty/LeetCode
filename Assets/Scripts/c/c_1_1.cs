using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class c_1_1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log(GetMaxPlan(new int[]{1,2,2,3,3,3,4,5,5,5,5,6}));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int GetMaxPlan(int[] array){
		int length = 1;
		for(int i = 1; i < array.Length; i++){
			if(array[i] == array[i - length]){
				length++;
			}
		}


		return length;
	}
}
