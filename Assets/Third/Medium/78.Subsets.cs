using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Third
{

    public class Subsets : MonoBehaviour
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
        https://leetcode.com/problems/subsets/
        Medium
        Tag: 数组 回溯

        思路：题目中没有重复数字，因此无需排序直接回溯即可
        */
        public IList<IList<int>> Subsets_(int[] nums) {
            IList<IList<int>> res = new List<IList<int>>();
            if (nums == null) return res;
            BackTrack(res, new List<int>(), nums, 0);
            return res;
        }
        
        void BackTrack(IList<IList<int>> res, IList<int> temp, int[] nums, int start){
            res.Add(new List<int>(temp));
            
            for (int i = start; i < nums.Length; i++){
                temp.Add(nums[i]);
                BackTrack(res, temp, nums, i + 1);
                temp.RemoveAt(temp.Count - 1);
            }
        }


        /**
        Bit Mask 方法
        思路：
        首先，res的长度为什么是 1 << n， 对于示例中的数组[1, 2, 3]
        其中3个数字1， 2， 3 每个都有选或者不选两种情况，因此总共有 2 * 2 * 2，8种可能2^3

        

        */
        public IList<IList<int>> Subsets_Bit(int[] nums) {
            IList<IList<int>> res = new List<IList<int>>();
            if (nums == null) return res;
            int n = nums.Length;
            int s = 1 << n;
            
            for (int i = 0; i < s; i++){
                res.Add(new List<int>());
            }
            
            for (int i = 0; i < s; i++){
                for (int j = 0; j < n; j++){
                    if (((i >> j) & 1) == 1){
                        res[i].Add(nums[j]);
                    }
                }
            }
            
            
            return res;
        }
    }

}