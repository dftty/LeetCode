using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_167 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Easy https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/description/
	// 2018/2/13
	public int[] TwoSum(int[] numbers, int target) {
        int[] result = new int[2];
        
        if(numbers.Length < 1){
            return result;
        }
        
        Dictionary<int, int> dic = new Dictionary<int, int>();
        
        for(int i = 0; i < numbers.Length; i++){
            if(dic.ContainsKey(target - numbers[i])){
                result[1] = i + 1;
                result[0] = dic[target - numbers[i]];
                return result;
            }

			// if has this key, then continue
            if(dic.ContainsKey(numbers[i])){
                continue;
            }
            dic.Add(numbers[i], i + 1);
        }
        return result;
    }
}
