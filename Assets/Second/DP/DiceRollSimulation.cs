using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRollSimulation : MonoBehaviour
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
    https://leetcode.com/problems/dice-roll-simulation/

    
    https://leetcode.com/problems/dice-roll-simulation/discuss/403756/Java-Share-my-DP-solution

    动态规划题目
     */
    public int DieSimulator(int n, int[] rollMax) {
        long[,] dp = new long[n, 7];
        
        for (int i = 0; i < 6; i++){
            dp[0, i] = 1;
        }
        
        dp[0, 6] = 6;
        
        int MOD = 1000000007;
        
        for (int i = 1; i < n; i++){
            long sum = 0;
            for (int j = 0; j < 6; j++){
                dp[i, j] = dp[i - 1, 6];
                
                if (i - rollMax[j] == 0){
                    dp[i, j] -= 1;
                }
                
                if (i - rollMax[j] > 0){
                    long reduce = dp[i - rollMax[j] - 1, 6] - dp[i - rollMax[j] - 1, j];
                    // 加一个MOD是因为减法有可能出现负数的情况
                    dp[i, j] = ((dp[i, j] - reduce) % MOD + MOD) % MOD;
                }
                
                sum = (sum + dp[i, j]) % MOD;
            }
            
            dp[i, 6] = sum;
        }
        
        
        return (int)dp[n - 1, 6];
    }
}
