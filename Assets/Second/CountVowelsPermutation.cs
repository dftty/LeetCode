using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountVowelsPermutation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        char c = (char)(10 + '0');
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
    https://leetcode.com/problems/count-vowels-permutation/

    动态规划题目
    注意：遇到需要模1000000007的题目，需要时刻警惕数据溢出的情况，最好使用long类型来保存数据，计算完成后再转int

    https://leetcode.com/problems/count-vowels-permutation/discuss/398222/Detailed-Explanation-using-Graphs-With-Pictures-O(n)
    根据题意，可以将该题转化为一道关于图的问题，每个字母代表图中的一个节点，然后规则可以转化为若干个有向边。
    计算总共有多少条长度为n的路径。
     */
    public int CountVowelPermutation(int n) {
        long[,] dp = new long[n + 1, 5];
        
        for (int i = 0; i < 5; i++){
            dp[1, i] = 1;
        }
        
        int MOD = 1000000007;
        for (int i = 1; i < n; i++){
            dp[i + 1, 0] = (dp[i, 1] + dp[i, 2] + dp[i, 4]) % MOD;
            dp[i + 1, 1] = (dp[i, 0] + dp[i, 2]) % MOD;
            dp[i + 1, 2] = (dp[i, 1] + dp[i, 3]) % MOD;
            dp[i + 1, 3] = dp[i, 2] % MOD;
            dp[i + 1, 4] = (dp[i, 2] + dp[i, 3]) % MOD;
        }
        
        int res = 0;
        for (int i = 0; i < 5; i++){
            res = (int)(res + dp[n, i]) % MOD;
        }
        
        return res;
    }
}
