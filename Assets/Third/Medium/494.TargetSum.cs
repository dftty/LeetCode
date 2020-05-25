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

        /**
        思路： 标准dp解法，因为S可能为负数，所以构建一个长度为sum * 2 + 1的dp数组，
        前半部分代表负数，后半部分代表负数。
        */
        public int FindTargetSumWays_(int[] nums, int S) {
            int n = nums.Length;
            
            int sum = 0;
            foreach (int i in nums){
                sum += i;
            }
            
            if (S < -sum || S > sum){
                return 0;
            }
            
            int[,] dp = new int[n + 1, sum * 2 + 1];
            dp[0, sum] = 1;
            int high = sum * 2;
            
            for (int i = 1; i <= n; i++){
                for (int j = 0; j <= high; j++){
                    if (j + nums[i - 1] <= high){
                        dp[i, j + nums[i - 1]] += dp[i - 1, j];
                    }
                    
                    if (j - nums[i - 1] >= 0){
                        dp[i, j - nums[i - 1]] += dp[i - 1, j];
                    }
                }
            }
            
            return dp[n, sum + S];
        }

        /**
        上一种解法的优化，将dp数组优化为一维
        缩小内层循环的范围
        */
        public int FindTargetSumWays__(int[] nums, int S) {
            int n = nums.Length;
            
            int sum = 0;
            foreach (int i in nums){
                sum += i;
            }
            
            if (S < -sum || S > sum){
                return 0;
            }
            
            int[] dp = new int[sum * 2 + 1];
            dp[sum] = 1;
            int high = sum * 2;
            
            int left = sum;
            int right = sum;
            
            for (int i = 1; i <= n; i++){
                // 内层循环的左边界
                left -= nums[i - 1];
                // 内层循环的右边界
                right += nums[i - 1];
                int[] temp = new int[high + 1];
                for (int j = left; j <= right; j++){
                    if (j + nums[i - 1] <= high){
                        temp[j + nums[i - 1]] += dp[j];
                    }
                    
                    if (j - nums[i - 1] >= 0){
                        temp[j - nums[i - 1]] += dp[j];
                    }
                }
                dp = temp;
            }
            
            return dp[sum + S];
        }


    }

}