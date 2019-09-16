using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UglyNumber : MonoBehaviour
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
    https://leetcode.com/problems/ugly-number/

    递归除这三个素数
     */
    public bool IsUgly(int num) {
        if (num <= 0) return false;
        int res = check(num);
        return res == 1;
    }
    
    public int check(int num){
        if (num % 2 == 0){
            return check(num / 2);
        }else if(num % 3 == 0){
            return check(num / 3);
        }else if(num % 5 == 0){
            return check(num / 5);
        }
        
        return num;
    }

    /**
    非递归解法
     */
    public bool IsUgly_(int num) {
        if (num <= 0) return false;
        
        while (num != 1){
            int temp = num;
            
            if (num % 2 == 0){
                num = num / 2;
            }else if(num % 3 == 0){
                num = num / 3;
            }else if(num % 5 == 0){
                num = num / 5;
            }
            
            if (temp == num){
                return false;
            }
        }
        
        return true;
    }
}
