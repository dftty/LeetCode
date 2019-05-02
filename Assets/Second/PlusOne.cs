using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusOne : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	Plus One


	 */
	public int[] PlusOne_(int[] digits) {
        if(digits == null) return null;
        List<int> result = new List<int>();
        
        int mod = 1;
        for(int i = digits.Length - 1; i >= 0; i--){
            mod += digits[i];
            result.Insert(0, mod % 10);
            mod = mod / 10;
        }
        
		// 这里不能忘记最后的进位
        if(mod != 0){
            result.Insert(0, mod);
        }
        
        return result.ToArray();
    }

	/**
	Discuss解法， O(1)空间
	 */
	public int[] PlusOne_Discuss(int[] digits){
		if(digits == null) return null;

		int n = digits.Length; 

		for(int i = n - 1; i >= 0; i--){
			if(digits[i] < 9){
				digits[i]++;
				return digits;
			}

			digits[i] = 0;
		}

		int[] result = new int[n + 1];
		result[n] = 1;
		return result;
	}
}
