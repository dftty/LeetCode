using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contest_870 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log(AdvantageCount(new int[]{718967141,189971378,341560426,23521218,339517772}, new int[]{967482459,978798455,744530040,3454610,940238504}));
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public int[] AdvantageCount(int[] A, int[] B) {
        int[] result = new int[A.Length];
        for(int i = 0; i < result.Length; i++){
            result[i] = -1;
        }
        
        for(int i = 0; i < A.Length; i++){
            int index = -1;
            int min = int.MaxValue;
            for(int j = 0; j < B.Length; j++){
                if(B[j] != -1 && A[i] - B[j] > 0 && A[i] - B[j] < min){
                    min = A[i] - B[j];
                    index = j;
                }
            }
            
            if(index != -1){
                result[index] = A[i];
                B[index] = -1;
                A[i] = -1;
            }
        }
        
        for(int i = 0; i < A.Length; i++){
            if(A[i] == -1) continue;
            for(int j = 0; j < A.Length; j++){
                if(result[j] == -1){
                    result[j] = A[i];
					break;
                }
            }
        }
        
        return result;
    }
}
