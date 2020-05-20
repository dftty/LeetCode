using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Third
{
    
    public class TargetSum : MonoBehaviour
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
        https://leetcode.com/problems/target-sum/
        Tag:动态规划

        思路：使用字典来保存到当前位置总共出现的每种sum的次数。

        */
        public int FindTargetSumWays(int[] nums, int S) {
            int n = nums.Length;
            Dictionary<int, int> dic = new Dictionary<int, int>();
            
            dic.Add(0, 1);
            for (int i = 0; i < n; i++){
                Dictionary<int, int> temp = new Dictionary<int, int>();
                foreach (KeyValuePair<int, int> keyValue in dic){
                    int val1 = keyValue.Key + nums[i];
                    int val2 = keyValue.Key - nums[i];
                    
                    if (temp.ContainsKey(val1)){
                        temp[val1] += keyValue.Value;
                    }else{
                        temp.Add(val1, keyValue.Value);
                    }
                    
                    if (temp.ContainsKey(val2)){
                        temp[val2] += keyValue.Value;
                    }else{
                        temp.Add(val2, keyValue.Value);
                    }
                }
                
                dic = temp;
            }
            
            if (dic.ContainsKey(S)){
                return dic[S];
            }
            
            return 0;
        }

    }

}