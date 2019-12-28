using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace Third
{

    public class DivideArrayinSetsofKConsecutiveNumbers : MonoBehaviour
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
        https://leetcode.com/problems/divide-array-in-sets-of-k-consecutive-numbers/
        Medium
        Tag: 数组 贪心

        思路：使用一个字典来保存每个数字对应的set列表

        */
        public bool IsPossibleDivide(int[] nums, int k) {
            if (nums.Length % k != 0){
                return false;
            }
            Dictionary<int, List<List<int>>> dic = new Dictionary<int, List<List<int>>>();
            Array.Sort(nums);

            dic.Keys.Min();
            
            for (int i = 0; i < nums.Length; i++){
                if (dic.Count == 0){
                    List<List<int>> temp = new List<List<int>>();
                    temp.Add(new List<int>(){nums[i]});
                    dic.Add(nums[i], temp);
                }else{
                    if (dic.ContainsKey(nums[i] - 1)){
                        List<List<int>> list = dic[nums[i] - 1];
                        
                        list[0].Add(nums[i]);
                        if (list[0].Count == k){
                            list.RemoveAt(0);
                        }else{
                            List<int> first = list[0];
                            if (dic.ContainsKey(nums[i])){
                                dic[nums[i]].Add(first);
                            }else{
                                dic.Add(nums[i], new List<List<int>>(){first});
                            }
                            
                            list.RemoveAt(0);
                        }
                        
                        if (dic[nums[i] - 1].Count == 0){
                            dic.Remove(nums[i] - 1);
                        }
                    }else {
                        List<List<int>> temp = new List<List<int>>();
                        temp.Add(new List<int>(){nums[i]});
                        if (dic.ContainsKey(nums[i])){
                            dic[nums[i]].Add(new List<int>(){nums[i]});
                        }else{
                            dic.Add(nums[i], temp);
                        }
                        
                    }
                }
            }
            
            foreach (var keyValue in dic){
                for (int i = 0; i < keyValue.Value.Count; i++){
                    if (keyValue.Value[i].Count != k){
                        return false;
                    }
                }
            }
                
            return true;
        }


        /**

        思路：使用字典来保存每个数字和它对应出现的次数，
        然后遍历字典，找出字典中的最小的数字，如果它出现了m次，那么后续k个
        数字也必须出现m次，我们找到后续数字，依次移除，如果数量不够或者
        不存在下一个数字，那么久不能成立

        */
        public bool IsPossibleDivide_(int[] nums, int k) {
            if (nums.Length % k != 0){
                return false;
            }
            
            Dictionary<int, int> dic = new Dictionary<int, int>();
            
            for (int i = 0; i < nums.Length; i++){
                if (!dic.ContainsKey(nums[i])){
                    dic[nums[i]] = 1;
                }else{
                    dic[nums[i]]++;
                }
            }
            
            while (dic.Count > 0){
                int min = int.MaxValue;
                foreach (var val in dic){
                    min = Math.Min(val.Key, min);
                }
                
                if (dic[min] == 0){
                    dic.Remove(min);
                    continue;
                }
                
                int count = dic[min];
                for (int i = 0; i < k; i++){
                    if (dic.ContainsKey(min + i)){
                        if (dic[min + i] < count){
                            return false;
                        }
                        if (dic[min + i] > count){
                            dic[min + i] -= count;
                        }else{
                            dic.Remove(min + i);
                        }
                    }else{
                        return false;
                    }
                }
            }
            
            return true;
        }
    }

}