using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberofWaystoStayintheSamePlaceAfterSomeSteps : MonoBehaviour
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
    https://leetcode.com/problems/number-of-ways-to-stay-in-the-same-place-after-some-steps/

    Discuss 解法， 动态规划，该题需要模10^9 + 7,因此需要注意使用long而不是int，保证不会溢出

    

    */

    long[][] dp;
    int len;
    long MOD = 1000000007;
    public int NumWays(int steps, int arrLen) {
        dp = new long[steps / 2 + 1][];
        len = arrLen;
        for (int i = 0; i < steps / 2 + 1; i++){
            dp[i] = new long[steps + 1];
            for (int j = 0; j < steps + 1; j++){
                dp[i][j] = -1;
            }
        }
        
        return (int)dfs(0, steps);
    }
    
    long dfs(int i, int steps){
        if (i == 0 && steps == 0){
            return 1;
        }else if (i < 0 || i >= len || steps < 0 || i > steps){
            return 0;
        }else if (dp[i][steps] != -1){
            return dp[i][steps];
        }
        dp[i][steps] = (dfs(i + 1, steps - 1) % MOD + dfs(i - 1, steps - 1) % MOD + dfs(i, steps - 1) % MOD) % MOD;
        return dp[i][steps];
    }
}
