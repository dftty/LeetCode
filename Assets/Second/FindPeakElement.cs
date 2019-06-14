using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPeakElement : MonoBehaviour
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
    https://leetcode.com/problems/find-peak-element/
    利用二分查找计算出mid和mid + 1 可以保证当前计算的mid + 1不会超过数组限制,最后返回low
    
     */
    public int FindPeakElement_(int[] nums) {
        if(nums == null || nums.Length == 0) return 0;
        int low = 0;
        int hi = nums.Length - 1;
        
        while(low < hi){
            int mid = (low + hi) / 2;
            int mid1 = mid + 1;
            
            if(nums[mid] < nums[mid1]){
                low = mid1;
            }else{
                hi = mid;
            }
        }
        
        return low;
    }
}
