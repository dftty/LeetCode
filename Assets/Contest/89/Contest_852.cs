using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contest_852 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int PeakIndexInMountainArray(int[] A) {
        List<int> indexLists = new List<int>();
        
        for(int i = 1; i < A.Length - 1; i++){
            if(A[i] > A[i - 1] && A[i] > A[i + 1]){
                indexLists.Add(i);
            }
        }
        
        int result = 0;
        int peak = 0;
        for(int i = 0; i < indexLists.Count; i++){
            int index = indexLists[i];
            int left = 0;
            int right = 0;
            while(index >= 1 && A[index] > A[index - 1]){
                left++;
                index--;
            }
            
            index = indexLists[i];
            while(index < A.Length - 1 && A[index] > A[index + 1]){
                right++;
                index++;
            }
            
            if(left + right > peak){
                result = indexLists[i];
                peak = left = right;
            }
        }
        
        return result;
    }
}
