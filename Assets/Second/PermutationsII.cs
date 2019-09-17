using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PermutationsII : MonoBehaviour
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
    https://leetcode.com/problems/permutations-ii/

    技巧，对于需要进行判断是否使用的，如果是独一无二的元素，可以考虑HashSet
    如果有重复的元素，可以考虑使用bool数组记录每个下标的使用情况

    回溯法, 对于重复的数字，可以先将数组进行排序，然后使用一个bool值数组记录是否使用当前数字
     */
    public IList<IList<int>> PermuteUnique(int[] nums) {
        IList<IList<int>> res = new List<IList<int>>();
        if (nums == null || nums.Length == 0) return res;
        Array.Sort(nums);
        Recursion(res, new List<int>(), nums, new bool[nums.Length]);
        return res;
    }
    
    public void Recursion(IList<IList<int>> res, IList<int> list, int[] nums, bool[] use){
        if (list.Count == nums.Length){
            res.Add(new List<int>(list));
            return ;
        }
        
        for (int i = 0; i < nums.Length; i++){
            if (use[i]) continue;
            if (i > 0 && !use[i] && !use[i - 1] && nums[i] == nums[i - 1]){
                continue;
            }
            
            list.Add(nums[i]);
            use[i] = true;
            Recursion(res, list, nums, use);
            list.RemoveAt(list.Count - 1);
            use[i] = false;
        }
    }
}
