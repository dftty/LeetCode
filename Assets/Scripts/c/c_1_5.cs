using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_1_5 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log(HeadTail(new int[]{3, 6, 2, 1, 4, 5, 2}));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int HeadTail(int[] array){
		if(array == null || array.Length == 0){
			return 0;
		}
		int low = 0;
		int hi = array.Length - 1;
		int preSum = array[low];
		int sufSum = array[hi];
		int count = 0;
		while(low < array.Length || hi >= 0){
			if(preSum == sufSum){
				count++;
			}

			if(low == array.Length - 1 && hi == 0){
				break;
			}

			if(preSum > sufSum){
				sufSum += array[--hi];
			}else{
				preSum += array[++low];
			}
		}

		return count;
	}
}
