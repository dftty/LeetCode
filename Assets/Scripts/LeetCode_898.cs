using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_898 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SubarrayBitwiseORs(new int[]{1,2,4});
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int SubarrayBitwiseORs(int[] A) {
        int[] bitarray = new int[32];
        
        for(int i = 0; i < A.Length; i++){
            int temp = A[i];
            int j = 0;
            while(temp > 0){
                if(bitarray[j] == 0){
                    bitarray[j] = 1 & temp;
                }
                j++;
                temp = temp >> 1;
            }
        }
        
        int count = 0;
        for(int i = 0; i < bitarray.Length; i++){
            if(bitarray[i] == 1){
                count++;
            }
        }
        
        int top = 1;
        for(int i = 1; i <= count; i++){
            top *= i;
        }
        
        int result = 0;
        for(int i = 1; i <= count; i++){
            int bottom = 1;
			int bottom_1 = 1;
            for(int j = 1; j <= i; j++){
                bottom *= j;
            }
			for(int j = 1; j <= count - i; j++){
				bottom_1 *= j;
			}
            result += top / (bottom * bottom_1);
        }
        return result;
    }
}
