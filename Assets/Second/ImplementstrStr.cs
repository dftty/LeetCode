using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImplementstrStr : MonoBehaviour
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
    https://leetcode.com/problems/implement-strstr/

    KMP 字符串匹配算法
     */
    public int StrStr(string haystack, string needle) {
        if(needle == ""){
            return 0;
        }
        
        if(needle.Length > haystack.Length) return -1;
        
        int[] maxLength = CalculateMaxLength(needle);
        
        int count = 0;
        for(int i = 0; i < haystack.Length; i++){
            while(count > 0 && haystack[i] != needle[count]){
                count = maxLength[count - 1];
            }
            
            if(haystack[i] == needle[count]){
                count++;
            }
            
            if(count == needle.Length){
                return i - needle.Length + 1;
            }
        }
        
        return -1;
    }
    
    int[] CalculateMaxLength(string needle)
    {
        int[] res = new int[needle.Length];
        int count = 0;
        
        for(int i = 1; i < needle.Length; i++){
            while(count > 0 && needle[count] != needle[i]){
                count = res[count - 1];
            }
            
            if(needle[count] == needle[i]){
                count++;
            }
            
            res[i] = count;
        }
        
        return res;
    }
}
