using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Thrid
{

public class NumberofSubarraysofSizeKandAverage : MonoBehaviour
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
    https://leetcode.com/problems/number-of-sub-arrays-of-size-k-and-average-greater-than-or-equal-to-threshold/
    Medium
    Tag: 数组

    思路： 使用滑动窗口

    O(n) 时间， O(1) 空间
    */
    public int NumOfSubarrays(int[] arr, int k, int threshold) {
        int sum = 0;
        int i = 0;
        int res = 0;
        for (int j = 0; j < arr.Length; j++){
            if (j - i + 1 > k){
                sum -= arr[i++];
            }
            sum += arr[j];
            if (j - i + 1 == k && sum / k >= threshold){
                res++;
            }
        } 
        return res;
    }
}

}