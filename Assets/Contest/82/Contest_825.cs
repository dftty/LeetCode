using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Contest_825 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log(NumFriendRequests(new int[]{16,17,18}));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/friends-of-appropriate-ages/description/
	// 2018/5/3
	// 定义一个年龄数组，然后计算各个年龄的人数。
	public int NumFriendRequests(int[] ages) {
		if(ages == null) return 0;
        
		int result = 0;
		int[] age = new int[121];
		foreach(int ag in ages){
			age[ag]++;
		}

		for(int i = 0; i < 121; i++){
			for(int j = 0; j < 121; j++){
				if(j * 2 <= i + 14 || j > i || (j > 100 && i < 100)){

				}else{
					if(i == j){
						result += age[i] * (age[i] - 1);
					}else{
						result += age[i] * age[j];
					}
				}
			}
		}

		return result;
    }
}
