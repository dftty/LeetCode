using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_62 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log(UniquePaths(23, 7));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/unique-paths/description/
	// 2018/3/5
	// 根据youtube视频解法写出，为DP问题，每个问题可以分解为两个子问题。
	public int UniquePaths(int m, int n) {
		int[,] temp = new int[m, n];
        int result = compute(m, n, temp);

		return result;
    }
    
    public int compute(int m, int n, int[,] temp){ 
        if(m == 0 || n == 0) return 0;
		else if(m == 1 && n == 1) return 1;

		if(temp[m - 1, n - 1] == 0){
			temp[m - 1, n - 1] = compute(m - 1, n, temp) + compute(m, n - 1, temp);
		}
        return temp[m - 1, n - 1];
    }

}
