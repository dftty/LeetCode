using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendCircles : MonoBehaviour
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
    https://leetcode.com/problems/friend-circles/
    经典并查集类型题目
     */
    int[] un;
    public int FindCircleNum(int[][] M) {
        if (M == null || M.Length == 0) return 0;
        un = new int[M.Length];
        
        for (int i = 0; i < un.Length; i++){
            un[i] = i;
        }
        
        for (int i = 0; i < M.Length; i++){
            for (int j = i + 1; j < M.Length; j++){
                if (M[i][j] == 1){
                    Union(i, j);
                }
            }
        }
        
        HashSet<int> res = new HashSet<int>();
        for (int i = 0; i < un.Length; i++){
            res.Add(find(un[i]));
        }
        
        return res.Count;
    }
    
    void Union(int x, int y){
        int index_x = find(x);
        int index_y = find(y);
        
        un[index_x] = index_y;
    }
    
    int find(int x){
        if (un[x] != x){
            un[x] = find(un[x]);
        }
        
        return un[x];
    }
}
