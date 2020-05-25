using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LastStoneWeightII : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	Discuss dp解法
    技巧：这个解法相当于把计算出了所有可能的和和差值，然后返回其中的最小值
	 */
	public int LastStoneWeightII_(int[] stones) {
        
        HashSet<int> res = new HashSet<int>();
        res.Add(0);
        
        for(int i = 0; i < stones.Length; i++){
            HashSet<int> plus = new HashSet<int>();
            HashSet<int> minus = new HashSet<int>();
            foreach(int k in res){
                plus.Add(k - stones[i]);
            }
            
            foreach(int k in res){
                minus.Add(k + stones[i]);
            }
            
            plus.UnionWith(minus);
            res = plus;
        }
        
        int min = int.MaxValue;
        foreach(int i in res){
            if(min > Math.Abs(i)){
                min = Math.Abs(i);
            }
        }
        return min;
    }

    /**
    技巧：类似于把这个数组分成两个子数组，两个子数组的和分别为S1和S2
    求S1 - S2的最小值

    dp[i, j] 的意思是前j个石头是否可以达成和为i。
    这样只要从sum / 2 + 1 到0找到最大的那个和res，然后sum - 2 * res就是答案。
     */
    public int LastStoneWeightII__(int[] stones) {
        int sum = 0;
        foreach(int i in stones){
            sum += i;
        }
        
        int n = stones.Length;
        bool[,] dp = new bool[sum / 2 + 1, n + 1];
        for(int i = 0; i < n + 1; i++){
            dp[0, i] = true;
        }
        int res = 0;
        for(int s = 1; s < sum / 2 + 1; s++){
            for(int i = 1; i < n + 1; i++){
                if(dp[s, i - 1] || (s >= stones[i - 1] && dp[s - stones[i - 1], i - 1])){
                    dp[s, i] = true;
                    res = Math.Max(res, s);
                }
            }
        }
        return sum - res - res;
    }
}
