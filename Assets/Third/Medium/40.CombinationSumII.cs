using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Third
{

    public class CombinationSumII : MonoBehaviour
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
        https://leetcode.com/problems/combination-sum-ii/
        Medium
        Tag: 数组 回溯

        思路：和39 类似，本题要求每个数字在一个解法中只能出现一次，
        不能出现重复的解法，因此需要对数组进行排序，回溯中跳过
        重复的选项。

        */
        public IList<IList<int>> CombinationSum2(int[] c, int target) {
            IList<IList<int>> res = new List<IList<int>>();
            if (c == null || c.Length == 0) return res;
            Array.Sort(c);
            BackTrack(res, new List<int>(), c, target, 0);
            return res;
        }
        
        void BackTrack(IList<IList<int>> res, IList<int> temp, int[] c, int target, int start){
            if (target < 0) return ;
            if (target == 0){
                res.Add(new List<int>(temp));
                return ;
            }
            
            for (int i = start; i < c.Length; i++){
                if (i > start && c[i] == c[i - 1]) continue;
                temp.Add(c[i]);
                BackTrack(res, temp, c, target - c[i], i + 1);
                temp.RemoveAt(temp.Count - 1);
            }
        }

    }

}