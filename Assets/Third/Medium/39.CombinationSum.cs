using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Third
{

    public class CombinationSum : MonoBehaviour
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
        https://leetcode.com/problems/combination-sum/
        Medium
        Tag : 数组 回溯

        思路：可以使用回溯求解
        题目中说明没有重复数字，因此无需对原数组进行排序

        */
        public IList<IList<int>> CombinationSum_(int[] c, int target) {
            IList<IList<int>> res = new List<IList<int>>();
            if (c == null || c.Length == 0) return res;
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
                temp.Add(c[i]);
                BackTrack(res, temp, c, target - c[i], i);
                temp.RemoveAt(temp.Count - 1);
            }
        }
    }

}