using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class LeetCode_66 : MonoBehaviour {

    void Start(){
        
    }

    // Easy https://leetcode.com/problems/plus-one/description/
    // 2018/8/15
    // 使用list保存每步计算的结果，最后翻转list，返回
    public int[] PlusOne(int[] digits) {
        if(digits == null || digits.Length == 0) return digits;
        List<int> list = new List<int>();
        int sum = 1;
        for(int i = digits.Length - 1; i >= 0; i--){
            sum += digits[i];
            list.Add(sum % 10);
            sum = sum / 10;
        }
        
        if(sum > 0) list.Add(sum);
        list.Reverse();
        return list.ToArray();
    }

    // Discuss solution
    // 这个方法直接判断第i位是否小于9， 如果是，则加一返回，否则，这个数就是1后面全是0
    public int[] PlusOne_(int[] digits) {
        if(digits == null || digits.Length == 0) return digits;
        int n = digits.Length;

        for(int i = n - 1; i >= 0; i--){
            if(digits[i] < 9){
                digits[i]++;
                return digits;
            }

            digits[i] = 0;
        }
        
        int[] newArr = new int[n + 1];
        newArr[0] = 1;
        return newArr;
    }
}


