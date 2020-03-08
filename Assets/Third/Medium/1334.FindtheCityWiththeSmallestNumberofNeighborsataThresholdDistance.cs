using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Third
{
    
    public class FindtheCityWiththeSmallestNumberofNeighborsataThresholdDistance : MonoBehaviour
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
        https://leetcode.com/problems/find-the-city-with-the-smallest-number-of-neighbors-at-a-threshold-distance/
        Medium
        Tag: 图

        Discuss 思路： Floyd-Warshall算法 多源最短路径问题 

        */
        public int FindTheCity(int n, int[][] edges, int distanceThreshold) {
            int[][] dp = new int[n][];
            
            for (int i = 0; i < n; i++){
                dp[i] = new int[n];
                for (int j = 0; j < n; j++){
                    dp[i][j] = 10001;
                    
                    if (i == j){
                        dp[i][j] = 0;
                    }
                }
            }
            
            for (int i = 0; i < edges.Length; i++){
                int x = edges[i][0], y = edges[i][1], z = edges[i][2];
                dp[x][y] = dp[y][x] = z;
            }
            
            for (int k = 0; k < n; k++){
                for (int i = 0; i < n; i++){
                    for (int j = 0; j < n; j++){
                        dp[i][j] = Math.Min(dp[i][j], dp[i][k] + dp[k][j]);
                    }
                }
            }
            
            int smallest = n + 1;
            int res = 0;
            for (int i = 0; i < n; i++){
                int count = 0;
                for (int j = 0; j < n; j++){
                    if (dp[i][j] <= distanceThreshold){
                        count++;
                    }
                }
                if (count <= smallest){
                    res = i;
                    smallest = count;
                }
            }
            
            return res;
        }
    }

}