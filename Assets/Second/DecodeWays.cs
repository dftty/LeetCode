using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecodeWays : MonoBehaviour
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
    https://leetcode.com/problems/decode-ways/

    Discuss 动态规划
     */
    public int NumDecodings(string s) {
        if(s == null || s.Length == 0){
            return 0;
        }
        int[] dp = new int[s.Length + 1];
        dp[0] = 1;
        dp[1] = s[0] == '0' ? 0 : 1;
        for(int i = 2; i <= s.Length; i++){
            if(s[i - 1] >= '1' && s[i - 1] <= '9'){
                dp[i] += dp[i - 1];
            }
            
            int second = int.Parse(s.Substring(i - 2, 2));
            if(second >= 10 && second <= 26){
                dp[i] += dp[i - 2];
            }
        }
        
        return dp[s.Length];
    }
}
