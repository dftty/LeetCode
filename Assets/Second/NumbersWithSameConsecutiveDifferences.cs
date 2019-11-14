using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumbersWithSameConsecutiveDifferences : MonoBehaviour
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
    https://leetcode.com/problems/numbers-with-same-consecutive-differences/

    深度优先搜索解法
    解题犯的错误： 没有考虑边界情况，当N为1时，应该返回所有1位数字

    c# 中int值和char值向加的结果为int值，需要进行强转
     */
    public int[] NumsSameConsecDiff(int N, int K) {
        HashSet<int> res = new HashSet<int>();
        
        if (N == 1){
            for (int i = 0; i < 10; i++){
                res.Add(i);
            }
            
            return new List<int>(res).ToArray();
        }
        
        for (int i = 1; i < 10; i++){
            List<char> temp = new List<char>();
            
            if (i - K >= 0){
                temp.Add((char)(i + '0'));
                dfs(N, K, res, temp, i);
                temp.RemoveAt(temp.Count - 1);
            }
            
            if (i + K < 10){
                temp.Add((char)(i + '0'));
                dfs(N, K, res, temp, i);
                temp.RemoveAt(temp.Count - 1);
            }
        }
        
        return new List<int>(res).ToArray();
        
    }
    
    void dfs(int N, int K, HashSet<int> res, List<char> temp, int i){
        if (temp.Count == N){
            res.Add(int.Parse(new string(temp.ToArray())));
            return ;
        }
        
        int plus = i + K;
        int minus = i - K;
        
        if (plus < 10){
            temp.Add((char)(plus + '0'));
            dfs(N, K, res, temp, plus);
            temp.RemoveAt(temp.Count - 1);
        }
        
        if (minus >= 0){
            temp.Add((char)(minus + '0'));
            dfs(N, K, res, temp, minus);
            temp.RemoveAt(temp.Count - 1);
        }
    }
}
