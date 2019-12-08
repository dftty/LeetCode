using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Third
{

    public class FindtheSmallestDivisorGivenaThreshold : MonoBehaviour
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
        https://leetcode.com/problems/find-the-smallest-divisor-given-a-threshold/
        Medium
        Tag: 二分查找

        思路:根据题意可以知道这个divisor的下界是1， 上届是1000000，
            因此可以考虑使用二分查找来找到divisor，每次遍历中，使用一个函数来计算当前
            divisor除数组中的数之后的和，然后和t进行比较，最后的lo就是答案

        
        解题失误：在while循环中添加了sum == t 的判断，但是当sum == t的时候，并不一定是最小的值，
        因此导致提交失败

        关键技巧：遇到拥有上界和下界要求寻找一个具体值的时候，可以考虑使用二分查找

        */
        public int SmallestDivisor(int[] nums, int t) {
            int lo = 1, hi = 1000000;
            
            while (lo < hi){
                int middle = (lo + hi) / 2;
                int sum = Sum(nums, middle);
                
                if (sum > t){
                    lo = middle + 1;
                }else{
                    hi = middle;
                }
            }
            
            return lo;
        }
        
        int Sum(int[] nums, int div){
            int res = 0;
            for (int i = 0; i < nums.Length; i++){
                res += (int)Math.Ceiling((double)nums[i] / div);
            }
            
            return res;
        }

    }

    

}