using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubarrayswithKDifferentIntegers : MonoBehaviour
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
    https://leetcode.com/problems/subarrays-with-k-different-integers/

    Discuss 第一种解法
    计算子数组中出现K个不同数字的所有可能情况
    可以转化为最多出现K次的数量减去最多出现K-1次的数量
     */
    public int SubarraysWithKDistinct(int[] A, int K) {
        return AtMost(A, K) - AtMost(A, K - 1);
    }
    
    /**
    计算数组中最多出现K个不同数字的子数组的所有可能情况
     */
    public int AtMost(int[] A, int K){
        Dictionary<int, int> countDic = new Dictionary<int, int>();
        int res = 0;
        int i = 0;
        
        for (int j = 0; j < A.Length; j++){
            int count = 0;
            countDic.TryGetValue(A[j], out count);
            if (count == 0) {
                K--;
                countDic.Add(A[j], 1);
            }else{
                countDic[A[j]]++;
            }
            
            while(K < 0){
                countDic[A[i]]--;
                if (countDic[A[i]] == 0){
                    countDic.Remove(A[i]);
                    K++;
                }
                i++;
            }
            
            res += j - i + 1;
        }
        
        return res;
    }
}
