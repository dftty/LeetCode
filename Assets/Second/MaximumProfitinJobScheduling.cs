using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MaximumProfitinJobScheduling : MonoBehaviour
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
    https://leetcode.com/problems/maximum-profit-in-job-scheduling/

    动态规划+二分查找
    

     */
    public int JobScheduling(int[] startTime, int[] endTime, int[] profit) {
        int[][] jobs = new int[startTime.Length][];
        
        for (int i = 0; i < startTime.Length; i++){
            jobs[i] = new int[3];
            jobs[i][0] = startTime[i];
            jobs[i][1] = endTime[i];
            jobs[i][2] = profit[i];
        }
        
        Array.Sort(jobs, (a, b) => {
            return a[1] - b[1];
        });
        
        List<int> dpEndTime = new List<int>(){0};
        List<int> dpProfit = new List<int>(){0};
        
        for (int i = 0; i < jobs.Length; i++){
            int preIndex = search(dpEndTime, jobs[i][0]);
            
            int profit1 = dpProfit[preIndex] + jobs[i][2];
            int profit2 = dpProfit[dpProfit.Count - 1];
            
            if (profit1 > profit2){
                dpEndTime.Add(jobs[i][1]);
                dpProfit.Add(profit1);
            }
        }
        
        return dpProfit[dpProfit.Count - 1];
    }
    
    public int search(List<int> list, int target){
        int lo = 0;
        int hi = list.Count - 1;
        
        while (lo + 1 < hi){
            int mid = (lo + hi) / 2;
            
            if (list[mid] <= target){
                lo = mid;
            }else{
                hi = mid - 1;
            }
        }
        
        return list[hi] > target ? lo : hi;
    }
}
