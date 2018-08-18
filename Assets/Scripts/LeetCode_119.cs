using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_119 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Easy https://leetcode.com/problems/pascals-triangle-ii/description/
	// 2018/2/13
	// use O(k) space
	public IList<int> GetRow(int rowIndex) {
        rowIndex += 1;
        int[] last = new int[rowIndex];
        int[] now = new int[rowIndex];
        
        for(int i = 1; i <= rowIndex; i++){
            for(int j = 0; j < i; j++){
                if(j == 0){
                    now[j] = 1;
                }else if(j == (i - 1)){
                    now[j] = 1;
                }else{
                    now[j] = last[j] + last[j - 1];
                }
            }
            
            Array.Copy(now, last, rowIndex);
        }
        
        IList<int> result = new List<int>(rowIndex);
        for(int i = 0; i < now.Length; i++){
            result.Add(now[i]);
        }
        
        return result;
    }

	// Discuss solution from back to front
	public IList<int> GetRow_Discuss(int rowIndex){
		IList<int> result = new List<int>(rowIndex);

		result[0] = 1;

		for(int i = 1; i < rowIndex + 1; i++){
			for(int j = i ; j > 0; j--){
				result[j] += result[j - 1];
			}
		}

		return result;
	}
}
