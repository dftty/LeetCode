using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TwoCityScheduling : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	Two City Scheduling
	There are 2N people a company is planning to interview. The cost of flying the i-th 
	person to city A is costs[i][0], and the cost of flying the i-th person to city B is costs[i][1].

	Return the minimum cost to fly every person to a city such that exactly N people arrive in each city.
	没有想出解法，直接看discuss

	标签里写的是贪心算法相关，对于每个人，我们计算出他去A城市和B城市之间的差，然后用这个差对数组进行排序
	排序完成后，左右的数组就是分开后去不同城市的人。左边一半去A还是去B取决于上述计算差值时是谁减谁。

	从这道题中，学习到了计算最值的一种方法，就是计算每一对数字的差值。
	 */
	public int TwoCitySchedCost(int[][] costs) {
        int result = 0;
        Array.Sort(costs, (a, b) => {
            return (a[0] - a[1]) - (b[0] - b[1]);
        });
        
        for(int i = 0; i < costs.Length / 2; i++){
            result += costs[i][0] + costs[i + costs.Length / 2][1];
        }
            
        return result;
    }
}
