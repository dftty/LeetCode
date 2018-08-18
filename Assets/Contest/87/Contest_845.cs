using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contest_845 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int LongestMountain(int[] A) {
        List<int> indexs = new List<int>();
        
        for(int i = 1; i <= A.Length - 2; i++){
            if(A[i] > A[i - 1] && A[i] > A[i + 1]){
                indexs.Add(i);
            }
        }
        
        List<int> result = new List<int>();
        for(int i = 0; i < indexs.Count; i++){
            int left = 0;
            int right = 0;
            
            int index = indexs[i];
            while(index > 0 && A[index] > A[index - 1]){
                left++;
                index--;
            }
            index = indexs[i];
            while(index < A.Length - 1 && A[index] > A[index + 1]){
                right++;
                index++;
            }
            
            if(left > 0 && right > 0){
                result.Add(left + right + 1);
            }
        }
        
        int r = 0;
        for(int  i = 0; i < result.Count; i++){
            if(result[i] > r){
                r = result[i];
            }
        }
        
        return r;
    }
}
