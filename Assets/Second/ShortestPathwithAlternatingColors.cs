using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShortestPathwithAlternatingColors : MonoBehaviour
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
    https://leetcode.com/problems/shortest-path-with-alternating-colors/

    BFS解法
     */
    public int[] ShortestAlternatingPaths(int n, int[][] red_edges, int[][] blue_edges) {
        HashSet<int>[][] graph = new HashSet<int>[n][];
        for(int i = 0; i < n; i++){
            graph[i] = new HashSet<int>[2];
            graph[i][0] = new HashSet<int>();
            graph[i][1] = new HashSet<int>();
        }
        
        for(int i = 0; i < red_edges.Length; i++){
            graph[red_edges[i][0]][0].Add(red_edges[i][1]);
        }
        
        for(int i = 0; i < blue_edges.Length; i++){
            graph[blue_edges[i][0]][1].Add(blue_edges[i][1]);
        }
        
        int[][] res = new int[n][];
        for(int i = 0; i < n; i++){
            res[i] = new int[2];
            res[i][0] = res[i][1] = int.MaxValue;
        }
        
        res[0][0] = res[0][1] = 0;
        
        Queue<int[]> queue = new Queue<int[]>();
        queue.Enqueue(new int[]{0, 0});
        queue.Enqueue(new int[]{0, 1});
        
        while(queue.Count > 0){
            int[] arr = queue.Dequeue();
            foreach(int next in graph[arr[0]][1 - arr[1]]){
                if(res[next][1 - arr[1]] > res[arr[0]][arr[1]] + 1){
                    res[next][1 - arr[1]] = res[arr[0]][arr[1]] + 1;
                    queue.Enqueue(new int[]{next, 1 - arr[1]});
                }
            }
        }
        
        int[] r = new int[n];
        for(int i = 0; i < res.Length; i++){
            int temp = Math.Min(res[i][0], res[i][1]);
            r[i] = temp == int.MaxValue ? -1 : temp;
        }
        
        return r;
    }
}
