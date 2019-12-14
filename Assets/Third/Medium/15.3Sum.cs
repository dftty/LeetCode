using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Third
{

    public class ThreeSum : MonoBehaviour
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
        https://leetcode.com/problems/3sum/
        Medium
        Tag: 数组 双指针

        思路：如果采用暴力解法，那么需要三层循环进行判断，时间复杂度过高。
        如果我们将数组排序，使用两个循环，内层循环使用双指针进行判断，那么
        时间复杂度就会降到O(n^2)

        
        注意：解题时遇到各种边界检测问题， 例如在跳过重复数字的while循环中
        没有考虑lo或者hi会超过数组边界，导致数组边界溢出。

        提交错误次数：4次
            边界没有考虑周全，还出现了数组越界情况。
        */
        public IList<IList<int>> ThreeSum_(int[] nums) {
            Array.Sort(nums);
            IList<IList<int>> res = new List<IList<int>>();
            if (nums == null || nums.Length == 0) return res;
            
            for (int i = 0; i < nums.Length; i++){
                if (i > 0 && nums[i] == nums[i - 1]) continue;
                int lo = i + 1, hi = nums.Length - 1;
                while (lo < hi){
                    while (lo - 1 > i && lo <= hi && nums[lo] == nums[lo - 1]) lo++;
                    while (hi + 1 < nums.Length && lo <= hi && nums[hi] == nums[hi + 1]) hi--;
                    if (lo >= hi) break;
                    int sum = nums[lo] + nums[hi];
                    if (sum + nums[i] == 0){
                        res.Add(new List<int>(){nums[i], nums[lo++], nums[hi--]});
                        continue;
                    }
                    
                    if (sum + nums[i] > 0){
                        hi--;
                    }else{
                        lo++;
                    }
                }
            }
            return res;
        }

        /**
        Discuss 解法

        思路：和自己的解法思路类似，但是双指针判断重复是在条件达成之后
        进行的，这样有效的避免了指针会越界的问题。

        技巧：条件达成之后再进行重复判断，把符合条件的全部跳过
        */
        public IList<IList<int>> ThreeSum_D(int[] nums) {
            Array.Sort(nums);
            IList<IList<int>> res = new List<IList<int>>();
            if (nums == null || nums.Length == 0) return res;
            
            for (int i = 0; i < nums.Length; i++){
                if (i > 0 && nums[i] == nums[i - 1]) continue;
                int lo = i + 1, hi = nums.Length - 1;
                while (lo < hi){
                    int sum = nums[lo] + nums[hi];
                    if (sum + nums[i] == 0){
                        res.Add(new List<int>(){nums[i], nums[lo], nums[hi]});
                        while(lo < hi && nums[lo] == nums[lo + 1]) lo++;
                        while(lo < hi && nums[hi] == nums[hi - 1]) hi--;
                        lo++;
                        hi--;
                        continue;
                    }
                    
                    if (sum + nums[i] > 0){
                        hi--;
                    }else{
                        lo++;
                    }
                }
            }
            return res;
        }


        /**
        c++ 实现

        vector<vector<int>> threeSum(vector<int>& nums) {
            sort(nums.begin(), nums.end());
            
            vector<vector<int>> res;
            
            for (int i = 0; i < nums.size(); i++){
                if (i > 0 && nums[i] == nums[i - 1]) continue;
                int lo = i + 1, hi = nums.size() - 1;
                while (lo < hi){
                    if (nums[i] + nums[lo] + nums[hi] == 0){
                        res.push_back({nums[i], nums[lo], nums[hi]});
                        while (lo < hi && nums[lo] == nums[lo + 1]) lo++;
                        while (lo < hi && nums[hi] == nums[hi - 1]) hi--;
                        lo++;
                        hi--;
                    }else if (nums[i] + nums[lo] + nums[hi] > 0){
                        hi--;
                    }else {
                        lo++;
                    }
                }
            }
            
            return res;
        }

        */
    }

}