using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrambleString : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(IsScramble("great", "rgeat"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
    https://leetcode.com/problems/scramble-string/

    利用递归和子字符串来判断子字符串是否相等
     */
    public bool IsScramble(string s1, string s2) {
        if(s1 == s2){
            return true;
        }
        
        int[] count = new int[128];
        int len = s1.Length;
        for(int i = 0; i < len; i++){
            count[s1[i]]++;
            count[s2[i]]--;
        }
        
        for(int i = 0; i < count.Length; i++){
            if(count[i] != 0){
                return false;
            }
        }
        
        for(int i = 1; i < len; i++){
            // 这是不互换的情况
            if(IsScramble(s1.Substring(0, i), s2.Substring(0, i)) && IsScramble(s1.Substring(i), s2.Substring(i))){
                return true;
            }
            
            // 这是互换的情况
            if(IsScramble(s1.Substring(0, i), s2.Substring(len - i)) && IsScramble(s1.Substring(i), s2.Substring(0, len - i))){
                return true;
            }
        }
        
        return false;
    }
}
