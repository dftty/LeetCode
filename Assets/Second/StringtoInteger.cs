using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringtoInteger : MonoBehaviour
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
    https://leetcode.com/problems/string-to-integer-atoi/
    这是discuss中的解法
     */
    public int MyAtoi(string str) {
        if(str == null || str.Length == 0) return 0;
        
        int sign = 1;
        int res = 0;
        int i = 0;
        while(i < str.Length && str[i] == ' ') i++;
        if(i < str.Length && (str[i] == '-' || str[i] == '+')){
            sign = str[i++] == '-' ? -1 : 1;
        }
        while(i < str.Length && str[i] >= '0' && str[i] <= '9'){
            if(res > int.MaxValue / 10 || ((res == int.MaxValue / 10) && str[i] > '7')){
                return sign == 1 ? int.MaxValue : int.MinValue;
            }
            
            res = res * 10 + (str[i++] - '0');
        }
        
        return res * sign;
    }
}
