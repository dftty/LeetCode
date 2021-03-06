﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Third
{

    public class SubsetsII : MonoBehaviour
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
        https://leetcode.com/problems/subsets-ii/
        Medium
        Tag ： 数组  回溯

        */
        public IList<IList<int>> SubsetsWithDup(int[] nums) {
            IList<IList<int>> res = new List<IList<int>>();
            if (nums == null || nums.Length == 0) return res;
            Array.Sort(nums);
            BackTrack(res, new List<int>(), nums, 0);
            return res;
        }

        void BackTrack(IList<IList<int>> res, List<int> temp, int[] nums, int start){
            res.Add(new List<int>(temp));
            
            for (int i = start; i < nums.Length; i++){
                if (i > start && nums[i] == nums[i - 1]) continue;
                temp.Add(nums[i]);
                BackTrack(res, temp, nums, i + 1);
                temp.RemoveAt(temp.Count - 1);
            }
        }

        /**
        c++ 实现
        vector<vector<int>> subsetsWithDup(vector<int>& nums) {
            vector<vector<int>> res;
            vector<int> temp;
            sort(nums.begin(), nums.end());
            backTrack(res, temp, nums, 0);
            return res;
        }
        
        void backTrack(vector<vector<int>>& res, vector<int>& temp, vector<int>& nums, int start){
            res.push_back(temp);
            
            for (int i = start; i < nums.size(); i++){
                if (i > start && nums[i] == nums[i - 1]) continue;
                temp.push_back(nums[i]);
                backTrack(res, temp, nums, i + 1);
                temp.pop_back();
            }
        }

        */
    }

}