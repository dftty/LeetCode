using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Third
{

    public class PartitionEqualSubsetSum : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        
        public bool CanPartition(int[] nums) {
            if (nums == null || nums.Length == 0) return false;
            int n = nums.Length; 
            int sum = 0;
            foreach (int i in nums){
                sum += i;
            }
            if (sum % 2 != 0) return false;
            
            bool[,] dp = new bool[n + 1, sum + 1];
            dp[0, 0] = true;
            
            for (int i = 1; i <= n; i++){
                for (int j = 0; j <= sum; j++){
                    dp[i, j] |= dp[i - 1, j];
                    if (j - nums[i - 1] >= 0)
                        dp[i, j] |= dp[i - 1, j - nums[i - 1]];
                }
            }
            
            return dp[n, sum / 2];
        }

        public bool CanPartition_(int[] nums) {
            if (nums == null || nums.Length == 0) return false;
            int n = nums.Length; 
            int sum = 0;
            
            bool[] dp = new bool[20001];
            dp[0] = true;
            for (int i = 0; i < n; i++){
                sum += nums[i];
                for (int j = sum; j >= nums[i]; j--){
                    dp[j] |= dp[j - nums[i]];
                }
            }
            
            if (sum % 2 != 0) return false;
            
            return dp[sum / 2];
        }

    }

}