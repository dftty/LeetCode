using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongestCommonPrefix : MonoBehaviour
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
    https://leetcode.com/problems/longest-common-prefix/

    采用两个指针计算字符串下标
     */
    public string LongestCommonPrefix_(string[] strs) {
        if(strs == null || strs.Length == 0) return "";
        string res = strs[0];
        
        for(int i = 1; i < strs.Length; i++){
            int fi = 0;
            int se = 0;
            
            while(fi < res.Length && se < strs[i].Length && res[fi] == strs[i][se]){
                fi++;
                se++;
            }
            
            if(fi < se){
                res = res.Substring(0, fi);
            }else{
                res = strs[i].Substring(0, se);
            }
        }
        
        return res;
    }
}
