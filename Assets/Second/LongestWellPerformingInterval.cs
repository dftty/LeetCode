using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LongestWellPerformingInterval : MonoBehaviour
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
    https://leetcode.com/problems/longest-well-performing-interval/
    https://leetcode.com/problems/longest-well-performing-interval/discuss/334897/ChineseC%2B%2B-1124.-O(n)
    Discuss 解法
    这种问题为前缀和问题，对于当前遍历的数组值，如果大于8，则加一，否则前缀和减一
     */
    public int LongestWPI(int[] hours) {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        int sum = 0;
        int res = 0;
        for(int i = 0; i < hours.Length; i++){
            sum += hours[i] > 8 ? 1 : -1;
            if(sum > 0){
                res = i + 1;
            }else{
                if(dic.ContainsKey(sum - 1)){
                    res = Math.Max(res, i - dic[sum - 1]);
                }
            }
            
            if(!dic.ContainsKey(sum)){
                dic.Add(sum, i);
            }
        }
        return res;
    }

    /**
    另一种解法
    对于大于8小时的值为1， 小于8小时的值为-1
    然后求出对应的前缀和数组
    接下来在两个for循环中找出最大的间隔
     */
    public int LongestWPI_(int[] hours) {
        int n = hours.Length;
        int[] sum = new int[n + 1];
        for(int i = 1; i <= n; i++){
            sum[i] = sum[i - 1] + (hours[i - 1] > 8 ? 1 : -1);
        }
        
        int best = 0;
        for(int i = 0; i < n; i++){
            for(int j = n; j > i && j - i > best; j--){
                if(sum[i] < sum[j]){
                    best = j - i;
                }
            }
        }
        return best;
    }
}
