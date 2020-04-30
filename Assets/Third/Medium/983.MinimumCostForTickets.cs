using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Third
{

    public class MinimumCostForTickets : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        /**
        https://leetcode.com/problems/minimum-cost-for-tickets/
        Tag:动态规划

        思路：根据题意，可以推断出days[i]要花的钱为前一天加costs[0],或者前七天加costs[1]，或者前30天加costs[2]中的最小值，
        但是如果创建一个长度和days一样的dp数组，寻找前七天和前三十天需要添加许多判断。
        因此考虑题目中最多会有365天，那就创建一个长度为366的dp数组，这样找前七天和前三十天的下标就容易多了。

        */
        public int MincostTickets(int[] days, int[] costs) {
            int[] dp = new int[366];
            
            HashSet<int> hashSet = new HashSet<int>(days);
            
            for (int i = 1; i < dp.Length; i++){
                if (hashSet.Contains(i)){
                    dp[i] = dp[i - 1] + costs[0];
                    dp[i] = Math.Min(dp[i], dp[Math.Max(i - 7, 0)] + costs[1]);
                    dp[i] = Math.Min(dp[i], dp[Math.Max(i - 30, 0)] + costs[2]);
                }else {
                    dp[i] = dp[i - 1];
                }
            }
            
            return dp[365];
        }
    }

}