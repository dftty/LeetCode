using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanMakePalindromefromSubstring : MonoBehaviour
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
    https://leetcode.com/problems/can-make-palindrome-from-substring/

    关键字： 前缀和，字符串

    Disciss解法：
    题目中出现了区间，根据题意有可能还需要对其中的字符个数进行计数，因此首相应该想到的就是
    是否可以求字符串的前缀和数组
     */
    public IList<bool> CanMakePaliQueries(string s, int[][] queries) {
        IList<bool> res = new List<bool>();
        
        int[,] count = new int[s.Length + 1, 26];
        for (int i = 1; i <= s.Length; i++){
            for (int j = 0; j < 26; j++){
                if (j == (s[i - 1] - 'a')){
                    count[i, j] = count[i - 1, j] + 1;
                }else {
                    count[i, j] = count[i - 1, j];
                }
            }
        }
        
        for (int i = 0; i < queries.Length; i++){
            int sum = 0;
            for (int j = 0; j < 26; j++){
                sum += (count[queries[i][1] + 1, j] - count[queries[i][0], j]) % 2;
            }
            
            res.Add(queries[i][2] >= sum / 2);
        }
        
        return res;
    }
}
