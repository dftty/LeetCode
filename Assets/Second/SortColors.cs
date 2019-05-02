using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortColors : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SortColors_(int[] A) {
        int j = 0, k = A.Length - 1;
        for (int i = 0; i <= k; ++i){
            if (A[i] == 0){
                swap(A, i, j);
                j++;
            }else if (A[i] == 2){
                swap(A, i, k);
                i--;
                k--;
            }
               
        }
    }
    
    public void swap(int[] A, int i, int j){
        int temp = A[i];
        A[i] = A[j];
        A[j] = temp;
    }
}
