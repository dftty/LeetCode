using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_97 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Hard https://leetcode.com/problems/interleaving-string/description/
	// 2018/8/30
	// discuss solution DP
	public bool IsInterleave(string s1, string s2, string s3) {
        if(s3.Length != s1.Length + s2.Length) return false;
        
        bool[,] result = new bool[s1.Length + 1, s2.Length + 1];
        for(int i = 0; i < s1.Length + 1; i++){
            for(int j = 0; j < s2.Length + 1; j++){
                if(i == 0 && j == 0){
                    result[i, j] = true;
                }else if(i == 0){
                    result[i, j] = result[i, j - 1] && s2[j - 1] == s3[i + j - 1];
                }else if(j == 0){
                    result[i, j] = result[i - 1, j] && s1[i - 1] == s3[i + j - 1];
                }else{
                    result[i, j] = (result[i, j - 1] && s2[j - 1] == s3[i + j - 1]) || (result[i - 1, j] && s1[i - 1] == s3[i + j - 1]);
                }
            }
        }
        
        return result[s1.Length, s2.Length];
    }


    // BFS
    public bool IsInterleave_(string s1, string s2, string s3) {
        if(s3.Length != s1.Length + s2.Length) return false;
        
        bool[,] result = new bool[s1.Length + 1, s2.Length + 1];
        Queue<int[]> queue = new Queue<int[]>();
        queue.Enqueue(new int[]{0, 0});
        while(queue.Count > 0){
            int[] point = queue.Dequeue();
            if(result[point[0], point[1]]) continue;
            
            if(point[0] == s1.Length && point[1] == s2.Length) return true;
            
            if(point[0] < s1.Length && s1[point[0]] == s3[point[0] + point[1]]){
                queue.Enqueue(new int[]{point[0] + 1, point[1]});
            }
            if(point[1] < s2.Length && s2[point[1]] == s3[point[0] + point[1]]){
                queue.Enqueue(new int[]{point[0], point[1] + 1});
            }
            result[point[0], point[1]] = true;
        }
        
        return false;
    }

}
