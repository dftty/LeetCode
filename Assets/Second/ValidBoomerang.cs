using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ValidBoomerang : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /**
    对比两条线的斜率是否相等即可
     */
	public bool IsBoomerang(int[][] points) {
        Array.Sort(points, (a, b) => {
            return a[0] - b[0];
        });
        
        if(points[0][0] == points[1][0] && points[0][1] == points[1][1]) return false;
        if(points[1][0] == points[2][0] && points[1][1] == points[2][1]) return false;
        if(points[0][0] == points[2][0] && points[0][1] == points[2][1]) return false;
        float first = (float)(points[2][1] - points[1][1]) / (float)(points[2][0] - points[1][0]);
        float second = (float)(points[2][1] - points[0][1]) / (float)(points[2][0] - points[0][0]);
        
        return first != second;
    }
}
