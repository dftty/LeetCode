using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Contest_826 : MonoBehaviour {

	struct work{
		public int difficulty;
		public int profit;
	}

	// Use this for initialization
	void Start () {
		Debug.Log(MaxProfitAssignment(new int[]{13,37,58}, new int[]{4,90,96}, new int[]{34,73,45}));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/most-profit-assigning-work/description/
	// 2018/5/1
	// 
	public int MaxProfitAssignment(int[] difficulty, int[] profit, int[] worker) {
        int result = 0;

		work[] works = new work[difficulty.Length];

		for(int i = 0; i < difficulty.Length; i++){
			work temp = new work();
			temp.difficulty = difficulty[i];
			temp.profit = profit[i];
			works[i] = temp;
		}
		
		Array.Sort(works, (a, b) => a.difficulty - b.difficulty);

		for(int i = 1; i < works.Length; i++){
			works[i].profit = Math.Max(works[i].profit, works[i - 1].profit);
		}

		Array.Sort(worker);

		for(int i = 0; i < worker.Length; i++){
			int j = 0;
			while(j < works.Length && works[j].difficulty <= worker[i]) j++;
			j = j - 1 >= 0 ? j - 1 : j;
			if(worker[i] >= works[j].difficulty) result += works[j].profit;
		}


		return result;
    }

/**
	public int MaxProfitAssignment_(int[] difficulty, int[] profit, int[] worker) {
        int result = 0;

		List<KeyValuePair<int, int>> lists = new List<KeyValuePair<int, int>>();;

		for(int i = 0; i < difficulty.Length; i++){
			lists.Add(new KeyValuePair<int, int>(difficulty[i], profit[i]));
		}
		
		lists.Sort((a, b) => a.Key - b.Key);

		for(int i = 1; i < lists.Count; i++){
			lists[i].Key = Math.Max(lists[i].profit, lists[i - 1].profit);
		}

		Array.Sort(worker);

		for(int i = 0; i < worker.Length; i++){
			int j = 0;
			while(j < works.Length && works[j].difficulty <= worker[i]) j++;
			j = j - 1 >= 0 ? j - 1 : j;
			if(worker[i] >= works[j].difficulty) result += works[j].profit;
		}


		return result;
    }
 */
}
