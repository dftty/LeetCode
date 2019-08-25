using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleNumber : MonoBehaviour
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
    https://leetcode.com/problems/single-number/
    直接异或数组中的所有数字即可
     */
    public int SingleNumber_(int[] nums) {
        int res = nums[0];
        
        for (int i = 1; i < nums.Length; i++){
            res ^= nums[i];
        }
        
        return res;
    }
}
