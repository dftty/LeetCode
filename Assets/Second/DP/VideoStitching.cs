using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VideoStitching : MonoBehaviour {

	// Use this for initialization
	void Start () {
		VideoStitching_DP(new int[][]{new int[]{0, 2}, new int[]{4, 6}, new int[]{8, 10}, new int[]{1, 9}, new int[]{1, 5}, new int[]{5, 9}}, 10);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	Video Stitching
	Discuss 贪心算法
	 */
	public int VideoStitching_(int[][] clips, int T) {
		int result = 0;

		int end = -1, end2 = 0;
		Array.Sort(clips, (a, b) => {
			return a[0] - b[0];
		});

		foreach(int[] clip in clips){
			int i = clip[0], j = clip[1];
			if(end2 >= T || i > end2){
				break;
			}else if(i > end && i <= end2){
				result++;
				end = end2;
			}
			end2 = Math.Max(end2, j);
			Console.WriteLine(end2);
		}

		return end2 >= T ? result : -1;
    }

	/**
	贪心算法的另一种写法循环这个数组，在每个循环中，找到当前左边值中最大的右边的值，然后返回值加1
	 */
	public int VideoStitching__(int[][] clips, int T){
		int result = 0;
		Array.Sort(clips, (a, b) => {
			return a[0] - b[0];
		});

		int curend = 0;
		
		for(int i = 0; i < clips.Length; i++){
			if(clips[i][0] > curend){
				return -1;
			}
			int maxend = curend;
			while(i < clips.Length && clips[i][0] <= curend){
				i++;
				maxend = Math.Max(maxend, clips[i][1]);
			}

			result++;
			curend = maxend;
			if(curend >= T){
				return result;
			}
		}

		return -1;
	}

	/**
	DP solution
	 */
	public int VideoStitching_DP(int[][] clips, int T){
		int[] dp = new int[T + 1];
		for(int i = 0; i < dp.Length; i++){
			dp[i] = T + 1;
		}
		dp[0] = 0;
		for(int i = 0; i < T; i++){
			foreach(int[] c in clips){
				if(i >= c[0] && i <= c[1]) dp[i] = Math.Min(dp[i], dp[c[0]] + 1);
			}
			if(dp[i] == T + 1) return -1;
		}

		return dp[T];
	}


}
