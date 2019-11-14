using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountNumberofNiceSubarrays : MonoBehaviour
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
    https://leetcode.com/problems/count-number-of-nice-subarrays/

    类似于Subarrays with K Different Integers
    可以转化为最多k次减去最多k-1次
    exactly(k) = AtMost(k) - AtMost(k - 1)
    */
    public int NumberOfSubarrays(int[] nums, int k) {
        return TotalCount(nums, k) - TotalCount(nums, k - 1);
    }
    
    public int TotalCount(int[] nums, int k){
        int res = 0;
        
        int j = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] % 2 != 0){
                k--;
            }
            
            while(k < 0 && j <= i){
                if (nums[j++] % 2 != 0){
                    k++;
                }
            }
            
            res += i - j + 1;
        }
        return res;
    }
}
