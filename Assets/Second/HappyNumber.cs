using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappyNumber : MonoBehaviour
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
    https://leetcode.com/problems/happy-number/

    判断是否会无限循环，如果出现了无限循环，则其中必定会出现重复数字组成环路
    使用set存储每次计算出来的数字，如果出现了重复的数字，则表明会无限循环下去。
     */
    public bool IsHappy(int n) {
        HashSet<int> hashSet = new HashSet<int>();
        
        if (n < 0) return false;
        
        while (n != 1){
            if (!hashSet.Add(n))
                return false;
            int sum = 0;
            while (n != 0){
                int temp = n % 10;
                sum += temp * temp;
                n = n / 10;
            }
            
            n = sum;
        }
        
        return true;
    }
}
