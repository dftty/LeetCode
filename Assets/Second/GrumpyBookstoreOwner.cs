using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GrumpyBookstoreOwner : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	Sliding window 类型问题, sum[i] 代表 grumpy为1的情况下的前缀和
	 */
	public int MaxSatisfied(int[] customers, int[] grumpy, int X) {
        int n = customers.Length;
        int result = 0;
        if(X >= n){
            for(int i = 0; i < n; i++){
                result += customers[i];
            }
            return result;
        }
        int[] sum = new int[n];
        sum[0] = grumpy[0] == 0 ? 0 : customers[0];
		result = grumpy[0] == 0 ? customers[0] : 0;

        for(int i = 1; i < n; i++){
            if(grumpy[i] == 1){
                sum[i] = customers[i] + sum[i - 1];
            }else{
                sum[i] = sum[i - 1];
				result += customers[i];
            }
        }
        
        int maxnum = sum[X - 1], index = X - 1;
        for(int i = X; i < n; i++){
            if(sum[i] - sum[i - X] > maxnum){
                maxnum = sum[i] - sum[i - X];
                index = i;
            }
        }
        return result + maxnum;
    }

	/**
	Discuss 方法，更加简洁的Sliding window
	 */
	public int MaxSatisfied_(int[] customers, int[] grumpy, int X){
		int sum = 0, maxWindow = 0, window = 0;

		for(int i = 0; i < customers.Length; i++){
			sum += grumpy[i] == 0 ? customers[i] : 0;
			window += grumpy[i] == 1 ? customers[i] : 0;
			if(i >= X){
				window -= grumpy[i - X] == 1 ? customers[i - X] : 0;
			}

			maxWindow = Math.Max(maxWindow, window);
		}
		return sum + maxWindow;
	}

}
