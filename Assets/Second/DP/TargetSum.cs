using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    使用字典保存和和差出现的次数
    首先创建一个计数字典，向其中添加0  1， 表示数字0 出现了一次，然后遍历数组，在遍历内部遍历计数字典，
    计算出当前数字和字典中的数字的和和差，然后添加到一个新的字典中.
     */
    public int FindTargetSumWays(int[] nums, int S) {
        Dictionary<int, int> count = new Dictionary<int, int>();
        
        count.Add(0, 1);
        
        for (int i = 0; i < nums.Length; i++){
            Dictionary<int, int> count1 = new Dictionary<int, int>();
            
            foreach(KeyValuePair<int, int> pair in count)
            {
                int plus = pair.Key + nums[i];
                int minus = pair.Key - nums[i];
                if (count1.ContainsKey(plus)){
                    count1[plus] = count1[plus] + pair.Value;
                }else {
                    count1.Add(plus, pair.Value);
                }
                
                if (count1.ContainsKey(minus)){
                    count1[minus] = count1[minus] + pair.Value;
                }else {
                    count1.Add(minus, pair.Value);
                }
            }
            
            count = count1;
        }
        
        return count.ContainsKey(S) ? count[S] : 0;
    }

    /**
    
     */
    public int FindTargetSumWays_Discuss(int[] nums, int S) {
        int sum = 0;
        foreach (int n in nums){
            sum += n;
        }
         
        return sum < S || (sum + S) % 2 > 0 ? 0 : subArray(nums, (sum + S) / 2);            
    }
    
    public int subArray(int[] nums, int S){
        int[] dp = new int[S + 1];
        
        dp[0] = 1;
        
        foreach (int n in nums){
            for (int i = S; i >= n; i--){
                dp[i] += dp[i - n];
            }

            // 不可以从低到高循环，这样会导致计算出不应该被计算的值
            // for (int i = n ; i < S; i++){
            //     dp[i] += dp[i - n];
            // }
        }
        
        return dp[S];
    }
}
