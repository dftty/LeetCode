using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contest_801 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log(MinSwap( new int[]{2,1,6,7,8,13,15,11,18,13,20,24,17,28,22,23,36,37,39,34,43,38,48,41,46,48,49,50,56,55,59,60,62,64,66,75,69,70,71,74,87,78,95,97,81,99,85,101,90,91,93,95,107,109,101,111,106,114,115,117,118,115,121,122,123,124,125,126,134,131,133,136,142,149,151,152,145,156,158,150,162,159,161,165,169,170,169,174,172,176,177,181,183,192,186,188,189,196,198,200}, new int[]{1,1,5,7,8,9,12,13,14,18}));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int MinSwap(int[] A, int[] B) {
        int result = 0;

		for(int i = 1; i < A.Length; i++){
			if(A[i] == A[i - 1]){
				if(i + 1 < A.Length && B[i] >= A[i + 1] && B[i] < B[i + 1]){
					swap(A, B, i - 1);
				}else {
					swap(A, B, i);
				}
				result++;
			}else if(B[i] == B[i - 1]){
				if(i + 1 < A.Length && A[i] <= B[i + 1] && A[i] < A[i + 1]){
					swap(A, B, i - 1);
				}else {
					swap(A, B, i);
				}
				result++;
			}else if(A[i] < A[i - 1]){
				if(i + 1 < A.Length && B[i] >= A[i + 1]){
					swap(A, B, i - 1);
				}else {
					swap(A, B, i);
				}
				result++;
			}else if(B[i] < B[i - 1]){
				if(i + 1 < A.Length && A[i] >= B[i + 1]){
					swap(A, B, i - 1);
				}else {
					swap(A, B, i);
				}
				result++;
			}
		}

		return result;
    }

	public void swap(int[] A, int[] B, int i){
		int temp = A[i];
		A[i] = B[i];
		B[i] = temp;
	}
}
